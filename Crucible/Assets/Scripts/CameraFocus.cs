using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {

	//Script that follows the object that is being focused on.

	//Item that you want the camera to focus on
	public GameObject cameraFocus;
	public float lerpSpeed = 15.0f;

	private bool cameraIsFocused;

	// Use this for initialization
	void Start () {
		cameraIsFocused = false;
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3 (cameraFocus.transform.position.x, cameraFocus.transform.position.y, Camera.main.transform.position.z), lerpSpeed * Time.deltaTime);
	}

	public void SetFocus(GameObject gameObject) {
		cameraFocus = gameObject;
		cameraIsFocused = true;
	}

	public void UnFocus() {
		cameraFocus = null;
		cameraIsFocused = false;
	}
}
