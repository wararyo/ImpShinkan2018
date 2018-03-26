using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthEarth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D meteo) {
		Debug.Log ("unsa");
		if(meteo.gameObject.tag == "finish")
			GetComponent<SpriteRenderer>().color = new Color(1,0,0,0);
	}

	public void move (float x, float y){
		transform.position += new Vector3 (x*0.2f, y*0.2f, 0);
	}
}
