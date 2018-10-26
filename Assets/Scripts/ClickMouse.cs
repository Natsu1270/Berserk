using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMouse : MonoBehaviour {
	private AudioSource click;
	// AudioSource charSound;
	// GameObject character;
	// Use this for initialization
	void Start () {
		//character=GameObject.FindGameObjectWithTag("char");
		DontDestroyOnLoad(gameObject);
		click=gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			
			click.Play();
		}
		
	}
}
