using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFiveManager : MonoBehaviour {

    public HighFiveHand hand1P;
    public HighFiveHand hand2P;
	public HighFiveSun sun1P;
	public HighFiveSun sun2P;
    public SpriteRenderer women1P, women2P;
    public Sprite womenFailed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("1A"))
        {
            if (hand1P.enabled)
            {
                hand1P.enabled = false;
                if (hand1P.HighFive() == true)
                {
                    Commander.Succeed(0);
					sun1P.Show ();
                    Debug.Log("1Pハイタッチ成功や");
                }
                else
                {
                    Commander.Failed(0);
                    women1P.sprite = womenFailed;
                    Debug.Log("1Pハイタッチ失敗や");
                }
            }
        }
		if (Input.GetButtonDown ("2A"))
        {
            if (hand2P.enabled)
            {
                hand2P.enabled = false;
                if (hand2P.HighFive() == true)
                {
                    Commander.Succeed(1);
					sun2P.Show ();
                    Debug.Log("2Pハイタッチ成功や");
                }
                else
                {
                    Commander.Failed(1);
                    women2P.sprite = womenFailed;
                    Debug.Log("2Pハイタッチ失敗や");
                }
            }
        }
	}
}
