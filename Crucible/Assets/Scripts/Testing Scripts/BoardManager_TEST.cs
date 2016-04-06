using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager_TEST : MonoBehaviour {

	public static int MAP_WIDTH = 50;
	public static int MAP_HEIGHT = 50;

	public static int MAX_ROOMS = 10;



	public GameObject[,] map = new GameObject[MAP_WIDTH, MAP_HEIGHT];
	public Assets.Scripts.Room[] rooms = new Assets.Scripts.Room[MAX_ROOMS];

	public List<GameObject> wallTiles = new List<GameObject>();
	public List<GameObject> characterList = new List<GameObject>();
	public List<GameObject> objectList = new List<GameObject>();

	private MapScript mapScript;

	// Use this for initialization
	void Start() {
		mapScript = gameObject.GetComponent<MapScript>();
		mapScript.GenerateMap(MAP_WIDTH, MAP_HEIGHT, MAX_ROOMS);
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown("space")) {
			StartCoroutine(MakeMap());
		}
	}


	IEnumerator MakeMap() {
		mapScript.GenerateMap(MAP_WIDTH, MAP_HEIGHT, MAX_ROOMS);
		yield return new WaitForSeconds(20);
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


	//Find a list of all objects on a tile, and see if the property isPassable is true.
	//Returns 0 if passable, greaten than if not.
	public int PassableCheck(int x, int y) {
		int count = 0;

		//Cast a line on the coordinates given
		var collisions = RetrieveObjects(x, y);

		foreach (var collision in collisions) {
			if (collision.GetComponent<Properties>().GetIsPassable() == false) {
				count++;
			}
		}

		return count;
	}


	//Returns a list of all game objects to then be filtered using another behaviour.
	//This finds all objects in a square with NO FILTERING OF TAGS. If you need to find specific tagged objects, use or create another public method.
	public List<GameObject> RetrieveObjects(int x, int y) {

		List<GameObject> objects = new List<GameObject>();

		var collisions = Physics2D.LinecastAll(new Vector2(x - 0.25f, y - 0.25f), new Vector2(x + 0.25f, y + 0.25f));

		foreach (var collision in collisions) {
			objects.Add(collision.collider.gameObject);
		}


		return objects;
	}


	//Finds the buttonspawner objects in the square given
	public virtual List<GameObject> RetrieveButtons(int x, int y) {

		List<GameObject> buttons = new List<GameObject>();

		var buttonObjects = RetrieveObjects(x, y);

		foreach (var objectFound in buttonObjects) {

			//Act only if a Buttonspawner component is found.
			if (objectFound.GetComponent<ButtonSpawner>() != null) {
				var buttonList = objectFound.GetComponent<ButtonSpawner>().FetchButtons();

				foreach (var button in buttonList) {
					buttons.Add(button);
				}
			}

		}

		return buttons;
	}
}
