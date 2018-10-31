using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointMana : MonoBehaviour {

	private static checkPointMana instance;
	public Vector3 lastcheckpoint;
	void Awake(){
		if(instance==null){
			instance=this;
			DontDestroyOnLoad(instance);
		}else{
			Destroy(gameObject);
		}
	}
}
