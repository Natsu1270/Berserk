using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {
private AudioSource pop;
	// Use this for initialization
	void Start () {
		pop=gameObject.GetComponent<AudioSource>();
	}
	public void LoadLevel(string levelName){
		SceneManager.LoadScene(levelName);
	}
	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}
	public void resetLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().buildIndex==0){
			if(Input.anyKeyDown){
				pop.Play();
				LoadNextLevel();
			}
		}
	}
}
