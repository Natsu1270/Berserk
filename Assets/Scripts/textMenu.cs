using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class textMenu : MonoBehaviour {
	public Text menuText;
	public Text optionDetail;
	public Button[] btns;
	public EventSystem eventSystem;
	public Slider musicSlider;
	// Use this for initialization
	void Start () {
		musicSlider.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(eventSystem.currentSelectedGameObject==btns[0].gameObject){
			musicSlider.gameObject.SetActive(false);
			optionDetail.gameObject.SetActive(true);
			menuText.text="Play";
			optionDetail.text="Ready to fight!";
		}else if(eventSystem.currentSelectedGameObject==btns[1].gameObject){
			musicSlider.gameObject.SetActive(false);
			optionDetail.gameObject.SetActive(true);
			menuText.text="How To Play";
			optionDetail.text="Use AWD or arrow key to move,Space to attack left mouse to fire. ";
		}else if(eventSystem.currentSelectedGameObject==btns[2].gameObject){
			optionDetail.gameObject.SetActive(false);
			menuText.text="Music";
			musicSlider.gameObject.SetActive(true);
		}else if(eventSystem.currentSelectedGameObject==btns[3].gameObject){
			musicSlider.gameObject.SetActive(false);
			optionDetail.gameObject.SetActive(true);
			menuText.text="Exit";
			optionDetail.text="I will miss you!";
		}
		
	}
	
}
