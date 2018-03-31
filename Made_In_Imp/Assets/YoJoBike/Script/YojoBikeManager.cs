using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YojoBikeManager : MonoBehaviour {

	public bool isRunning1,isRunning2;
	private bool succeed = false;
	private float x1,x2;
    float x1Before = 0;
    float x2Before = 0;

    public Background back1, back2;
	public Yojo yojo1, yojo2;

	// Use this for initialization
	void Start () {
		isRunning1 = true;
		isRunning2 = true;
	}
	
	// Update is called once per frame
	void Update () {

		x1 = Input.GetAxisRaw ("1Horizontal");
		x2 = Input.GetAxisRaw ("2Horizontal");

		if (Input.GetButtonDown ("1L"))
			yojo1.MoveYojo (-1);
		if (Input.GetButtonDown ("1R"))
			yojo1.MoveYojo (1);
		if (Input.GetButtonDown ("2L"))
			yojo2.MoveYojo (-1);
		if (Input.GetButtonDown ("2R"))
			yojo2.MoveYojo (1);

		if(x1Before==0 && x1!=0){
			yojo1.MoveYojo (x1);
		}
		if (isRunning1 == true) {
			back1.SpeedUp ();
		} else if (succeed == true) {
			back1.SpeedDown ();
		} else {
			back1.Stop ();
		}

		back1.MoveBackGround ();

		if (x2Before == 0 && x2 != 0) {
			yojo2.MoveYojo (x2);
		}
		if (isRunning2 == true) {
			back2.SpeedUp ();
		} else if (succeed == true) {
			back2.SpeedDown ();
		} else {
			back2.Stop ();
		}

		back2.MoveBackGround ();

        x1Before = x1;
        x2Before = x2;
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
