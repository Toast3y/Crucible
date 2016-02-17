using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public static int MAP_WIDTH = 100;
	public static int MAP_HEIGHT = 60;

	

	public GameObject[,] map = new GameObject[MAP_WIDTH, MAP_HEIGHT];
	
	public List<GameObject> wallTiles = new List<GameObject>();
	public List<GameObject> characterList = new List<GameObject>();

	private MapScript_NAME mapScript;

	// Use this for initialization
	void Start () {
		mapScript = gameObject.GetComponent<MapScript_NAME>();
		mapScript.GenerateMap(MAP_WIDTH, MAP_HEIGHT);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}