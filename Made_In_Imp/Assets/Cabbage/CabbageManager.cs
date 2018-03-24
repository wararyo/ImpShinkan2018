using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageManager : MonoBehaviour {

	public int cutCountGoal = 40;
	[Space()]

	public CabbageCabbage cabbage1P;
	public CabbageCabbage cabbage2P;
    public CabbageGirl cabbageGirl1P, cabbageGirl2P;

	// Use this for initialization
	void Start () {
		cabbage1P.cutCountGoal = cutCountGoal;
		cabbage2P.cutCountGoal = cutCountGoal;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){//Input.GetButtonDown ("1A")) {
			cabbage1P.Cut();
            cabbageGirl1P.Down();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cabbageGirl1P.Up();
        }
		if (Input.GetMouseButtonDown (1)) {
			cabbage2P.Cut ();
            cabbageGirl2P.Down();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            cabbageGirl2P.Up();
        }
    }

	public void OnCutSucceed1P() {
		Debug.Log ("キャベツ1P切った");
		Commander.Succeed (0);
	}

	public void OnCutSucceed2P() {
		Debug.Log ("キャベツ2P切った");
		Commander.Succeed (1);
	}
}
