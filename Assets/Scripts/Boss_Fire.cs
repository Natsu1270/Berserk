using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Fire : MonoBehaviour {
	public GameObject[] pojectiles;
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
			int a=Random.Range(0,pojectiles.Length-1);
			Instantiate(pojectiles[a],firePos.position,Quaternion.identity);
			timeBtwFire=initTimeFire;
		}else{
			timeBtwFire-=Time.deltaTime;
		}
	}
}
