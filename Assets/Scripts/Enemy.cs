﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour {

	public float health;
	public float speed;
	private Animator eneAnime;
	public GameObject dameffect;
	private Rigidbody2D eneRbg;
	public bool moveLeft;
	private AudioSource hurt;
	public GameObject roll_spawner;
	public bool zzz=false;
	public int ene_dam;
	public AudioClip deadsound;
	public GameObject bloodStain;
	private RipplePostProcessor ripple;
	void Start(){
		ripple=Camera.main.GetComponent<RipplePostProcessor>();
		hurt=GetComponent<AudioSource>();
		int ran=Random.Range(0,1);
		if(ran==1) moveLeft=true;
		else if(ran==0) moveLeft=false;
		
		eneRbg=GetComponent<Rigidbody2D>();
		eneAnime=GetComponent<Animator>();
		eneAnime.SetBool("isRunnig",true);
	}
	void Update(){
		if(health<=0){
			ripple.RippleEffect();
			Instantiate(bloodStain,transform.position-new Vector3(0f,2f),Quaternion.identity);
			AudioSource.PlayClipAtPoint(deadsound,transform.position);
			Destroy(gameObject);
		}
		if(moveLeft){
			transform.Translate(Vector2.left*speed*Time.deltaTime);
		}else if(!moveLeft){
			transform.Translate(Vector2.right*speed*Time.deltaTime);
		}
	}
	public void TakeDamage(int i){
		hurt.Play();
		if(zzz==true){
			eneRbg.velocity=Vector2.up*60;
		}
		
		Instantiate(dameffect,transform.GetChild(0).transform.position,Quaternion.identity);
		health-=i;
	}
	public void BossTakeDam(int dame){
		roll_spawner.SetActive(false);
		hurt.Play();
		Instantiate(dameffect,transform.position,Quaternion.identity);
		health-=dame;
	}
	private void OnCollisionEnter2D(Collision2D other) {
		
		if(other.gameObject.tag=="Player2"){
			if(SceneManager.GetActiveScene().name=="Level_1"){
				other.gameObject.GetComponent<Health>().TakenDamage(ene_dam);
			}else if(SceneManager.GetActiveScene().name=="Level_2"){
				other.gameObject.GetComponent<Health2>().TakenDamage(ene_dam);
			}
				
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
