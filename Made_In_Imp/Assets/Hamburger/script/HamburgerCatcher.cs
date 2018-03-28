using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerCatcher : MonoBehaviour {

    public int playerNum;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //移動処理　画面からはみ出ないよ！
        float v = Input.GetAxis((playerNum + 1).ToString() + "Horizontal") * 0.5f;
        float pos_x = transform.position.x;
        if (Mathf.Abs(pos_x + v) > 4.8f) v = 0;
        transform.position += Vector3.right * v;
	}
}
