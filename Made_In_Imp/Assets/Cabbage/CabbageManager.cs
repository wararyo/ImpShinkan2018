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
		if (Input.GetButtonDown ("1A")) {
			cabbage1P.Cut();
            cabbageGirl1P.Down();
        }
		else if (Input.GetButtonUp ("1A"))
        {
            cabbageGirl1P.Up();
        }
		if (Input.GetButtonDown ("2A")) {
			cabbage2P.Cut ();
            cabbageGirl2P.Down();
        }
		else if (Input.GetButtonUp ("2A"))
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
