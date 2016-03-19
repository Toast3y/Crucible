using UnityEngine;
using System.Collections.Generic;

public class GenerateMenu : MonoBehaviour {

	public BoardManager boardManager;

	private List<GameObject> buttons = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Fetch all game objects in the square and find the buttonspawner component
	public void AssembleMenu(int x, int y) {

		var tempbuttons = boardManager.RetrieveButtons(x, y);

	}


	//Pick all the buttons from the lists retrieved.


	//Disassemble the menu on menu close
	public void DisassembleMenu() {

	}


	//Assign the layout of the menu to each button.
	public void DetermineLayout() {

	}

}
