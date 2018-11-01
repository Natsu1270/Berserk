using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartSpw : MonoBehaviour {
	public GameObject heart;
	private bool once=true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.childCount==1 && once==true){
			Instantiate(heart,transform.GetChild(0).transform.position,Quaternion.identity);
			once=false;
		}
	}
}
