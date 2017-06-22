using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject platform;

	Vector3 lastpos;
	float size;
	public bool GameOver;



	// Use this for initialization
	void Start () {
		lastpos = platform.transform.position;
		size = platform.transform.localScale.x;

		for (int i = 0; i < 20; i++) {
			SpawnPlatforms();
		}

		InvokeRepeating ("SpawnPlatforms", 2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameOver) {
			CancelInvoke ("SpawnPlatforms");
		}
	}

	void SpawnPlatforms(){
		
		int rand = Random.Range(0, 6);
		if (rand < 3) {
			SpawnX ();	
		} 
		else if (rand >= 3) {
			SpawnZ ();
		}
	}

	void SpawnX(){
		Vector3 pos = lastpos;
		pos.x += size;
		lastpos = pos;
		Instantiate (platform,pos,Quaternion.identity); //Spawn the clone Platforms at the end of the previous and with no rotation


	}


	void SpawnZ(){
		Vector3 pos = lastpos;
		pos.z += size;
		lastpos = pos;
		Instantiate (platform,pos,Quaternion.identity); //Spawn the clone Platforms at the end of the previous and with no rotation

	}






}

