using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotate : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Role(bool L,bool R){
		float angle = 0;
		if (L && R)
			angle = 0;
		else if (L)
			angle = speed;
		else if (R)
			angle = -speed;
		transform.eulerAngles += angle * new Vector3 (0, 0, 1);
	}
}
