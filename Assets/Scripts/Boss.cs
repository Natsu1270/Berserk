using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
    private LevelMusic lvm;
    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;
	private bool playonce=true;


    public Animator camAnim;
    public Slider healthBar;
    private Animator anim;
    public bool isDead;
    public GameObject[] limits;
    public GameObject bossDeathEff;
    private AudioSource S;
    public AudioSource edingsong;

    private void Start()
    {
		lvm=GameObject.FindGameObjectWithTag("lvMusic").GetComponent<LevelMusic>();
        S=GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (health <= 50) {
            anim.SetTrigger("stageTwo");
        }

        if (health <= 0) {
            foreach(GameObject l in limits){
                Destroy(l);
            }
            if(playonce==true){
                Instantiate(bossDeathEff,transform.GetChild(0).transform.position,Quaternion.identity);
				GetComponent<AudioSource>().Play();
                healthBar.gameObject.SetActive(false);
                lvm.music.Pause();
				playonce=false;
			}
            anim.SetTrigger("death");
            Invoke("bossdead",2f);
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0) {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player2") && isDead == false) {
            if (timeBtwDamage <= 0) {
                camAnim.SetTrigger("shake");
                other.GetComponent<Health2>().TakenDamage(damage);
            }
        } 
    }
    void bossdead(){
        edingsong.Play();
        Destroy(gameObject);
    }
}
