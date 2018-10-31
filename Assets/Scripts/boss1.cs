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
	public GameObject[] limits;	
	public GameObject bossdeadeff;
	private bool playonce=true;
	public AudioClip deadsound;
	private LevelMusic lvm;

	// Use this for initialization
	void Start () {
		lvm=GameObject.FindGameObjectWithTag("lvMusic").GetComponent<LevelMusic>();
		lvm.music.Pause();
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
			if(playonce==true){
				Instantiate(bossdeadeff,transform.GetChild(2).transform.position,Quaternion.identity);
				GetComponent<AudioSource>().clip=deadsound;
				GetComponent<AudioSource>().Play();
				lvm.music.UnPause();
				playonce=false;
			}
			boss1Anime.SetTrigger("death");
			foreach(GameObject l in limits){
				l.SetActive(false);
			}
			
			boss1HealthBar.gameObject.SetActive(false);
			Invoke("bossdead",1.5f);
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
