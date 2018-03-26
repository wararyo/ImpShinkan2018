using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFiveManager : MonoBehaviour {

    public HighFiveHand hand1P;
    public HighFiveHand hand2P;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (hand1P.enabled)
            {
                hand1P.enabled = false;
                if (hand1P.HighFive() == true)
                {
                    Commander.Succeed(0);
                    Debug.Log("1Pハイタッチ成功や");
                }
                else
                {
                    Commander.Failed(0);
                    Debug.Log("1Pハイタッチ失敗や");
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (hand2P.enabled)
            {
                hand2P.enabled = false;
                if (hand2P.HighFive() == true)
                {
                    Commander.Succeed(1);
                    Debug.Log("2Pハイタッチ成功や");
                }
                else
                {
                    Commander.Failed(1);
                    Debug.Log("2Pハイタッチ失敗や");
                }
            }
        }
	}
}
