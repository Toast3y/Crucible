using UnityEngine;
using System.Collections;

public class CameraBehaviour2D : MonoBehaviour {

	//***SCRIPT FOR USE WITHIN WINDOWS, MACINTOSH AND LINUX SYSTEMS***
	//***FOR APPROPRIATE CONTROLLERS FOR ANDROID, USE "CameraBehaviour2D_Android"***


	/*A 2D camera controller that uses the mouse and mousewheel to navigate the world.
	 *Uses an upper bound, the top left of the map, and a lower bound, the bottom right, to restrict camera movement within the game level.
	 *upperHeightBound and lowerHeightBound are used to control the camera zoom level.
	 */



	//upperBound is the top left corner of the map.
	//lowerBound is the bottom right corner of the map.
	public Vector2 upperBound;
	public Vector2 lowerBound;



	//upperHeightBound is the furthest distance away possible.
	//lowerHeightBound is the closest distance possible.
	public float upperHeightBound;
	public float lowerHeightBound;

	// Use this for initialization
	void Start () {
		//Use this space on initialization to receive any specific camera boundary requirements from a Game Manager or Game World object.
	}
	
	// Update is called once per frame
	void Update () {

		


		
		/*Height camera controller to determine the zoom level of the camera.
		 *
		 *If the 
		 */
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			//Moves the camera further away.
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			//Moves the camera closer.
		}

	}
}
