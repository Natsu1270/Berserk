using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enePorj : MonoBehaviour {
	private GameObject player;
	public float speed;
	private Vector2 target;

	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player2");
		target=new Vector2(player.transform.position.x,player.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position=Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
		if(transform.position.x==target.x && transform.position.y==target.y){
			Destroy(gameObject);
		}
	}
}
