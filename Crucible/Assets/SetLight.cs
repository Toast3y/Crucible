using UnityEngine;
using System.Collections;

public class SetLight : MonoBehaviour {

	private GameObject mainChar;
	public Sprite lightSprite;
	public Sprite darkSprite;
	public float torchDistance;

	private bool lit;

	// Use this for initialization
	void Start () {
		lit = false;
		mainChar = GameObject.FindGameObjectWithTag("Player");
		torchDistance = mainChar.GetComponent<TorchValue>().torchRange;
	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance(mainChar.transform.position, transform.position);

		if (distance < torchDistance && lit == false) {
			LightUp();
		}
		else if (distance > torchDistance && lit == true){
			GoDark();
		}
	
	}


	void LightUp() {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = lightSprite;
		lit = true;
	}

	void GoDark() {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = darkSprite;
		lit = false;
	}
}
