using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSunFollow : MonoBehaviour {
	private GameObject player;
	private Transform playerPos;
	public float yDistance;
	public float xDistance;
	public float floatSpeed;
	private Vector3 newPos;
	// Use this for initialization
	void Start () {
		GameObject p=GameObject.FindGameObjectWithTag("Player");
		if(p==null){
			p=GameObject.FindGameObjectWithTag("Player2");
		}
		player=p;
		playerPos=player.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!player.activeSelf){
			player=GameObject.FindGameObjectWithTag("Player2");
			playerPos=player.GetComponent<Transform>();
		}
		newPos=new Vector3(playerPos.position.x+xDistance,playerPos.position.y+yDistance,playerPos.position.z);
		transform.position=Vector2.MoveTowards(transform.position,newPos,floatSpeed*Time.deltaTime);
	}
}
