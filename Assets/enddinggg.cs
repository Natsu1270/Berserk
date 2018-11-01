using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enddinggg : MonoBehaviour {
	public GameObject edeff;
	private AudioSource s;
	// Use this for initialization
	void Start () {
		s=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player2"){
			s.Play();
			Instantiate(edeff,transform.position,Quaternion.identity);
		}
	}
}
