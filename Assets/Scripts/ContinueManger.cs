using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueManger : MonoBehaviour {
	private continuenumber cn;
	// Use this for initialization
	void Start () {
		cn=GameObject.FindGameObjectWithTag("Continue").GetComponent<continuenumber>();

	}
	
	public void LoadScene(){
		StartCoroutine(FadeLoadScene());
	}
	public void NewGame(){
		SceneManager.LoadScene("Level_1");
	}

	IEnumerator FadeLoadScene(){
		yield return new WaitForSeconds(.5f);
		cn.LoadNewScene();
	}

	
}
