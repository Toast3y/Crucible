using UnityEngine;

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

	new public GameObject FetchButtons() {

		if (gameObject.GetComponent<DoorBehaviour>().GetIsOpen() == true) {
			return closeDoor_Button;
		}
		else {
			return openDoor_Button;
		}

	}
}
