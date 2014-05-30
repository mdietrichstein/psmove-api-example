using UnityEngine;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using io.thp.psmove;

public class PSMoveThread : MonoBehaviour {
	public static float FUSION_Z_NEAR = -1f;
	public static float FUSION_Z_FAR = 10f;

	private bool useTracker = true;

	private Thread t;
	private bool running = true;

	private PSMoveCameraTracker cameraTracker;
	private LinkedList<PSMoveController> controllers = new LinkedList<PSMoveController>();
	
	void Start () {
		t = new Thread(new ThreadStart(PSMoveHandler));
		t.Start();
	}

	
	public void PSMoveHandler() {
		try {
			
			psmoveapi_csharp.psmove_init(PSMove_Version.PSMOVE_CURRENT_VERSION);
			
			int numConnected = psmoveapi_csharp.count_connected();
			Log(string.Format("{0} controllers found", numConnected));
	
			if(useTracker && !SetupTracker()) {
				return;
			}

			Log("Creating Controller");
			var c = new PSMoveController(psmoveapi_csharp.psmove_connect());
			if(!AddController(c)) {
				Log("Unable to create controller");
				c.Disconnect();
				c = null;
			} else {
				Log("Created controller");
			}


			while (running) {
				if(useTracker) {
					// update positions
					cameraTracker.Update();
					foreach(var controller in controllers) {
						cameraTracker.UpdateControllerPosition(controller);
					}
				}

				// update buttons and orientation
				foreach(var controller in controllers) {
					controller.Update();
				}
				/* Optional and not required by default
            byte r, g, b;
            tracker.get_color(move, out r, out g, out b);
            move.set_leds(r, g, b);
            move.update_leds();
            */
				
				/* If we're tracking, output the position */
				/*
				if (controller.IsTracking()) {
					
					controller.Update();
					
					Log("TRACKER " + controller.TrackerPosition);
					Log("FUSION " + controller.FusionPosition);
				} else {
					Log("Not Tracking!");
				}

*/
			}



			CleanUp();
		} catch(Exception e) {
			Log("Error while processing move controller(s): " + e.Message);
		}
	}

	private bool AddController(PSMoveController controller) {
		if(useTracker) {
			// Calibrate the controller in the camera picture
			int trackerEnableCount = 3;
			Log("Attempting to enable tracker");
			
			while (!cameraTracker.EnableTracker(controller)) {
				Log(string.Format("Failed to enable tracker with attempt {0}, status {1}", trackerEnableCount, cameraTracker.GetStatus(controller)));
				trackerEnableCount++;
				if(trackerEnableCount>1) {
					Log ("Permanently failed to enable tracker, exiting");
					return false;
				}
				Thread.Sleep(200);
			};

		}

		controllers.AddLast(controller);
		return true;
	}

	private bool SetupTracker() {
		
		Log("Creating Tracker");
		cameraTracker = new PSMoveCameraTracker();
		Log("Tracker created");
		
		PSMove move = psmoveapi_csharp.psmove_tracker_exposure_lock_init();
		
		if(move == null) {
			Log("No Move Controller found, quitting");
			return false;
		}

		Func<bool> waitForMoveButton = () => {
			while(psmoveapi_csharp.psmove_poll(move) > 0) {
				uint buttons = psmoveapi_csharp.psmove_get_buttons(move);
				return (buttons & ( (uint)Button.Btn_MOVE) ) > 0;
			}
			return false;
		};

		Log("Press PSMove Button");
		while(!waitForMoveButton());
		
		Log("Exposure Lock Process");
		psmoveapi_csharp.psmove_tracker_exposure_lock_process(move, cameraTracker.Tracker, 0);
		
		Log("Press PSMove Button");
		while(!waitForMoveButton());
		psmoveapi_csharp.psmove_tracker_exposure_lock_finish(move);

		cameraTracker.EnableFusion(FUSION_Z_NEAR, FUSION_Z_FAR);

		Log("Tracker enabled");

		return true;
	}
	
	private void CleanUp() {
		Log ("CleanUp");

		foreach(var controller in controllers) {
			if(cameraTracker.IsTracking(controller)) {
				cameraTracker.StopTracking(controller);
			}

			controller.Disconnect();	
		}

		controllers.Clear();
		cameraTracker.Disable();
	}
	
	private bool WaitForMoveButton(PSMove move) {
		while(psmoveapi_csharp.psmove_poll(move) > 0) {
			uint buttons = psmoveapi_csharp.psmove_get_buttons(move);
			return (buttons & ( (uint)Button.Btn_MOVE) ) > 0;
		}
		return false;

	}
	
	private void Log(String message) {
		Loom.QueueOnMainThread( () =>
			Debug.Log(message)
		);
	} 
	
	void OnApplicationQuit() {
		running = false;
		t.Join();
	}
}
