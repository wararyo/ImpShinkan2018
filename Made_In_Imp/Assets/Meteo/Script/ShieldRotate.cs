using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotate : MonoBehaviour {

	public float speed;
	public EarthLREarth Earth;
	//public 爆発エフェクト
	bool destroy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Earth.dead)
			destroy = true;

		if (destroy) {
			Vector3 EndOfTheWorld = new Vector3 (114514, 0, 0);
			transform.position = EndOfTheWorld;
		}
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
