using UnityEngine;
using System.Collections;
using io.thp.psmove;


#region enums and structs

public enum PSMoveConnectionType  {
	Bluetooth,
	USB,
	Unknown,
};

public enum PSMoveButton {
	L2 = 1 << 0x00,
	R2 = 1 << 0x01,
	L1 = 1 << 0x02,
	R1 = 1 << 0x03,
	Triangle = 1 << 0x04,
	Circle = 1 << 0x05,
	Cross = 1 << 0x06,
	Square = 1 << 0x07,
	Select = 1 << 0x08,
	L3 = 1 << 0x09,
	R3 = 1 << 0x0A,
	Start = 1 << 0x0B,
	Up = 1 << 0x0C,
	Right = 1 << 0x0D,
	Down = 1 << 0x0E,
	Left = 1 << 0x0F,
	PS = 1 << 0x10,
	Move = 1 << 0x13,
	Trigger = 1 << 0x14
};

public enum PSMoveBatteryLevel {
	Min = 0x00, /*!< Battery is almost empty (< 20%) */
	TwentyPercent = 0x01, /*!< Battery has at least 20% remaining */
	FourtyPercent = 0x02, /*!< Battery has at least 40% remaining */
	SixtyPercent = 0x03, /*!< Battery has at least 60% remaining */
	EightyPercent = 0x04, /*!< Battery has at least 80% remaining */
	Max = 0x05, /*!< Battery is fully charged (not on charger) */
	Charging = 0xEE, /*!< Battery is currently being charged */
	Charged = 0xEF, /*!< Battery is fully charged (on charger) */
};

#endregion

public class PSMoveController {
	
	#region Private Members
	private PSMove move;

	private Vector3 trackerPosition;
	private Vector3 fusionPosition;
	private Quaternion orientation;
	private Color color;

	private PSMoveConnectionType connectionType;
	#endregion
	
	#region Properties
	public PSMove Move { get { return move; } }
	public Vector3 TrackerPosition { get { return trackerPosition; } }
	public Vector3 FusionPosition { get { return fusionPosition; } }
	public Quaternion Orientation { get { return orientation; } }
	public Color Color { get { return color; } }

	public PSMoveConnectionType ConnectionType { get { return connectionType; } }
	#endregion

	#region State
	private uint currentButtonState;
	private uint previousButtonState;
	#endregion


	public PSMoveController(PSMove move) {
		this.move = move;
		this.color = Color.blue;
		this.connectionType = (PSMoveConnectionType)psmoveapi_csharp.psmove_connection_type(move);

		this.currentButtonState = 0;
		this.previousButtonState = 0;
	}
	
	#region Configuration
	public void Disconnect() {
		if(move != null) {
			psmoveapi_csharp.psmove_disconnect(move);
			move = null;
		}
	}
	#endregion
	
	#region State Updates
	public void Update() {

		this.previousButtonState  = this.currentButtonState;
		this.currentButtonState = 0;
		while(move.poll() > 0) {
			this.currentButtonState |= (uint)move.get_buttons();
		}

		float q0 = 0.0f, q1 = 0.0f, q2 = 0.0f, q3 = 0.0f;
		move.get_orientation(out q0, out q1, out q2, out q3);

		orientation.x=q0;
		orientation.x=q1;
		orientation.y=q2;
		orientation.z=q3;


		Debug.Log(orientation.eulerAngles);
	}

	public void UpdatePosition(Vector3 trackerPosition, Vector3 fusionPosition) {
		this.trackerPosition = trackerPosition;
		this.fusionPosition = fusionPosition;
	} 

	public void SetColor(Color color) {
		this.color = color;
		move.set_leds( (char)(color.r * 255), (char)(color.g * 255), (char)(color.b * 255) );
		move.update_leds();
	}

	#endregion

	#region Public

	public void InitOrientation(){
		if(!HasOrientation()){
			if(!HasCalibration()){
				Debug.Log("Move is not calibrated, cannot use orientation");
			}
			else{
				Debug.Log("Move does not have orientation set up, enabling...");
				EnableOrientation();
				ResetOrientation();
			}
		}
	}

	public bool HasCalibration() {
		return move.has_calibration()==1;
	}

	public bool HasOrientation() {
		return move.has_orientation()==1;
	}

	public void ResetOrientation() {
		move.reset_orientation();
	}

	public void EnableOrientation() {
		move.enable_orientation(1);
	}

	public void DisableOrientation() {
		move.enable_orientation(0);
	}

	public void EnableRateLimiting() {
		move.set_rate_limiting(1);
	}

	public void DisableRateLimiting() {
		move.set_rate_limiting(0);
	}

	public bool GetButton(PSMoveButton b) {
		return ((currentButtonState & (uint)b) != 0);
	}

	public bool GetButtonDown(PSMoveButton b) {
		return ((previousButtonState & (uint)b) == 0) && ((currentButtonState & (uint)b) != 0);
	}

	public bool GetButtonUp(PSMoveButton b) {
		return ((previousButtonState & (uint)b) != 0) && ((currentButtonState & (uint)b) == 0);
	}
	#endregion
	
	
	#region Utils
	private void Log(string message) {
		Loom.QueueOnMainThread( () =>
			Debug.Log(message)
		);
	}
	#endregion
}
