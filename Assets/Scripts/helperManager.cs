using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperManager : MonoBehaviour {
	public GameObject sword;
	public GameObject shield;
	public AudioClip release;
	public GameObject btnContinue;
	private AudioSource thevoidMusic;
	public GameObject gun;
	private LevelMusic lvm;
	// Use this for initialization
	void Start () {
		lvm=GameObject.FindGameObjectWithTag("lvMusic").GetComponent<LevelMusic>();
		thevoidMusic=GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player" ||other.CompareTag("Player2")){
			lvm.music.Pause();
			thevoidMusic.Play();
			//other.gameObject.GetComponent<PlayerController>().canMove=false;
			//other.transform.position=this.transform.position-new Vector3(10f,0f,0f);
			transform.GetChild(0).gameObject.SetActive(true);
			btnContinue.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag=="Player"){
			lvm.music.UnPause();
			thevoidMusic.Stop();
			AudioSource.PlayClipAtPoint(release,transform.position);
			Vector3 posSword=new Vector3(transform.position.x+18f,transform.position.y,transform.position.z);
			Vector3 posShield=new Vector3(transform.position.x+23f,transform.position.y,transform.position.z);
			Instantiate(sword,posSword,Quaternion.identity);
			Instantiate(shield,posShield,Quaternion.identity);
			Destroy(this.gameObject);
		}
		if(other.CompareTag("Player2")){
			lvm.music.UnPause();
			thevoidMusic.Stop();
			AudioSource.PlayClipAtPoint(release,transform.position);
			Vector3 posShield=new Vector3(transform.position.x+13f,transform.position.y,transform.position.z);
			Instantiate(gun,posShield,Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
