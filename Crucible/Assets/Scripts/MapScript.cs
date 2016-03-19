using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour, IGenerateMap{

	//Class from which all level generation classes derive. MapScripts only requires that GenerateMap be fulfilled.


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void GenerateMap(int mapWidth, int mapHeight, int maxRooms) {
		//This method is to be overwritten by derived classes.
		//It does not need to call the base method.
		
	}
}
