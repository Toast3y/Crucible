using UnityEngine;
using System.Collections;

public abstract class ObjectLink : MonoBehaviour, IObjectInteract {

	public GameObject LinkedObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public abstract void SetLinkedObject(GameObject linkedObject);

	public abstract void ObjectInteract();
}
