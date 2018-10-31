using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogController : MonoBehaviour {
	public TextMeshProUGUI textDisplay;
	public string[] sentences;
	private string[] currentSentences;
	private int index=0;
	public float typingSpeed;
	public GameObject contBtn;
	private GameObject playerGO;
	private PlayerController player;
	private AudioSource nextSound;
	private bool canSpace=true;
	
	void Start(){
		nextSound=GetComponent<AudioSource>();
		currentSentences=sentences;
		StartCoroutine(Type());
		playerGO=GameObject.FindGameObjectWithTag("Player");
		player=playerGO.GetComponent<PlayerController>();
	}
	void Update(){
		if(index<sentences.Length){
			player.canMove=false;
			if(textDisplay.text==currentSentences[index]){
				contBtn.SetActive(true);
				canSpace=true;
			}
			if(Input.GetKeyDown(KeyCode.Space)){
				if(canSpace)
					NextSentence();
			}
		}else{
			player.canMove=true;
			this.gameObject.SetActive(false);
		}
		
		// if(index>=currentSentences.Length){
		// 	player.canMove=true;
		// 	this.gameObject.SetActive(false);
		// }
		
	}
	IEnumerator Type(){
		nextSound.Play();
		foreach(char letter in currentSentences[index].ToCharArray()){
			textDisplay.text+=letter;
			yield return new WaitForSeconds(typingSpeed);
		}
	}
	public void NextSentence(){
		contBtn.SetActive(false);
		canSpace=false;
		nextSound.Play();
		if(index<currentSentences.Length-1){
			index++;
			textDisplay.text="";
			StartCoroutine(Type());
		}else{
			index++;
			textDisplay.text="";
			contBtn.SetActive(false);
			canSpace=false;
			
		}
	}
}
