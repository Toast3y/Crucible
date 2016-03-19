using UnityEngine;
using System.Collections.Generic;

public class ButtonSpawner_Door : ButtonSpawner {
	//ButtonSpawner Edited to return one of two buttons based on a host objects given state.

	public GameObject openDoor_Button;
	public GameObject closeDoor_Button;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public override List<GameObject> FetchButtons() {

		List<GameObject> buttons = new List<GameObject>();

		if (gameObject.GetComponent<DoorBehaviour>().GetIsOpen() == true) {

			buttons.Add(closeDoor_Button);
			return buttons;
		}
		else {
			buttons.Add(openDoor_Button);
			return buttons;
		}

	}
}
