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
	public GameObject slash;
	public GameObject boss;
	private PlayerController playerController;
	private RipplePostProcessor ripple;
	
	void Start(){
		ripple=Camera.main.GetComponent<RipplePostProcessor>();
		playerController=GetComponent<PlayerController>();
		playeranime=GetComponent<Animator>();
		timeBtwAttack=0;
	}
	// Update is called once per frame
	void Update () {
		if(timeBtwAttack<=0){
			if(Input.GetKeyDown(KeyCode.Z)){
				ripple.RippleEffect();
				Vector3 sPos=new Vector3(5f,0f,0f);
				if(playerController.facingRight){
					Instantiate(slash,transform.GetChild(0).transform.position+sPos,Quaternion.identity);
				}else if(playerController.facingRight==false){
					Instantiate(slash,transform.GetChild(0).transform.position-sPos,Quaternion.identity);
				}
				AudioSource.PlayClipAtPoint(swordSound,transform.position);
				playeranime.SetTrigger("Attack");
				Collider2D[] enemyToDamage=Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsEnemy);
				for(int i=0;i<enemyToDamage.Length;i++){
					if(enemyToDamage[i].gameObject.tag=="run_ene" || enemyToDamage[i].gameObject.tag=="fly_ene"){
						enemyToDamage[i].GetComponent<Enemy>().TakeDamage(damage); //damage to quai.
					}else if(enemyToDamage[i].gameObject.tag=="roll_spawner"){
						enemyToDamage[i].GetComponent<Enemy>().BossTakeDam(damage);} //damage to boss
					else if(enemyToDamage[i].gameObject.tag=="boss1"){
						enemyToDamage[i].GetComponent<boss1>().TakeDame(damage); //damage to boss
					}else if(enemyToDamage[i].gameObject.tag=="Ghost"){
						enemyToDamage[i].GetComponent<ghostBehavior>().TakenDamage(damage);
					}
				}
				timeBtwAttack=startTimeBtwAttack;
				}
			}else{
				timeBtwAttack-=Time.deltaTime;
			}
				
		}
	void OnDrawGizmosSelected(){
		Gizmos.color=Color.red;
		Gizmos.DrawWireSphere(attackPos.position,attackRange);
	}
}
