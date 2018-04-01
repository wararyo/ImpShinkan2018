using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthEarth : MonoBehaviour {

	public int Player;
	bool dead;
	public GameObject armagedon;
	AudioSource SE;

	// Use this for initialization
	void Start () {
		Commander.onMinigameEnd += () => {
			Commander.Succeed(Player-1);
		};
		SE = GetComponent<AudioSource> ();
		if (gameObject.layer == 8)
			SE.panStereo = -1;
		else if(gameObject.layer == 9)
			SE.panStereo = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D meteo) {
		if (!dead && meteo.gameObject.tag == "Finish") {
			//Debug.Log ("unsa");
			Instantiate(armagedon,transform.position,Quaternion.identity);
			SE.PlayOneShot (SE.clip);
			transform.position = new Vector3(114514,0,0);
			dead = true;
			Commander.Failed (Player - 1);
		}
	}

	public void move (float x, float y){
		if(!dead) transform.position += new Vector3 (x*0.15f, y*0.15f, 0);
	}

	void onMinigameEnd(){
		Commander.Succeed(Player-1);
	}
}
