using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthLREarth : MonoBehaviour {

	bool dead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D meteo) {
		if (meteo.gameObject.tag == "Finish" && gameObject.layer == meteo.gameObject.layer) {
			//Debug.Log ("unsa");
			GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0, 1);
			dead = true;
		}
	}

	public void move (float x, float y){
		if(!dead) transform.position += new Vector3 (x*0.2f, y*0.2f, 0);
	}
}
