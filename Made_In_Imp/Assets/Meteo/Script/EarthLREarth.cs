using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthLREarth : MonoBehaviour {

	public int Player;
	public bool dead;
	public GameObject armagedon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D meteo) {
		if (!dead && meteo.gameObject.tag == "Finish") {
			Instantiate(armagedon,transform.position,Quaternion.identity);
			transform.position = new Vector3(114514,0,0);
			dead = true;
			Commander.Failed (Player - 1);
		}
	}

	public void move (float x, float y){
		if(!dead) transform.position += new Vector3 (x*0.2f, y*0.2f, 0);
	}

	void onMinigameEnd(){
		Commander.Succeed(Player-1);
	}
}
