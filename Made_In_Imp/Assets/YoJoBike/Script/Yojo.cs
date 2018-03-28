using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Yojo : MonoBehaviour {
	
	public GameObject endPosition;

	public UnityEvent hitEndPosition,hitObject;

	public float moveSpeed = 0.5f;
	private Vector3 position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveYojo(float x){
		gameObject.transform.position += new Vector3 (x*moveSpeed, 0, 0);
		position = gameObject.transform.position;
		position.x = Mathf.Clamp (position.x, -2.8f, 2.8f);
		gameObject.transform.position = position;
	}

	private void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject == endPosition) {
			Debug.Log ("hit");
			hitEndPosition.Invoke ();
		} else {
			Debug.Log ("Failed");
			hitObject.Invoke ();
		}
	}
}
