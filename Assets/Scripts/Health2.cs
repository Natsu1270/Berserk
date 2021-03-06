﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health2 : MonoBehaviour {
	private checkPointMana ckm;
	public int health;
	//public Image[] hearts;
	public AudioClip hurtSound;
	private PlayerController player;
	private Rigidbody2D rgb;
	public GameObject skullDead;
	public AudioClip deathSound;
	public Slider healthbar;
	public float recoverTime;
	public GameObject edPanel;
	private RipplePostProcessor ripple;
	public GameObject edeff;

	private void Awake() {
		ripple=Camera.main.GetComponent<RipplePostProcessor>();
		rgb=GetComponent<Rigidbody2D>();
		//ckm=GameObject.FindGameObjectWithTag("ckm2").GetComponent<checkPointMana>();
		//transform.position=ckm.lastcheckpoint;
	}
	void Start(){
		player=GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
	}
	void Update(){
		// for(int i=0;i<hearts.Length;i++){
		// 	if(i<health){
		// 		hearts[i].enabled=true;
		// 	}else{
		// 		hearts[i].enabled=false;
		// 	}
		// }
		if(health>50){
			health=50;
		}
		if(health<=0){
			
				this.gameObject.SetActive(false);
				Instantiate(skullDead,transform.GetChild(0).transform.position,Quaternion.identity);
				AudioSource.PlayClipAtPoint(deathSound,transform.position);
				Invoke("Lost",2f);
		}
		healthbar.value=health;
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("optacle")){
			TakenDamage(1);
		}
		if(other.CompareTag("bosssword")){
			TakenDamage(1);
		}
		if(other.CompareTag("health")){
			health+=30;
			Destroy(other.gameObject);
		}
		
		if(other.CompareTag("ene_fire")){
			TakenDamage(3);
		}
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="ed"){
			other.gameObject.GetComponent<AudioSource>().Play();
			Instantiate(edeff,transform.position,Quaternion.identity);
			edPanel.SetActive(true);
			Invoke("edd",2f);
		}
	}
	void Lost(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void TakenDamage(int damage){
		ripple.RippleEffect();
		rgb.velocity=Vector2.up*50;
		health=health-damage;
		AudioSource.PlayClipAtPoint(hurtSound,this.transform.position);
		player.Damage();
	}
	void edd(){
		SceneManager.LoadScene(0);
	}
}
