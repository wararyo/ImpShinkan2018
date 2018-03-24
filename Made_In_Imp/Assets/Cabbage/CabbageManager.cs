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
		if (Input.GetMouseButtonDown(0)){//Input.GetButtonDown ("1A")) {
			cabbage1P.Cut();
		}
		if (Input.GetMouseButtonDown (1)) {
			cabbage2P.Cut ();
		}
	}

	public void OnCutSucceed1P() {
		Debug.Log ("キャベツ1P切った");
	}

	public void OnCutSucceed2P() {
		Debug.Log ("キャベツ2P切った");
	}
}
