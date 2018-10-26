using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charSound : MonoBehaviour {
	public GameObject charac;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
	}
	public void playChar(){
		audioSource=charac.GetComponent<AudioSource>();
		audioSource.Play();
		audioSource.loop=false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
