using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ene_fire : MonoBehaviour {
	public GameObject pojectile;
	private GameObject player;
	public float initTimeFire;
	private float timeBtwFire;
	private Transform firePos;
	// Use this for initialization
	void Start () {
		firePos=transform.GetChild(0).transform;
		timeBtwFire=initTimeFire;
	}
	
	// Update is called once per frame
	void Update () {
		if(timeBtwFire<=0){
			Instantiate(pojectile,firePos.position,Quaternion.identity);
			timeBtwFire=initTimeFire;
		}else{
			timeBtwFire-=Time.deltaTime;
		}
	}
}
