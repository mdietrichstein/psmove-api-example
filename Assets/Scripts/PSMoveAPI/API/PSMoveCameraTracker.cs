using UnityEngine;
using System.Collections;
using io.thp.psmove;

#region enums and structs

public enum PSMoveCameraTrackerStatus  {
	NotCalibrated,
	CalibrationError,
	Calibrated,
	Tracking
};

#endregion

public class PSMoveCameraTracker {
	#region Private Members
	private PSMoveTracker tracker;
	private PSMoveFusion fusion;
	#endregion

	#region Properties
	public PSMoveTracker Tracker { get { return tracker; }}
	#endregion

	public PSMoveCameraTracker() {
		this.tracker = psmoveapi_csharp.psmove_tracker_create_default();
	}
	
	#region Configuration
	public bool EnableTracker(PSMoveController controller) {
		return ((PSMoveCameraTrackerStatus)tracker.enable(controller.Move)) == PSMoveCameraTrackerStatus.Calibrated;
	}
	
	public bool EnableFusion(float zNear, float zFar) {
		if(tracker == null) {
			Log("Tracker not enabled. Call PSMoveController.EnableTracker first");
			return false;
		}

		fusion = psmoveapi_csharp.psmove_fusion_new(tracker, zNear, zFar);
		if(fusion != null) {
			Log("Could not enable fusion");
		} else {
			Log("Fusion enabled");
		}
		
		return fusion != null;
	}
	
	public void Disable() {
		if(fusion != null) {
			psmoveapi_csharp.psmove_fusion_free(fusion);
			fusion = null;
		}

		if(tracker != null) {
			//psmoveapi_csharp.psmove_tracker_free(tracker);
			tracker = null;
		}
	}

	public void StopTracking(PSMoveController controller) {
		if(tracker != null) {
			tracker.disable(controller.Move);
		}
	}
	#endregion

	#region Querying
	public PSMoveCameraTrackerStatus GetStatus(PSMoveController controller) {
		return (PSMoveCameraTrackerStatus)tracker.get_status(controller.Move);
	}
	
	public bool IsCalibrated(PSMoveController controller) {
		return GetStatus(controller) == PSMoveCameraTrackerStatus.Calibrated;
	}
	
	public bool IsTracking(PSMoveController controller) {
		return GetStatus(controller) == PSMoveCameraTrackerStatus.Tracking;
	}
	#endregion

	public void Update() {
		/* Get a new image from the camera */
		tracker.update_image();
		/* Track controllers in the camera picture */
		tracker.update();

	}

	private Vector3 trackerPosition;
	private Vector3 fusionPosition;

	public void UpdateControllerPosition(PSMoveController controller) {
		if(tracker != null) {
			tracker.get_position(controller.Move, out trackerPosition.x, out trackerPosition.y, out trackerPosition.z);
		}
		
		if(fusion != null) {
			fusion.get_position(controller.Move, out fusionPosition.x, out fusionPosition.y, out fusionPosition.z);
		}

		controller.UpdatePosition(trackerPosition, fusionPosition);
	}

	private void Log(string message) {
		Loom.QueueOnMainThread( () => Debug.Log(message) );
	}
}
