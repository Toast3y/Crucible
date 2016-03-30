using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {
	//Door behaviour that switches between two states: Open and Closed

	private bool isOpen;

	[Header("Door Closed Sprites")]
	public Sprite door_Closed_Dark;
	public Sprite door_Closed_Light;
	[Header("Door Open Sprites")]
	public Sprite door_Open_Dark;
	public Sprite door_Open_Light;

	private SetLight lightBehaviour;
	private Properties objectProperties;


	// Use this for initialization
	void Start () {
		isOpen = false;
		lightBehaviour = gameObject.GetComponent<SetLight>();
		objectProperties = gameObject.GetComponent<Properties>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenDoor() {
		SetIsOpen(true);
	}

	public void CloseDoor() {
		SetIsOpen(false);
	}

	public bool GetIsOpen() {
		return isOpen;
	}

	public void SetIsOpen(bool IsOpen) {
		isOpen = IsOpen;
		UpdateState(isOpen);
	}

	private void UpdateState(bool IsOpen) {
		if (IsOpen == true) {
			//Set the sprites and properties of the now open door
			objectProperties.SetIsPassable(true);
			lightBehaviour.lightSprite = door_Open_Light;
			lightBehaviour.darkSprite = door_Open_Dark;
			lightBehaviour.ForceUpdate();
		}
		else if (IsOpen == false) {
			//Set the properties to close the door
			objectProperties.SetIsPassable(false);
			lightBehaviour.lightSprite = door_Closed_Light;
			lightBehaviour.darkSprite = door_Closed_Dark;
			lightBehaviour.ForceUpdate();
		}
		else {
			//Edge case, if the door state is set to null, simply close it
			SetIsOpen(false);
		}
	}
}
