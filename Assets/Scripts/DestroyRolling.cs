using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRolling : MonoBehaviour {

	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("optacle")){
			Destroy(other.gameObject);
		}
	}
}
