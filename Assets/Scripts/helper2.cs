using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helper2 : MonoBehaviour {
	public AudioClip release;
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
		if(other.CompareTag("Player2")){
			lvm.music.Pause();
			thevoidMusic.Play();
			//other.gameObject.GetComponent<PlayerController>().canMove=false;
			//other.transform.position=this.transform.position-new Vector3(10f,0f,0f);
			transform.GetChild(0).gameObject.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
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
