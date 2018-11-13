using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {
	public checkPointMana checkPointMana;
	public static bool Gameispaused;
	public GameObject pauseMenuUI;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(Gameispaused){
				Resume();
			}else{
				Pause();
			}
		}
	}
	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale=1f;
		Gameispaused=false;
	}
	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale=0f;
		Gameispaused=true;
	}
	public void NewGame(){
		Time.timeScale=1f;
		checkPointMana.lastcheckpoint=new Vector3(-202.5f,-4.4f,0f);
		SceneManager.LoadScene("Level_1");
	}
	public void Gohome(){
		Time.timeScale=1f;
		SceneManager.LoadScene("Start Menu");
	}
	public void Quit(){
		Application.Quit();
	}
}
