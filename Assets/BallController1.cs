using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController1 : MonoBehaviour {

	[SerializeField]
	private float speed;
	bool started;
	bool GameOver;
	Rigidbody rb;


	void Awake()
	{ rb = GetComponent<Rigidbody> ();
	}



	// Use this for initialization
	void Start () {
		started = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!started) {
			if (Input.GetMouseButtonDown (0)) {
				rb.velocity = new Vector3 (speed, 0, 0);
				started = true;
			}
		}

		Debug.DrawRay (transform.position, Vector3.down, Color.red);

		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			GameOver = true;
			rb.velocity = new Vector3 (0, -25f, 0);

			Camera.main.GetComponent<CamFoll>().GameOver = true;
		}
		if(Input.GetMouseButtonDown(0) && !GameOver) {
			SwitchDir ();
		}
	}

	void SwitchDir()
	{
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}


	}



}
