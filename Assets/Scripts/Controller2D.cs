using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Controller2D : MonoBehaviour {
	[SerializeField] private float c_jumpForce=400f; // jump force added to character
	[Range(0, .3f)] [SerializeField] private float c_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool c_AirControl=false;
	[SerializeField] private LayerMask c_WhatIsGround;
	[SerializeField] private Transform c_GroundCheck;
	[SerializeField] private Transform c_CeilingCheck;
	private bool c_Grounded;
	const float k_GroundedRadius=.2f;
	const float k_CeilingRadius=.2f;
	private Rigidbody2D c_Rigidbody2D;
	private bool m_FacingRight=true;
	private Vector3 c_Velocity =Vector3.zero;
	
	[Header("Events")]
	[Space]

	public UnityEvent onLandEvent;
	[System.Serializable]
	public class BoolEvent:UnityEvent<bool> {}

	public void Awake(){
		c_Rigidbody2D=GetComponent<Rigidbody2D>();
		if(onLandEvent==null){
			onLandEvent=new UnityEvent();
		}
	}
	// Use this for initialization

	
	private void FixedUpdate(){
		bool wasGrounded=c_Grounded;
		c_Grounded=false;

		Collider2D[] colliders=Physics2D.OverlapCircleAll(c_GroundCheck.position,k_GroundedRadius,c_WhatIsGround);
		for(int i=0;i<colliders.Length;i++){
			if(colliders[i].gameObject!=gameObject){
				c_Grounded=true;
				if(!wasGrounded){
					onLandEvent.Invoke();
				}
			}
		}
	}
	
	public void Move(float move,bool jump){
		if(c_Grounded ||c_AirControl){
			
			Vector3 targetVelocity=new Vector2(move*10f,c_Rigidbody2D.velocity.y);
			c_Rigidbody2D.velocity=Vector3.SmoothDamp(c_Rigidbody2D.velocity,targetVelocity,ref c_Velocity,c_MovementSmoothing);
			if(move>0&& !m_FacingRight){
				Flip();
			}
			else if(move<0 && m_FacingRight){
				Flip();
			}
		}
		if(c_Grounded&&jump){
			c_Grounded=false;
			c_Rigidbody2D.AddForce(new Vector2(0f ,c_jumpForce),ForceMode2D.Impulse);
		}
	}

	private void Flip(){
		m_FacingRight=!m_FacingRight;
		Vector3 theScale=transform.localScale;
		theScale.x*=-1;
		transform.localScale=theScale;
	}

}
