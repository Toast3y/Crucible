using UnityEngine;
using System.Collections;

public class Properties : MonoBehaviour {
	//Script to control map triggers and behaviours for various characters.


	public bool isPassable;
	public bool isRevealed;

	// Use this for initialization
	void Start() {
		isRevealed = false;
	}

	// Update is called once per frame
	void Update() {

	}



	public bool GetIsPassable() {
		return isPassable;
	}

	public void SetIsPassable(bool IsPassable) {
		isPassable = IsPassable;
	}



	public bool GetIsRevealed() {
		return isRevealed;
	}

	public void SetIsRevealed(bool IsRevealed) {
		isRevealed = IsRevealed;
	}

}