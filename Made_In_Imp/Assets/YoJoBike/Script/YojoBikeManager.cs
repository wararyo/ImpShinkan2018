using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YojoBikeManager : MonoBehaviour {

	public bool isRunning1,isRunning2;
	private bool succeed = false;
	private float x1P,x2P;


	public Background back1, back2;
	public Yojo yojo1, yojo2;

	// Use this for initialization
	void Start () {
		isRunning1 = true;
		isRunning2 = true;
	}
	
	// Update is called once per frame
	void Update () {

		x1P = Input.GetAxisRaw ("1Horizontal");
		x2P = Input.GetAxisRaw ("2Horizontal");

		if (isRunning1 == true) {
			back1.SpeedUp ();
			if(Input.GetButtonDown("1Horizontal")){
				yojo1.MoveYojo (x1P);
			}
		} else if (succeed == true) {
			back1.SpeedDown ();
		} else {
			back1.Stop ();
		}

		back1.MoveBackGround ();

		if (isRunning2 == true) {
			back2.SpeedUp ();
			if (Input.GetButtonDown ("2Horizontal")) {
				yojo2.MoveYojo (x2P);
			}
		} else if (succeed == true) {
			back2.SpeedDown ();
		} else {
			back2.Stop ();
		}

		back2.MoveBackGround ();
	}


	public void Succeed1P(){
		isRunning1 = false;
		succeed = true;
		Commander.Succeed (0);
	}

	public void Succeed2P(){
		isRunning2 = false;
		succeed = true;
		Commander.Succeed (1);
	}

	public void Failed1P(){
		isRunning1 = false;
		Commander.Failed (0);
	}

	public void Failed2P(){
		isRunning2 = false;
		Commander.Failed (1);
	}
}
