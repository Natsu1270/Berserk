using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumnController : MonoBehaviour {

	// Use this for initialization
	public Slider mSlider;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AudioListener.volume=mSlider.value;
	}
}
