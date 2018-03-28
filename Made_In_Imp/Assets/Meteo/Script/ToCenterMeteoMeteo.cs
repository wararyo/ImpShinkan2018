using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCenterMeteoMeteo : MonoBehaviour {

	public Vector2 start;
	public Vector2 angle;
	public float speed;

	// Use this for initialization
	void Start () {
		start = transform.position;
		angle = -1*start;
		angle.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 unsa = speed * angle;
		transform.position += unsa;
		Vector3 aho = new Vector3 (0, 0, speed * 30);
		transform.eulerAngles += aho;
	}

	void OnTriggerEnter2D(Collider2D s){
		if (s.gameObject.tag == "Player")
			angle *= -1;
	}

}
