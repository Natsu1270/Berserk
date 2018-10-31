using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour {
	public float offset;
	public GameObject gunprojectile;
	public Transform shotPoint;
	private float timeBtwShot;
	public float shotFreq;
	// Use this for initialization
	void Start () {
		timeBtwShot=shotFreq;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dis=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
		float rotZ=Mathf.Atan2(dis.y,dis.x)*Mathf.Rad2Deg;
		transform.rotation=Quaternion.Euler(0f,0f,rotZ+offset);
		if(timeBtwShot<=0){
			if(Input.GetKeyDown(KeyCode.Z)){
			Instantiate(gunprojectile,shotPoint.position,transform.rotation);
			timeBtwShot=shotFreq;
			}
		}else{
			timeBtwShot-=Time.deltaTime;
		}
	}
}
