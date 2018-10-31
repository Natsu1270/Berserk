using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour {
	public AudioClip[] lvMusicArr;
	public AudioSource music;
	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	void Start () {
		music=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded(int lvIndex){
		music.clip=lvMusicArr[lvIndex];
		music.loop=true;
		music.Play();
	}


}
