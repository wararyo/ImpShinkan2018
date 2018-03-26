using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerCatcher : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("1Horizontal") * 0.5f;
        float pos_x = transform.position.x;
        if (Mathf.Abs(pos_x + v) > 4.8f) v = 0;
        transform.position += Vector3.right * v;
	}
}
