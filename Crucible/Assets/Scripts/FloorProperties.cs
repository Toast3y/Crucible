using UnityEngine;
using System.Collections;

public class FloorProperties : MonoBehaviour {
	//Script to control map triggers and behaviours for various characters.


	public bool isPassable;
	public bool isRevealed;

	// Use this for initialization
	void Start () {
		isRevealed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool GetIsPassable() {
		return isPassable;
	}

	public bool GetIsRevealed() {
		return isRevealed;
	}
}
