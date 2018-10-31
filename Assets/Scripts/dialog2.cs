using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dialog2 : MonoBehaviour {
	public TextMeshProUGUI textDisplay;
	public string[] sentences;
	private int index=0;
	public float typingSpeed;
	
	private PlayerController player;
	private bool canSpace=true;
	
	void Start(){
		StartCoroutine(Type());
		player=GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
	}
	void Update(){
		if(index<sentences.Length){
			player.canMove=false;
			if(textDisplay.text==sentences[index]){
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
		
		// if(index>=sentences.Length){
		// 	player.canMove=true;
		// 	this.gameObject.SetActive(false);
		// }
		
	}
	IEnumerator Type(){
		foreach(char letter in sentences[index].ToCharArray()){
			textDisplay.text+=letter;
			yield return new WaitForSeconds(typingSpeed);
		}
	}
	public void NextSentence(){
		
		canSpace=false;
		if(index<sentences.Length-1){
			index++;
			textDisplay.text="";
			StartCoroutine(Type());
		}else{
			index++;
			textDisplay.text="";
			canSpace=false;
			
		}
	}
}
