using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public static int MAP_WIDTH = 50;
	public static int MAP_HEIGHT = 50;

	public static int MAX_ROOMS = 25;

	

	public GameObject[,] map = new GameObject[MAP_WIDTH, MAP_HEIGHT];
	public Assets.Scripts.Room[] rooms = new Assets.Scripts.Room[MAX_ROOMS];
	
	public List<GameObject> wallTiles = new List<GameObject>();
	public List<GameObject> characterList = new List<GameObject>();
	public List<GameObject> objectList = new List<GameObject>();

	private MapScript_NAME mapScript;

	// Use this for initialization
	void Start () {
		mapScript = gameObject.GetComponent<MapScript_NAME>();
		mapScript.GenerateMap(MAP_WIDTH, MAP_HEIGHT, MAX_ROOMS);
		mapScript.GenerateWalls(MAP_WIDTH, MAP_HEIGHT);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Check if the passed in move is valid
	public bool ValidateMove(int x, int y) {

		//If it falls outside the map borders
		if (x < 0 || y < 0 || x >= MAP_WIDTH || y >= MAP_HEIGHT) {
			return false;
		}
		//If there's no tile to stand on
		else if (map[x, y] == null) {
			return false;
		}
		//If there's an impassable object on the tile
		else if (PassableCheck(x, y) > 0) {
			return false;
		}
		//The way is clear and you can pass
		else {
			return true;
		}
	}

	//Return a list of all objects on a tile, and see if the property isPassable is true.
	public int PassableCheck(int x, int y) {
		int count = 0;

		//Cast a line on the coordinates given
		var collisions = Physics2D.LinecastAll(new Vector2(x - 0.25f, y - 0.25f), new Vector2(x + 0.25f, y + 0.25f));

		foreach (var collision in collisions) {
			if (collision.collider.gameObject.GetComponent<Properties>().GetIsPassable() == false) {
				count++;
			}
		}

		return count;
	}
}