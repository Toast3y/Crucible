using UnityEngine;
using System.Collections;

public class MapScript_NAME : MonoBehaviour {


	//Template class used to create procedural map scripting objects
	public int minRoomWidth = 3;
	public int maxRoomWidth = 8;
	public int minRoomHeight = 3;
	public int maxRoomHeight = 8;

	public GameObject character;

	//Reference all objects that will be created during runtime, using prefabs in Unity
	[Header("Floor Objects")]
	public GameObject floor1;
	[Header("Wall Objects")]
	public GameObject wall_Left;
	public GameObject wall_Right;
	public GameObject wall_Down;
	public GameObject wall_Face;
	//Corner pieces used to mark the inside corners of rooms
	[Header("Corner Objects")]
	public GameObject corner_InsideBottomLeft;
	public GameObject corner_InsideBottomRight;
	public GameObject corner_InsideTopLeft;
	public GameObject corner_InsideTopRight;



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

		for (int i = 0; i < MAX_ROOMS; i++) {

			//Determine the width and height of the rooms
			int roomWidth = Random.Range(minRoomWidth, maxRoomWidth);
			int roomHeight = Random.Range(minRoomHeight, maxRoomHeight);

			//Determine the position of the rooms top left corner
			//Keeps the room inside the borders by reducing the search space by the room size minus one
			//This prevents Array out of bounds errors
			Vector2 roomPos = new Vector2(Random.Range(0, mapWidth - roomWidth - 1), Random.Range(0, mapHeight - roomHeight - 1));

			//Add the room object to the board manager
			var newRoom = new Assets.Scripts.Room(roomPos, roomWidth, roomHeight);
			gameObject.GetComponent<BoardManager>().rooms[i] = newRoom;

			//If this is the first room spawned, move the character to the start


			//create a room at the location chosen
			for (int x = 0; x < roomWidth; x++) {
				for (int y = 0; y < roomHeight; y++) {
					if (gameObject.GetComponent<BoardManager>().map[x, y] != null) {
						//Do not create an object where a tile already exists
					}
					else {
						var newfloor = (GameObject)GameObject.Instantiate(floor1, new Vector3(x + roomPos.x, y + roomPos.y, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().map[(int)(x + roomPos.x), (int)(y + roomPos.y)] = newfloor;
					}
				}
			}


			//Generate a corridor from the last room to the new one
			if (i == 0) {
				var protagonist = (GameObject)GameObject.Instantiate(character, (Vector3)newRoom.GetCentre(), Quaternion.identity);
				Camera.main.GetComponent<CameraFocus>().SetFocus(protagonist);
			}
			else {
				switch(Random.Range(0, 2)){
					case 0:
						//Create a horizontal corridor first
						CreateHorizontalTunnel((int) gameObject.GetComponent<BoardManager>().rooms[i-1].GetCentre().x, (int)newRoom.GetCentre().x, (int)gameObject.GetComponent<BoardManager>().rooms[i - 1].GetCentre().y);
						CreateVerticalTunnel((int)gameObject.GetComponent<BoardManager>().rooms[i - 1].GetCentre().y, (int)newRoom.GetCentre().y, (int)newRoom.GetCentre().x);
						break;
					case 1:
						CreateVerticalTunnel((int)gameObject.GetComponent<BoardManager>().rooms[i - 1].GetCentre().y, (int)newRoom.GetCentre().y, (int)gameObject.GetComponent<BoardManager>().rooms[i - 1].GetCentre().x);
						CreateHorizontalTunnel((int)gameObject.GetComponent<BoardManager>().rooms[i - 1].GetCentre().x, (int)newRoom.GetCentre().x, (int)newRoom.GetCentre().y);
						break;
				}
			}

		}
		
	}


	//Generate walls for the newly created template
	public void GenerateWalls(int mapWidth, int mapHeight) {
		//Iterate through each tile to place a wall near it
		for (int x = 0; x < mapWidth; x++) {
			for (int y = 0; y < mapHeight; y++) {

				//Check if the square has a map tile with nothing above it.
				if (gameObject.GetComponent<BoardManager>().map[x, y] != null) {


					//Create wall face
					if(y + 1 == mapHeight){
						//Automatically create the tile, because the array check would cause an out of bounds error
						//The wall should be created anyway, so this shouldn't be a problem
						var newWall = (GameObject)GameObject.Instantiate(wall_Face, new Vector3(x, y + 1, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}
					else if (gameObject.GetComponent<BoardManager>().map[x, y + 1] == null) {
						var newWall = (GameObject)GameObject.Instantiate(wall_Face, new Vector3(x, y + 1, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}


					
					//Left Wall
					if(x - 1 == -1){
						//Automatically create the tile, because the array check would cause an out of bounds error
						//The wall should be created anyway, so this shouldn't be a problem
						var newWall = (GameObject)GameObject.Instantiate(wall_Left, new Vector3(x - 1, y, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}
					else if (gameObject.GetComponent<BoardManager>().map[x - 1, y] == null) {
						var newWall = (GameObject)GameObject.Instantiate(wall_Left, new Vector3(x - 1, y, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}



					//Right Wall
					if (x + 1 == mapWidth) {
						var newWall = (GameObject)GameObject.Instantiate(wall_Right, new Vector3(x + 1, y, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}
					else if (gameObject.GetComponent<BoardManager>().map[x + 1, y] == null) {
						var newWall = (GameObject)GameObject.Instantiate(wall_Right, new Vector3(x + 1, y, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}
					


					//Bottom Wall
					if (y - 1 == -1) {
						var newWall = (GameObject)GameObject.Instantiate(wall_Down, new Vector3(x, y-1, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}
					else if (gameObject.GetComponent<BoardManager>().map[x, y - 1] == null) {
						var newWall = (GameObject)GameObject.Instantiate(wall_Down, new Vector3(x, y-1, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}



					//Corner cases

					//Bottom Left
					/*
					if (x - 1 == -1 && y - 1 == -1) {
						var newWall = (GameObject)GameObject.Instantiate(corner_InsideBottomLeft, new Vector3(x - 1, y - 1, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}
					else if (gameObject.GetComponent<BoardManager>().map[x - 1, y - 1] == null) {
						var newWall = (GameObject)GameObject.Instantiate(corner_InsideBottomLeft, new Vector3(x - 1, y - 1, 0), Quaternion.identity);
						gameObject.GetComponent<BoardManager>().wallTiles.Add(newWall);
					}*/

				}


			}
		}
	}


	//Creates a horizontal tunnel between two x coordinates
	private void CreateHorizontalTunnel(int x1, int x2, int y) {

		int width = (Mathf.Max(x1, x2) - Mathf.Min(x1, x2));

		for (int x = 0; x <= width; x++) {
			//If the container tile already has a tile in it, don't place a new one.
			if (gameObject.GetComponent<BoardManager>().map[x + Mathf.Min(x1, x2), y] != null) {
				//Do nothing, as a tile already exists
			}
			else {
				//Create a new tile at that position
				var newfloor = (GameObject)GameObject.Instantiate(floor1, new Vector3(x + Mathf.Min(x1, x2), y, 0), Quaternion.identity);
				gameObject.GetComponent<BoardManager>().map[(int)(x + Mathf.Min(x1, x2)), (int)(y)] = newfloor;
			}
		}

	}

	//Creates a vertical tunnel between two y coordinates
	private void CreateVerticalTunnel(int y1, int y2, int x) {

		int height = Mathf.Max(y1, y2) - Mathf.Min(y1, y2);

		for (int y = 0; y <= height; y++) {
			//If the container has something in it, don't create a tile
			if (gameObject.GetComponent<BoardManager>().map[x, y + Mathf.Min(y1, y2)] != null) {
				//Do nothing, as a tile already exists
			}
			else {
				var newfloor = (GameObject)GameObject.Instantiate(floor1, new Vector3(x, y + Mathf.Min(y1, y2), 0), Quaternion.identity);
				gameObject.GetComponent<BoardManager>().map[(int)(x), (int)(y + Mathf.Min(y1, y2))] = newfloor;
			}
		}

	}
}
