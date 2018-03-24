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

	public void move (float x, float y){
		transform.position += new Vector3 (x*0.3f, y*0.3f, 0);
	}
}
