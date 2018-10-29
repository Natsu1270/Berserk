using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBehavior : MonoBehaviour {
	private int health=2;
	public GameObject dameffect;
	private GameObject player2;
	public float speed;
	// Use this for initialization
	void Start () {
		player2=GameObject.FindGameObjectWithTag("Player2");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position=Vector2.MoveTowards(transform.position,player2.transform.position,speed);
		if(health<=0){
			Destroy(gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="swingsword"){
			Instantiate(dameffect,transform.GetChild(0).transform.position,Quaternion.identity);
			health--;
		}
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player2"){
			other.gameObject.GetComponent<Health>().TakenDamage(1);
		}
		if(other.gameObject.tag=="swingsword"){
			Instantiate(dameffect,transform.GetChild(0).transform.position,Quaternion.identity);
			health--;
		}
	}
}
