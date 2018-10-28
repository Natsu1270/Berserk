using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyVoid : MonoBehaviour {
	public GameObject theVoid;
	// Use this for initialization
	void Start () {
		Destroy(theVoid);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
