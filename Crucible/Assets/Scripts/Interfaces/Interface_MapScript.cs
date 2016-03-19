using UnityEngine;
using System.Collections;

public interface IGenerateMap{
	void GenerateMap(int mapWidth, int mapHeight, int maxRooms);
}

public interface IGenerateWalls {
	void GenerateWalls(int mapWidth, int mapHeight);
}