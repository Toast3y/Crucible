using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {

	//Script that follows the object that is being focused on.

	private GameObject camera;

	//Item that you want the camera to focus on
	public GameObject cameraFocus;
	public float lerpSpeed = 5.0f;

	private bool cameraIsFocused;

	// Use this for initialization
	void Start () {
		camera = this.gameObject;
		cameraIsFocused = false;
	}
	
	// Update is called once per frame
	void Update () {
		camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3 (cameraFocus.transform.position.x, cameraFocus.transform.position.y, camera.transform.position.z), lerpSpeed * Time.deltaTime);
	}

	public void SetFocus(GameObject gameObject) {
		cameraFocus = gameObject;
		cameraIsFocused = true;
	}
}
