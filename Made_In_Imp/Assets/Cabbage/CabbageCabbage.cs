using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CabbageCabbage : MonoBehaviour {

	int cutCount = 0;
	[System.NonSerialized()]
	public int cutCountGoal = 40;
	public UnityEvent onCutAll;

	bool isCutAll = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Cut() {
		cutCount++;
		if (cutCountGoal <= cutCount) {
			if (isCutAll == false) {
				onCutAll.Invoke ();
				isCutAll = true;
			}
		}
	}
}
