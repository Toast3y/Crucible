using UnityEngine;
using System.Collections;

public class OnClickMenu : MonoBehaviour {

	//Detects behaviour for calling up the On Click Canvas menu in game
	public GameObject canvas;
	public float zoomThreshold;

	private bool menuOpen;

	// Use this for initialization
	void Start () {
		menuOpen = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) && menuOpen == false) {
			//Cast a ray from the mouse down to the game world.
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			if (hit.collider != null && hit.collider.gameObject.GetComponent<Properties>().isRevealed == true && menuOpen == false) {
				Camera.main.GetComponent<CameraFocus>().SetFocus(hit.collider.gameObject);

				//If the camera isn't close enough, zoom to the appropriate level
				if (gameObject.GetComponent<CameraBehaviour2D>().zoomLevel > zoomThreshold + 0.1f) {
					gameObject.GetComponent<CameraBehaviour2D>().zoomLevel = zoomThreshold;
				}
				else {
					//If sure, zoom to the correct level and open the menu
					gameObject.GetComponent<CameraBehaviour2D>().zoomLevel = zoomThreshold;
					canvas.SetActive(true);
					canvas.GetComponent<GenerateMenu>().AssembleMenu((int)hit.collider.gameObject.transform.position.x, (int)hit.collider.gameObject.transform.position.y);
					menuOpen = true;
				}
				
				
			}
		}
	}

	public void SwitchMenuOff() {
		//Disable the menu when called
		menuOpen = false;
		canvas.GetComponent<GenerateMenu>().DisassembleMenu();
		canvas.SetActive(false);
	}

	public bool GetMenuOpen() {
		return menuOpen;
	}
}
