using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SelectOnOption : MonoBehaviour {
	public EventSystem evSys;
	public GameObject selected;
	private bool isSelected;
	// Use this for initialization
	void Start () {
		evSys.SetSelectedGameObject(this.transform.GetChild(0).gameObject);
		selected.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Vertical")!=0 &&!isSelected){
			evSys.SetSelectedGameObject(selected);
			isSelected=true;
		}
		
	}
	private void OnDisable() {
		isSelected=false;
	}
	
}
