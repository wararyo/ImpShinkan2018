using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MazePlayer : MonoBehaviour {

	public float moveSpeed = 0.2f;
	public UnityEvent onGoal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move (float x, float y){
		transform.position += new Vector3 (x * moveSpeed, y * moveSpeed, 0);
	}

	void OnTriggerEnter2D(Collider2D c){
		onGoal.Invoke ();
	}
}
