using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOnLoad : MonoBehaviour {
	public float fadeInTime=1.5f;
	private Image fadeImg;
	private Color currentColor=Color.black;
	// Use this for initialization
	void Start () {
		fadeImg=gameObject.GetComponent<Image>();
		//fadeImg.color=new Color(0f,0f,0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad<fadeInTime){
			float alphaTime=Time.deltaTime/fadeInTime;
			currentColor.a-=alphaTime;
			fadeImg.color=currentColor;
		}else{
			gameObject.SetActive(false);
		}
	}
}
