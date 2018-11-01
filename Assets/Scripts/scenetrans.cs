using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenetrans : MonoBehaviour {
	public Animator trans;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().buildIndex==0){
			if(Input.anyKeyDown){
				StartCoroutine(LoadScene());
			}
		}
	}
	IEnumerator LoadScene(){
		trans.SetTrigger("end");
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(1);
	}
}
