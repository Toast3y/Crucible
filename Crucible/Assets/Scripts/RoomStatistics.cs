using UnityEngine;
using System.Collections;

public class RoomStatistics : MonoBehaviour {

	//Determine the position and width of a given room.

	public int minWidth = 3;
	public int maxWidth = 8;
	public int minHeight = 3;
	public int maxHeight = 8;
	

	private int width, height;
	private Vector2 startPosition;
	private Vector2 endPosition;

	// Use this for initialization
	void Start () {
		startPosition = new Vector2 (transform.position.x, transform.position.y);

		width = Random.Range(minWidth, maxWidth);
		height = Random.Range(maxWidth, maxHeight);

		endPosition = new Vector2(startPosition.x + width, startPosition.y + height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector2 GetEndPosition() {
		return endPosition;
	}
}
