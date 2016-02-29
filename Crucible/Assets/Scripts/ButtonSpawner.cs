using UnityEngine;
using System.Collections.Generic;

public class ButtonSpawner : MonoBehaviour {
	//Component that passes back buttons to the UserInterface_Canvas Object
	//Buttons should be spawned from prefabs in Unity Editor. Simply drag and drop them into the list.

	public List<GameObject> buttons = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public List<GameObject> FetchButtons() {
		return buttons;
	}
}
