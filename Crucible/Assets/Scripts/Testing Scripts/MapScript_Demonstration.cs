using UnityEngine;
using System.Collections;
using System.Timers;
using System;

public class MapScript_Demonstration : MapScript {

	public GameObject floor1;

	//Template class used to create procedural map scripting objects
	public int minRoomWidth = 3;
	public int maxRoomWidth = 8;
	public int minRoomHeight = 3;
	public int maxRoomHeight = 8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void WaitFrames() {

	}



	//Show the construction of each block and corridor over time.
	public override void GenerateMap(int mapWidth, int mapHeight, int maxRooms) {
		//Generate the map and all objects as required by the board manager

		for (int i = 0; i < maxRooms; i++) {

			//Determine the width and height of the rooms
			int roomWidth = UnityEngine.Random.Range(minRoomWidth, maxRoomWidth);
			int roomHeight = UnityEngine.Random.Range(minRoomHeight, maxRoomHeight);

			//Determine the position of the rooms top left corner
			//Keeps the room inside the borders by reducing the search space by the room size minus one
			//This prevents Array out of bounds errors
			Vector2 roomPos = new Vector2(UnityEngine.Random.Range(0, mapWidth - roomWidth - 1), UnityEngine.Random.Range(0, mapHeight - roomHeight - 1));

			//Add the room object to the board manager
			var newRoom = new Assets.Scripts.Room(roomPos, roomWidth, roomHeight);
			gameObject.GetComponent<BoardManager>().rooms[i] = newRoom;


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
				
			}
			else {
				switch (UnityEngine.Random.Range(0, 2)) {
					case 0:
						//Create a horizontal corridor first
						CreateHorizontalTunnel((int)gameObject.GetComponent<BoardManager>().rooms[i - 1].GetCentre().x, (int)newRoom.GetCentre().x, (int)gameObject.GetComponent<BoardManager>().rooms[i - 1].GetCentre().y);
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





	//Creates a horizontal tunnel between two x coordinates
	private void CreateHorizontalTunnel(int x1, int x2, int y) {

		int width = (Mathf.Max(x1, x2) - Mathf.Min(x1, x2));

		for (int x = 0; x <= width; x++) {
			//If the container tile already has a tile in it, don't place a new one.
			if (gameObject.GetComponent<BoardManager>().map[x + Mathf.Min(x1, x2), y] != null) {
				//Do nothing, as a tile already exists
				//Trigger a flag to spawn a new door
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
