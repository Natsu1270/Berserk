using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss1 : MonoBehaviour {
	public int boss1Health;
	public int boss1Damage;
	private float timeBtwDamage=1.5f;

	public Slider boss1HealthBar;
	public bool isDead;
	private Animator boss1Anime;
	public GameObject dameffect;
	private GameObject[] ghosts;
	private GameObject[] limits;
	// Use this for initialization
	void Start () {
		ghosts=GameObject.FindGameObjectsWithTag("Ghost");
		foreach(GameObject g in ghosts){
			Destroy(g);
		}
		boss1Anime=GetComponent<Animator>();
		boss1HealthBar.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(boss1Health<=0){
			foreach(GameObject l in limits){
				l.SetActive(true);
			}
			boss1Anime.SetTrigger("death");
			Invoke("bossdead",5f);
		}
		if(timeBtwDamage>0){
			timeBtwDamage-=Time.deltaTime;
		}
		boss1HealthBar.value=boss1Health;
	}
	public void TakeDame(int dam){
		Instantiate(dameffect,transform.GetChild(0).transform.position,Quaternion.identity);
		boss1Health-=dam;
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player2") && isDead==false){
			if(timeBtwDamage<=0){
				other.GetComponent<Health>().TakenDamage(boss1Damage);
			}
		}else if(other.CompareTag("swingsword")){
			print("swrod");
			TakeDame(5);
		}
		
	}
	private void bossdead(){
		Destroy(gameObject);
	}
}
