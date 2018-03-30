using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCenterMeteoMeteo : MonoBehaviour {

	public Vector2 start;
	public Vector2 angle;
	public float speed;
	AudioSource[] SE;

	// Use this for initialization
	void Start () {
		start = transform.position;
		angle = -1*start;
		angle.Normalize ();
		SE = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 unsa = speed * angle;
		transform.position += unsa;
		Vector3 aho = new Vector3 (0, 0, speed * 30);
		transform.eulerAngles += aho;
	}

	void OnTriggerEnter2D(Collider2D s){
		if (s.gameObject.tag == "Player"){
			angle *= -1;
			SE [1].PlayOneShot (SE [1].clip);
		}
	}

}
