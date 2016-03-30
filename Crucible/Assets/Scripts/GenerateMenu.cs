using UnityEngine;
using System.Collections.Generic;

public class GenerateMenu : MonoBehaviour {

	public BoardManager boardManager;

	public Vector3 scaler = new Vector3();

	private List<GameObject> buttons = new List<GameObject>();

	[Header("Canvas Co-ordinates")]
	public Vector2 canvasPosition1;
	public Vector2 canvasPosition2;
	public Vector2 canvasPosition3;
	public Vector2 canvasPosition4;
	public Vector2 canvasPosition5;
	public Vector2 canvasPosition6;

	private List<Vector2> canvasPositions = new List<Vector2>();

	// Use this for initialization
	void Start () {
		canvasPositions.Add(canvasPosition1);
		canvasPositions.Add(canvasPosition2);
		canvasPositions.Add(canvasPosition3);
		canvasPositions.Add(canvasPosition4);
		canvasPositions.Add(canvasPosition5);
		canvasPositions.Add(canvasPosition6);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Fetch all game objects in the square and find the buttonspawner component
	public void AssembleMenu(int x, int y) {

		var buttonObjects = boardManager.RetrieveObjects(x, y);

		buttons = new List<GameObject>();

		foreach (var objectFound in buttonObjects) {

			//Act only if a Buttonspawner component is found.
			if (objectFound.GetComponent<ButtonSpawner>() != null) {
				var buttonList = objectFound.GetComponent<ButtonSpawner>().FetchButtons();

				foreach (var button in buttonList) {
					var newbutton = Instantiate(button);
					newbutton.GetComponent<ObjectLink>().SetLinkedObject(objectFound);
					newbutton.transform.SetParent(gameObject.transform, false);
					buttons.Add(newbutton);
				}
			}

		}

		DetermineLayout();
	}


	//Assign the layout of the menu to each button.
	public void DetermineLayout() {
		//Determine the number of buttons and assign a position to each one
		//Switch statements in C# do not cascade naturally. You have to use a goto to go to each next statement.
		//

		switch (buttons.Count) {
			case 0:
				break;
			case 6:
				
                break;
			case 5:

			case 4:

			case 3:

			case 2:

			case 1:

				break;
		};
	}




	//Disassemble the menu on menu close
	public void DisassembleMenu() {
		foreach (var oldbutton in buttons) {
			Destroy(oldbutton);
		}
	}
	

}
