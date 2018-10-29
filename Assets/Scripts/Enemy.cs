using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health;
	public float speed;
	private Animator eneAnime;
	public GameObject dameffect;
	private Rigidbody2D eneRbg;
	public bool moveLeft;
	

	void Start(){
		int ran=Random.Range(0,1);
		if(ran==1) moveLeft=true;
		else if(ran==0) moveLeft=false;
		
		eneRbg=GetComponent<Rigidbody2D>();
		eneAnime=GetComponent<Animator>();
		eneAnime.SetBool("isRunnig",true);
	}
	void Update(){
		if(health<=0){
			Destroy(gameObject);
		}
		if(moveLeft){
			transform.Translate(Vector2.left*speed*Time.deltaTime);
		}else if(!moveLeft){
			transform.Translate(Vector2.right*speed*Time.deltaTime);
		}
	}
	public void TakeDamage(int i){
		eneRbg.velocity=Vector2.up*60;
		Instantiate(dameffect,transform.GetChild(0).transform.position,Quaternion.identity);
		health-=i;
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player2"){
			other.gameObject.GetComponent<Health>().TakenDamage(1);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("limit")){
			moveLeft=!moveLeft;
		}
	}
	void Flip(){
		
	}
}
