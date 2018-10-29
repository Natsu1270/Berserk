using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyEnemy : MonoBehaviour {
	public GameObject boomEffect;
	private AudioSource boom;
	// Use this for initialization
	void Start () {
		boom=GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player2"){
			
			//boom.Play();
			Instantiate(boomEffect,this.transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
