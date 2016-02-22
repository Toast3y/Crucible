using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

	//Simple character movement that does not use lerping... yet

	public float lerpSpeed = 10.0f;

	private GameObject attached;
	private GameObject boardManager;
	private Vector2 newPos;
	private Vector2 oldPos;

	// Use this for initialization
	void Start () {
		attached = this.gameObject;
		newPos = attached.transform.position;
		boardManager = GameObject.FindGameObjectWithTag("Board");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("up") && Camera.main.GetComponent<OnClickMenu>().GetMenuOpen() == false) {
			Camera.main.GetComponent<CameraFocus>().SetFocus(this.gameObject);
			MoveUp();
		}
		else if (Input.GetKeyDown("down") && Camera.main.GetComponent<OnClickMenu>().GetMenuOpen() == false) {
			Camera.main.GetComponent<CameraFocus>().SetFocus(this.gameObject);
			MoveDown();
		}
		else if (Input.GetKeyDown("left") && Camera.main.GetComponent<OnClickMenu>().GetMenuOpen() == false) {
			Camera.main.GetComponent<CameraFocus>().SetFocus(this.gameObject);
			MoveLeft();
		}
		else if (Input.GetKeyDown("right") && Camera.main.GetComponent<OnClickMenu>().GetMenuOpen() == false) {
			Camera.main.GetComponent<CameraFocus>().SetFocus(this.gameObject);
			MoveRight();
		}

		attached.transform.position = Vector3.Lerp(attached.transform.position, newPos, lerpSpeed * Time.deltaTime);
	}



	void MoveUp() {
		if (boardManager.GetComponent<BoardManager>().ValidateMove((int)newPos.x, (int)newPos.y + 1) == false) {
			//Restrict movement to tiles
		}
		else {
			oldPos = newPos;
			newPos.y++;
		}
	}

	void MoveDown() {
		if (boardManager.GetComponent<BoardManager>().ValidateMove((int)newPos.x, (int)newPos.y - 1) == false) {
			//Restrict movement to tiles
		}
		else {
			oldPos = newPos;
			newPos.y--;
		}
	}

	void MoveLeft() {
		if (boardManager.GetComponent<BoardManager>().ValidateMove((int)newPos.x - 1, (int)newPos.y) == false) {
			//Restrict movement to tiles
		}
		else {
			oldPos = newPos;
			newPos.x--;
		}
	}

	void MoveRight() {
		if (boardManager.GetComponent<BoardManager>().ValidateMove((int)newPos.x + 1, (int)newPos.y) == false) {
			//Restrict movement to tiles
		}
		else {
			oldPos = newPos;
			newPos.x++;
		}
	}

	void CheckArea() {
		//Check to see if the area to be entered is a wall.

	}
}
