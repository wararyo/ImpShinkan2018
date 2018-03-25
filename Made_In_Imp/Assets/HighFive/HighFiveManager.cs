using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFiveManager : MonoBehaviour {

    public HighFiveHand hand1P;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (hand1P.HighFive() == true)
            {
                Debug.Log("1Pハイタッチ成功や");
            }
            else
            {
                Debug.Log("1Pハイタッチ失敗や");
            }
        }
	}
}
