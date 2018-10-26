using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperManager : MonoBehaviour {
	public GameObject sword;
	public GameObject shield;
	public AudioClip release;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player"){
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag=="Player"){
			AudioSource.PlayClipAtPoint(release,transform.position);
			Vector3 posSword=new Vector3(transform.position.x+10f,transform.position.y,transform.position.z);
			Vector3 posShield=new Vector3(transform.position.x+15f,transform.position.y,transform.position.z);
			Instantiate(sword,posSword,Quaternion.identity);
			Instantiate(shield,posShield,Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
