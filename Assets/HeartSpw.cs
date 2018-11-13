using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpw : MonoBehaviour {
	public GameObject heart;
	private Enemy enemy;
	private bool once=true;
	// Use this for initialization
	void Start () {
		enemy=GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemy.health<=0 && once){
			Instantiate(heart,transform.position,Quaternion.identity);
			once=false;
		}
	}
}
