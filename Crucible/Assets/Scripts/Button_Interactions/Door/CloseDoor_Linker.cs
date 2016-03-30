using UnityEngine;
using System.Collections;
using System;

public class CloseDoor_Linker : ObjectLink {

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
		LinkedObject.GetComponent<DoorBehaviour>().CloseDoor();
		Camera.main.GetComponent<OnClickMenu>().SwitchMenuOff();
	}
}
