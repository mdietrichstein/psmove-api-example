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
	
	private PSMoveConnectionType connectionType;
	#endregion
	
	#region Properties
	public PSMove Move { get { return move; } }
	public Vector3 TrackerPosition { get { return trackerPosition; } }
	public Vector3 FusionPosition { get { return fusionPosition; } }
	
	public PSMoveConnectionType ConnectionType { get { return connectionType; } }
	#endregion

	#region State
	private uint currentButtonState;
	private uint previousButtonState;
	#endregion


	public PSMoveController(PSMove move) {
		this.move = move;
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
	}
	#endregion

	public void UpdatePosition(Vector3 trackerPosition, Vector3 fusionPosition) {
		this.trackerPosition = trackerPosition;
		this.fusionPosition = fusionPosition;
	} 

	private void Log(string message) {
		Loom.QueueOnMainThread( () =>
			Debug.Log(message)
		);
	}
}
