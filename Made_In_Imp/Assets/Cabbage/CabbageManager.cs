using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageManager : MonoBehaviour {

	public int cutCountGoal = 40;
	[Space()]

	public CabbageCabbage cabbage1P;
	public CabbageCabbage cabbage2P;

	// Use this for initialization
	void Start () {
		cabbage1P.cutCountGoal = cutCountGoal;
		cabbage2P.cutCountGoal = cutCountGoal;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("1A")) {
			cabbage1P.Cut();
		}
	}

	public void OnCutSucceed1P() {

	}

	public void OnCutSucceed2P() {

	}
}
