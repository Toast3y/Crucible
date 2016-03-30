using UnityEngine;
using System.Collections;

public abstract class MapScript : MonoBehaviour, IGenerateMap{

	//Class from which all level generation classes derive. MapScripts only requires that GenerateMap be fulfilled.


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public abstract void GenerateMap(int mapWidth, int mapHeight, int maxRooms);
}
