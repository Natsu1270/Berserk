using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyformation : MonoBehaviour {

	public GameObject player;
	private bool once;
	public GameObject boss;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(this.transform.childCount==0 || once==true){
			boss.SetActive(true);
			once=false;
			Destroy(gameObject);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}
}
