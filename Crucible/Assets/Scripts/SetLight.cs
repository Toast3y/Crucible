using UnityEngine;
using System.Collections;

public class SetLight : MonoBehaviour {

	private GameObject mainChar;
	public Sprite lightSprite;
	public Sprite darkSprite;
	public Sprite unrevealedSprite;
	public float torchDistance;

	private bool lit;

	// Use this for initialization
	void Start () {
		lit = false;
		mainChar = GameObject.FindGameObjectWithTag("Player");
		torchDistance = mainChar.GetComponent<TorchValue>().torchRange;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = unrevealedSprite;
	}
	
	// Update is called once per frame
	void Update () {
		try {
			float distance = Vector3.Distance(mainChar.transform.position, transform.position);

			if (distance < torchDistance && lit == false) {
				LightUp();
			}
			else if (distance > torchDistance && lit == true) {
				GoDark();
			}
		}
		catch {
			mainChar = GameObject.FindGameObjectWithTag("Player");
		}
	}


	void LightUp() {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = lightSprite;
		this.gameObject.GetComponent<Properties>().SetIsRevealed(true);
		lit = true;
	}

	void GoDark() {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = darkSprite;
		lit = false;
	}
}
