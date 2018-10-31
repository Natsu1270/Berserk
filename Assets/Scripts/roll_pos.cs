using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roll_pos : MonoBehaviour {
	public GameObject rollOp;
	private float timeBtwSpawn;
	public float initTimeBtwSpawn;
	private AudioSource s;
	
	private void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position,4);
	}
	// Use this for initialization
	void Start () {
		s=GetComponent<AudioSource>();
		timeBtwSpawn=initTimeBtwSpawn;
	}
	
	// Update is called once per frame
	void Update () {
		if(timeBtwSpawn<=0){
			s.Play();
			Instantiate(rollOp,this.transform.position,Quaternion.identity);
			timeBtwSpawn=initTimeBtwSpawn;
		}else{
			timeBtwSpawn-=Time.deltaTime;
		}
	}
}
