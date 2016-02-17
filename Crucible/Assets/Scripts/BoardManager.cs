using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public int MAP_WIDTH = 100;
	public int MAP_HEIGHT = 60;

	

	public List<GameObject> map = new List<GameObject>();
	
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