using UnityEngine;
using System.Collections;

public class MapScript_NAME : MonoBehaviour {
	//Template class used to create procedural map scripting objects
	public int numRooms = 5;
	public int minRoomWidth = 3;
	public int maxRoomWidth = 8;
	public int minRoomHeight = 3;
	public int maxRoomHeight = 8;

	//Reference all objects that will be created during runtime, using prefabs in Unity
	[Header("Floor Objects")]
	public GameObject floor1;
	[Header("Wall Objects")]
	public GameObject wall_Left;
	public GameObject wall_Right;
	public GameObject wall_Down;
	public GameObject wall_Face;
	//Corner pieces used to mark the inside corners of rooms
	[Header("Inside Corner Objects")]
	public GameObject corner_InsideBottomLeft;
	public GameObject corner_InsideBottomRight;
	[Header("Outside Corner Objects")]
	public GameObject corner_OutsideTopLeft;
	public GameObject corner_OutsideTopRight;
	public GameObject corner_OutsideBottomLeft;
	public GameObject corner_OutsideBottomRight;

	//Corner pieces used to make the outside corners adjoining corridors for rooms
	/*public GameObject corner_OutsideTopLeft;
	public GameObject corner_OutsideTopRight;
	public GameObject corner_OutsideBottomLeft;
	public GameObject corner_OutsideBottomRight;*/



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

	public void GenerateMap(int mapWidth, int mapHeight, int MAX_ROOMS) {
		//Generate the map and all objects as required by the board manager

		for (int i = 0; i < numRooms; i++) {

			//Determine the width and height of the rooms
			int roomWidth = Random.Range(minRoomWidth, maxRoomWidth);
			int roomHeight = Random.Range(minRoomHeight, maxRoomHeight);

			//Determine the position of the rooms top left corner
			//Keeps the room inside the borders by reducing the search space by the room size minus one
			//This prevents Array out of bounds errors
			Vector2 roomPos = new Vector2(Random.Range(0, mapWidth - roomWidth - 1), Random.Range(0, mapHeight - roomHeight - 1));

			//create a room at the location chosen
			for (int x = 0; x < roomWidth; x++) {
				for (int y = 0; y < roomHeight; y++) {
					var newfloor = (GameObject)GameObject.Instantiate(floor1, new Vector3(x + roomPos.x, y + roomPos.y, 0), Quaternion.identity);
					gameObject.GetComponent<BoardManager>().map[(int)(x + roomPos.x), (int)(y + roomPos.y)] = newfloor;
				}
			}

		}
		//Create a simple room, that's the size of the map
		/*	for (int x = 0; x < mapWidth; x++) {
				for (int y = 0; y < mapHeight; y++) {
					var newfloor = (GameObject) GameObject.Instantiate(floor1, new Vector3(x, y, 0), Quaternion.identity);
					gameObject.GetComponent<BoardManager>().map[x, y] = newfloor;
				}
			}*/
	}
}
