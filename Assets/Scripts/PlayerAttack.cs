using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	private float timeBtwAttack; //avoid spam attack
	public float startTimeBtwAttack;
	private Animator playeranime;
	public Transform attackPos;
	public LayerMask whatIsEnemy;
	public float attackRange;
	public int damage;
	public AudioClip swordSound;
	
	void Start(){
		playeranime=GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z)){
				AudioSource.PlayClipAtPoint(swordSound,transform.position);
				playeranime.SetTrigger("Attack");
				Collider2D[] enemyToDamage=Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsEnemy);
				for(int i=0;i<enemyToDamage.Length;i++){
					enemyToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
					enemyToDamage[i].GetComponent<boss1>().TakeDame(damage);

				}
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.color=Color.red;
		Gizmos.DrawWireSphere(attackPos.position,attackRange);
	}
}
