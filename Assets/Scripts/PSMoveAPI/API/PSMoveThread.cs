using UnityEngine;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using io.thp.psmove;

public class PSMoveThread : MonoBehaviour {
	public static float FUSION_Z_NEAR = -1f;
	public static float FUSION_Z_FAR = 10f;
	
	private Thread t;
	private bool running = true;
	
	private LinkedList<PSMoveController> controllers = new LinkedList<PSMoveController>();
	
	void Start () {
		Loom l = Loom.Current;
		t = new Thread(new ThreadStart(PSMoveHandler));
		t.Start();
	}
	
	public void PSMoveHandler() {
		try {
			
			psmoveapi_csharp.psmove_init(PSMove_Version.PSMOVE_CURRENT_VERSION);
			
			int numConnected = psmoveapi_csharp.count_connected();
			Log(string.Format("{0} controllers found", numConnected));
			
			Log("Creating Tracker");
			PSMoveTracker tracker = psmoveapi_csharp.psmove_tracker_create_default();
			Log("Tracker created");
			
			PSMove move = psmoveapi_csharp.psmove_tracker_exposure_lock_init();
			while(!WaitForMoveButton(move));
			
			psmoveapi_csharp.psmove_tracker_exposure_lock_process(move, tracker, 0);
			
			while(!WaitForMoveButton(move));
			psmoveapi_csharp.psmove_tracker_exposure_lock_finish(move);
			
			Log("Creating Move");
			PSMoveController controller = new PSMoveController(psmoveapi_csharp.psmove_connect());
			Log("Move created");
			
			Log("Setting Tracker");
			controller.Tracker = tracker;
			Log("Tracker Set");
			
	        /* Calibrate the controller in the camera picture */
			int trackerEnableCount = 1;
			Log("Attempting to enable tracker");
			
	        while (!controller.EnableTracker()) {
				Log(string.Format("Failed to enable tracker with attempt {0}, status {1}", trackerEnableCount, controller.GetTrackerStatus()));
				trackerEnableCount++;
				if(trackerEnableCount>1) {
					return;
				}
				Thread.Sleep(200);
			};
			
			controller.EnableFusion(FUSION_Z_NEAR, FUSION_Z_FAR);
			
	        while (running) {
	            /* Get a new image from the camera */
	            tracker.update_image();
	            /* Track controllers in the camera picture */
	            tracker.update();
	
	            /* Optional and not required by default
	            byte r, g, b;
	            tracker.get_color(move, out r, out g, out b);
	            move.set_leds(r, g, b);
	            move.update_leds();
	            */
	
	            /* If we're tracking, output the position */
	            if (controller.IsTracking()) {
					
					controller.Update();
					
					Log("TRACKER " + controller.TrackerPosition);
					Log("FUSION " + controller.FusionPosition);					
	            } else {
	                Log("Not Tracking!");
	            }
	        }
			
			if(tracker != null) {
				//controller.DisableTracker();
			}
		} catch(Exception e) {
			Log("Error while processing move controller(s): " + e.Message);
		}
	}
	
	private bool WaitForMoveButton(PSMove move) {
		while(true) {
			if(psmoveapi_csharp.psmove_poll(move) > 0) {
				uint buttons = psmoveapi_csharp.psmove_get_buttons(move);
				return (buttons & ( (uint)Button.Btn_MOVE) ) > 0;
			} else {
				return false;
			}
			
			Thread.Sleep(100);
		}
	}
	
	private void Log(String message) {
		Loom.QueueOnMainThread( () =>
			Debug.Log(message)
		);
	} 

	void OnApplicationQuit() {
		Log("QUIT");
		running = false;
		
		//t.Join();
	}
}
