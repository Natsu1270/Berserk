using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour {
	private checkPointMana ckm;
	void Start(){
		ckm=GameObject.FindGameObjectWithTag("ckm").GetComponent<checkPointMana>();
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player2")||other.CompareTag("Player")){
			ckm.lastcheckpoint=other.transform.position;
		}
	}
}
