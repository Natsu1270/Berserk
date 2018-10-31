using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
	private checkPointMana ckm;
	public int health;
	public Image[] hearts;
	public AudioClip hurtSound;
	private PlayerController player;
	private Rigidbody2D rgb;
	public GameObject skullDead;
	public AudioClip deathSound;

	private void Awake() {
		rgb=GetComponent<Rigidbody2D>();
		ckm=GameObject.FindGameObjectWithTag("ckm").GetComponent<checkPointMana>();
		transform.position=ckm.lastcheckpoint;
	}
	void Start(){
		player=GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
	}
	void Update(){
		for(int i=0;i<hearts.Length;i++){
			if(i<health){
				hearts[i].enabled=true;
			}else{
				hearts[i].enabled=false;
			}
		}
		if(health<=0){
			
				this.gameObject.SetActive(false);
				Instantiate(skullDead,transform.GetChild(0).transform.position,Quaternion.identity);
				AudioSource.PlayClipAtPoint(deathSound,transform.position);
				Invoke("Lost",2f);
			
			
		}
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("optacle")){
			TakenDamage(1);
		}
		if(other.CompareTag("bosssword")){
			TakenDamage(1);
		}
	}
	void Lost(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void TakenDamage(int damage){
		rgb.velocity=Vector2.up*50;
		health=health-damage;
		AudioSource.PlayClipAtPoint(hurtSound,this.transform.position);
		player.Damage();
	}
}
