using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFoll : MonoBehaviour {


	public GameObject ball;
	Vector3 offset; //Distance bt/w Cam and our ball
	public float lerpRate; //Rate at which the Camera will change its position to follow the ball
	public bool GameOver;

	// Use this for initialization
	void Start () {

		offset = ball.transform.position - transform.position;
		GameOver = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOver) {
			Follow ();
		}
		
	}

	void Follow(){
		Vector3 pos = transform.position;
		Vector3 targetpos = ball.transform.position - offset;
		pos = Vector3.Lerp (pos, targetpos, lerpRate * Time.deltaTime);
		transform.position = pos;


	}


}
