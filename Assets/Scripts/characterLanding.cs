using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterLanding : MonoBehaviour {
	public AudioClip landEffect;
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player"){
			if(other.gameObject.GetComponent<Animator>().GetBool("isJumping")==true){
				AudioSource.PlayClipAtPoint(landEffect,other.gameObject.transform.position);
			}
			other.gameObject.GetComponent<Animator>().SetBool("isJumping",false);
			
		}
	}
}
