using UnityEngine;
using System.Collections;

public class SimpleCharacterController : MonoBehaviour {

	//Simple character controller to test character movement and collision
	//Uses lerping to create smooth transitions, keeps character centered by tracking last position in case of collision or unwanted movement.

	public float lerpSpeed = 3.0f;

	private GameObject attachedCharacter;
	private Vector3 currentPos;
	private Vector3 oldPos;
	private Vector3 newPos;
	private bool lerp;
	

	// Use this for initialization
	void Start () {
		attachedCharacter = this.gameObject;
		currentPos = attachedCharacter.transform.position;
		oldPos = currentPos;
		newPos = currentPos;
		lerp = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (lerp == true) {
			//if finished moving, end lerping
			/*if (currentPos == newPos) {
				lerp = false;

				//Set the current position to the new position, center the character on new position
				//attachedCharacter.transform.position = newPos;
				//SetPosition();
			}
			else */{
				//Lerp to the new coordinates given
				attachedCharacter.transform.position = Vector3.Lerp(currentPos, newPos, lerpSpeed * Time.deltaTime);
				currentPos = attachedCharacter.transform.position;
			}
		}



		if (Input.GetKeyDown("up") && lerp == false) {
			MoveUp();
		}
		else if (Input.GetKeyDown("down") && lerp == false) {
			MoveDown();
		}
		else if (Input.GetKeyDown("left") && lerp == false) {
			MoveLeft();
		}
		else if (Input.GetKeyDown("right") && lerp == false) {
			MoveRight();
		}
		
	}

	//Set the position of the character again in case of character misalignment, or when colliding with a wall or invalid move, according to the last known coordinates.
	public void ResetPosition() {
		newPos = currentPos;
		lerp = true;
	}

	//Set the new position of the character as the current position
	/*void SetPosition() {
		currentPos = newPos;
	}*/


	void MoveUp() {
		oldPos = currentPos;
		newPos = new Vector3 (currentPos.x, currentPos.y++, currentPos.z);
		lerp = true;
	}

	void MoveDown() {
		oldPos = currentPos;
		newPos = new Vector3 (currentPos.x, currentPos.y--, currentPos.z);
		lerp = true;
	}

	void MoveLeft() {
		oldPos = currentPos;
		newPos = new Vector3 (currentPos.x--, currentPos.y, currentPos.z);
		lerp = true;
	}

	void MoveRight() {
		oldPos = currentPos;
		newPos = new Vector3 (currentPos.x++, currentPos.y, currentPos.z);
		lerp = true;
	}
}
