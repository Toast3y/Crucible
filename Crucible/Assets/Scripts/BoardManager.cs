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

	public bool ValidateMove(int x, int y) {
		if (map[x, y] == null) {
			return false;
		}
		else {
			if (map[x, y].GetComponent<Properties>().isPassable == true) {
				return true;
			}
			else {
				return false;
			}
		}
	}
}