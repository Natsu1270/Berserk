using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class helperManText : MonoBehaviour {
	public string[] texts;
	public TextMeshProUGUI dialog;
	public GameObject dialogManager;
	private DialogController dialogController;
	// Use this for initialization
	void Start () {
		dialogController=dialogManager.GetComponent<DialogController>();
		dialogController.sentences=texts;
		dialogController.textDisplay=dialog;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player"){
			Instantiate(dialogManager,this.transform.position,Quaternion.identity);
		}
	}
}
