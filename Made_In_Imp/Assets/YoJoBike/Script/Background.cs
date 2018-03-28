using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public GameObject backGround;
	public float moveSpeed = 0;
	public float maxMoveSpeed = 15.0f;
	public float speedUpRatio = 2.0f;
	public float speedDownRatio = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SpeedUp(){
			moveSpeed += Time.deltaTime * speedUpRatio;
		moveSpeed = Mathf.Clamp (moveSpeed, 0, maxMoveSpeed);
	}

	public void SpeedDown(){
		moveSpeed -=  Time.deltaTime * speedDownRatio;
		moveSpeed = Mathf.Clamp (moveSpeed, 0, maxMoveSpeed);
	}

	public void Stop(){
		moveSpeed = 0;
	}

	public void MoveBackGround(){
		
		backGround.transform.position += Vector3.down * moveSpeed * Time.deltaTime;
	}
}
