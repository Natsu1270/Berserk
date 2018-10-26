using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursor : MonoBehaviour {
	private Image newCursor;
	private TrailRenderer trail;
	// Use this for initialization
	void Start () {
		trail=GetComponent<TrailRenderer>();
		Cursor.visible=false;
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			trail.startColor=Color.cyan;
		}
		Vector2 pos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position=pos;
	}
}
