using UnityEngine;
using System.Collections;
using io.thp.psmove;

public class PSMoveController {
	
	#region Private Members
	private PSMove move;
	private PSMoveTracker tracker;
	private PSMoveFusion fusion;
	
	private Vector3 trackerPosition;
	private Vector3 fusionPosition;
	
	private ConnectionType connectionType;
	#endregion
	
	#region Properties
	public PSMove Move { get { return move; } }
	public PSMoveTracker Tracker { 
		get { return tracker; }
		set {
			this.tracker = value;
		}
	}
	
	public Vector3 TrackerPosition { get { return trackerPosition; } }
	public Vector3 FusionPosition { get { return fusionPosition; } }
	
	public ConnectionType ConnectionType { get { return connectionType; } }
	#endregion
	
	public PSMoveController(PSMove move) {
		this.move = move;
		this.connectionType = psmoveapi_csharp.psmove_connection_type(move);
	}
	
	#region Configuration
	public bool EnableTracker() {
		if(tracker == null) {
			Log("PSMoveController.Tracker not set!");
			return false;
		}
		
		return tracker.enable(move) == Status.Tracker_CALIBRATED;
	}
	
	public bool EnableFusion(float zNear, float zFar) {
		if(tracker != null && !IsCalibrated()) {
			Log("Tracker not enabled. Call PSMoveController.EnableTracker first");
			return false;
		}
		
		fusion = psmoveapi_csharp.psmove_fusion_new(tracker, zNear, zFar);
		if(fusion != null) {
			Log("Could not create PSMoveFusion");
		}
		
		return fusion != null;
	}
	
	public void DisableTracker() {
		if(tracker != null) {
			tracker.disable(move);
			fusion = null;
		}
	}
	
	#endregion
	
	#region Querying
	public Status GetTrackerStatus() {
		return tracker.get_status(move);	
	}
	
	public bool IsCalibrated() {
		return GetTrackerStatus() == Status.Tracker_CALIBRATED;
	}
	
	public bool IsTracking() {
		return GetTrackerStatus() == Status.Tracker_TRACKING;
	}
	#endregion
	
	#region State Updates
	public void Update() {
		if(move.poll() > 0) {
			//update button states	
		}
		
		if(IsTracking()) {		
			if(tracker != null) {
				tracker.get_position(move, out trackerPosition.x, out trackerPosition.y, out trackerPosition.z);
			}
			
			if(fusion != null) {
				fusion.get_position(move, out fusionPosition.x, out fusionPosition.y, out fusionPosition.z);
			}
		}
	}
	#endregion
	
	private void Log(string message) {
		Loom.QueueOnMainThread( () =>
			Debug.Log(message)
		);
	} 
}
