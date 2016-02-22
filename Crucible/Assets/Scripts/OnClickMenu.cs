using UnityEngine;
using System.Collections;

public class OnClickMenu : MonoBehaviour {

	//Detects behaviour for calling up the On Click Canvas menu in game
	public GameObject canvas;

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
				//Debug.Log("Object Hit: ", GameObject.Find(hit.collider.gameObject.name));
				canvas.SetActive(true);
				menuOpen = true;
				Camera.main.GetComponent<CameraFocus>().SetFocus(hit.collider.gameObject);
			}
		}
	}

	public void SwitchMenuOff() {
		//Disable the menu when called
		menuOpen = false;
		canvas.SetActive(false);
	}

	public bool GetMenuOpen() {
		return menuOpen;
	}
}
