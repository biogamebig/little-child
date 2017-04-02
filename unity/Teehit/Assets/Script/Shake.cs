using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shake : MonoBehaviour {

	public float shakeTimer;
	public float shakeAmount;
	// Use this for initialization
	void Start () {
		shakeAmount = 0.1f;
		shakeTimer = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(shakeTimer >=0){
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y,transform.position.z);
			shakeTimer -= Time.deltaTime;
		}
	}

	public void ShakeCamera(float shakePwr, float shakeDur){

		shakeAmount =  shakePwr;
		shakeTimer = shakeDur; 

	}
}
