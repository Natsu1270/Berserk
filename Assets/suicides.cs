using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suicides : MonoBehaviour {
	public Transform resetPos;
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player2")){
			other.transform.position=resetPos.position;
		}
	}
}
