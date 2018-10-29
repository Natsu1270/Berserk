using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGhost : MonoBehaviour {
	public GameObject ghosts;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player2")){
				Vector3 pos=new Vector3(Random.Range(10f,100f),Random.Range(10f,100f),other.transform.position.z);
				Instantiate(ghosts,other.transform.position+pos,Quaternion.identity);
			
		}
	}
}
