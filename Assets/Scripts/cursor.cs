using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursor : MonoBehaviour {
	private RipplePostProcessor ripple;
	private Image newCursor;
	private TrailRenderer trail;
	// Use this for initialization
	void Start () {
		ripple=Camera.main.GetComponent<RipplePostProcessor>();
		trail=GetComponent<TrailRenderer>();
		Cursor.visible=false;
		//DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			ripple.RippleEffect();
		}
		Vector2 pos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position=pos;
	}
}
