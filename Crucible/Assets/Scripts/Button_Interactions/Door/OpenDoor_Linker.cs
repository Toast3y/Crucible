using UnityEngine;
using System.Collections;

public class OpenDoor_Linker : ObjectLink {

	//Object that interacts with the linked object using Canvas buttons.
	//This object opens doors.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void SetLinkedObject(GameObject linkedObject) {
		LinkedObject = linkedObject;
	}

	public override void ObjectInteract() {
		LinkedObject.GetComponent<DoorBehaviour>().OpenDoor();
		Camera.main.GetComponent<OnClickMenu>().SwitchMenuOff();
	}
}
