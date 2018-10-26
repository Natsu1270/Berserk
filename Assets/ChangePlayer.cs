using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour {
	public GameObject vcm1;
	public GameObject vcm2;
	public GameObject playerArmed;
	// Use this for initialization
	private void OnCollisionEnter2D(Collision2D other) {
			vcm1.SetActive(false);
			vcm2.SetActive(true);
			playerArmed.SetActive(true);
		if(other.gameObject.tag=="Player"){
			Destroy(other.gameObject);
			Destroy(this.gameObject);
			

		}
	}
}
