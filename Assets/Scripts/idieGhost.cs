using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idieGhost : StateMachineBehaviour {
	private GameObject player2;
	public float speed=0.1f;
	 //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		player2=GameObject.FindGameObjectWithTag("Player2");
	}

	//nStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Vector2 target=new Vector2(player2.transform.position.x,animator.transform.position.y);
		animator.transform.position=Vector2.MoveTowards(animator.transform.position,target,speed*Time.deltaTime);
	}

//	OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
