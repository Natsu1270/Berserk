using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public float speed;  // Berserk's running speed
	public float jumpForce; //Berserk's jumping force.
	private float extraJump; //extra jump on the mid-air
	public float extraJumpOption; // how many time player can do a extra jump in the mid-air ;)

	private float moveInput; // Move key
	private Rigidbody2D rgb;
	public bool facingRight=true;

	private bool isGrounded; // Is touching grass
	public Transform groundCheck;
	public float groundRadius;
	public LayerMask whatisGround;

	public Animator hurtPanel;
	private Animator anime; //Berserk animation
	public AudioClip landEffect; //landing sound effect
	public AudioClip jumpEffect; //jumping sound effect

	public GameObject landingEffect; 
	public bool canMove=true;
	
	public GameObject playerArm;
	public GameObject vcm1;  // virtual following berserk camera 1
	public GameObject vcm2; // virtual following berserk with weapons camera 2
	public  AudioClip powerup;
	public GameObject hurtEffect;

	
	void Start(){

		anime=GetComponent<Animator>();
		extraJump=extraJumpOption; 
		rgb=GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){
		
		isGrounded=Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatisGround); //Checks if a collider falls within a circular area.
		if(canMove==true){
			moveInput=Input.GetAxisRaw("Horizontal"); //left=-1 null=0 right=1
			rgb.velocity=new Vector2(moveInput*speed,rgb.velocity.y);
		}
		if(canMove==false){
			anime.SetBool("isRunning",false);
		}
		if(!facingRight && moveInput>0){ //move right
			Flip();
		}else if(facingRight && moveInput<0){ //move left
			Flip();
		}
		if(moveInput!=0){
			if(canMove==true){
				anime.SetBool("isRunning",true);
			}
		}else if(moveInput==0){
			anime.SetBool("isRunning",false);
		}

	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="grass" && anime.GetBool("isJumping")==true){
			Vector3 pos=new Vector3(0f,5f,0f);
			Instantiate(landingEffect,this.transform.position-pos,Quaternion.identity);
			AudioSource.PlayClipAtPoint(landEffect,this.transform.position);
		}

		//pick up weapon from the Void.
		if(other.gameObject.tag=="sword"){
			Destroy(other.gameObject);
		}
		if(other.gameObject.tag=="shield"){
			Destroy(other.gameObject);
		}
		if(other.gameObject.tag=="gun"){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag=="trans"){
			playerArm.SetActive(true);
			AudioSource.PlayClipAtPoint(powerup,transform.position);
			this.gameObject.SetActive(false);
			playerArm.transform.position=other.transform.position;
			vcm1.SetActive(false);
			vcm2.SetActive(true);
		}
	}
	void Update(){
		if(!isGrounded){
			anime.SetBool("isJumping",true);
		}
		if(isGrounded){
			extraJump=extraJumpOption;
			anime.SetBool("isJumping",false);
		}
		
		if(canMove){
				if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)){
				
					if(extraJump>0){
						rgb.velocity=Vector2.up*jumpForce;
						extraJump--;
						AudioSource.PlayClipAtPoint(jumpEffect,this.transform.position);
					}else if(extraJump==0 && isGrounded){
						rgb.velocity=Vector2.up*jumpForce;
						AudioSource.PlayClipAtPoint(jumpEffect,this.transform.position);
				}
			}
		}
	}
	void Flip(){
		facingRight=!facingRight;
		Vector3 Scaler=transform.localScale;
		Scaler.x*=-1;
		transform.localScale=Scaler;
	}
	public void Damage(){
		anime.SetTrigger("hurt");
		hurtPanel.SetTrigger("Hurt");
		Instantiate(hurtEffect,transform.position,Quaternion.identity);
	}
}
