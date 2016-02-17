using UnityEngine;
using System.Collections;

public class MapScript_NAME : MonoBehaviour {
	//Template class used to create procedural map scripting objects

	//Reference all objects that will be created during runtime, using prefabs in Unity
	[Header("Floor Objects")]
	public GameObject floor1;
	[Header("Wall Objects")]
	private GameObject wall_Left;
	private GameObject wall_Right;
	private GameObject wall_Up;
	private GameObject wall_Down;
	private GameObject wall_Face;
	//Corner pieces used to mark the inside corners of rooms
	[Header("Inside Corner Objects")]
	private GameObject corner_InsideTopLeft;
	private GameObject corner_InsideTopRight;
	private GameObject corner_InsideBottomLeft;
	private GameObject corner_InsideBottomRight;

	//Corner pieces used to make the outside corners adjoining corridors for rooms
	/*private GameObject corner_OutsideTopLeft;
	private GameObject corner_OutsideTopRight;
	private GameObject corner_OutsideBottomLeft;
	private GameObject corner_OutsideBottomRight;*/



	// Use this for initialization
	void Start() {
		/*
		//Use this to initialize all GameObject references in code
		//Floor prefabs
		floor1 = (GameObject)Resources.Load("Floor1_Dark");

		//Wall prefabs
		wall_Left = (GameObject)Resources.Load("Wall_LeftFace");
		wall_Right = (GameObject)Resources.Load("Wall_RightFace");
		wall_Up = (GameObject)Resources.Load("Wall_TopFace");
		wall_Down = (GameObject)Resources.Load("Wall_BottomFace");
		wall_Face = (GameObject)Resources.Load("WallFace_Dark");

		//Inside Corner prefabs
		corner_InsideTopLeft = (GameObject)Resources.Load("Wall_Corner_TopLeft");
		corner_InsideTopRight = (GameObject)Resources.Load("Wall_Corner_TopRight");
		corner_InsideBottomLeft = (GameObject)Resources.Load("Wall_Corner_BottomLeft");
		corner_InsideBottomRight = (GameObject)Resources.Load("Wall_Corner_BottomRight");

		//Outside Corner prefabs
		*/
	}

	// Update is called once per frame
	void Update() {

	}

	public void GenerateMap(int mapWidth, int mapHeight) {
		//Generate the map and all objects as required by the board manager


		//Create a simple room, that's the size of the map
		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {
				var newfloor = (GameObject) GameObject.Instantiate(floor1, new Vector3(x, y, 0), Quaternion.identity);
				gameObject.GetComponent<BoardManager>().map[x, y] = newfloor;
			}
		}
	}
}
