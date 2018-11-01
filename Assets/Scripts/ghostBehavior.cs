using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ghostBehavior : MonoBehaviour {
	public int health;
	public GameObject dameffect;
	private GameObject player2;
	public float speed;
	public int ghostDam;
	// Use this for initialization
	void Start () {
		player2=GameObject.FindGameObjectWithTag("Player2");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position=Vector2.MoveTowards(transform.position,player2.transform.position,speed);
		if(health<=0){
			Instantiate(dameffect,transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}
	public void TakenDamage(int dame){
		health-=dame;
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player2"){
			if(SceneManager.GetActiveScene().name=="Level_1"){
				other.gameObject.GetComponent<Health>().TakenDamage(ghostDam);
			}else if(SceneManager.GetActiveScene().name=="Level_2"){
				other.gameObject.GetComponent<Health2>().TakenDamage(ghostDam);
			}
			
			
		}
	}
}
