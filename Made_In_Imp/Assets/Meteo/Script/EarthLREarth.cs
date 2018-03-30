using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthLREarth : MonoBehaviour {

	public int Player;
	public bool dead;
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
		if(gameObject.layer == 9)
			SE.panStereo = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D meteo) {
		if (!dead && meteo.gameObject.tag == "Finish") {
			Instantiate(armagedon,transform.position,Quaternion.identity);
			GetComponent<SpriteRenderer> ().enabled = false;
			//transform.position = new Vector3(114514,0,0);
			SE.PlayOneShot (SE.clip);
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