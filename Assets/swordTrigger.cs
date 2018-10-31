using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordTrigger : MonoBehaviour {
	public GameObject[] swords;
	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player2")){
			foreach(GameObject s in swords){
				s.SetActive(true);
			}
		}
	}
}
