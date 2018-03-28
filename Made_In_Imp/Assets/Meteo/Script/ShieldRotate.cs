using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotate : MonoBehaviour {

	public float speed;
	public EarthLREarth Earth;
	public Transform shield;
	public GameObject Explosion;
	public GameObject zangai;
	bool destroy;
	bool flag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Earth.dead)
			destroy = true;

		if (destroy && !flag) {
			Instantiate (zangai, shield.position, transform.rotation);
			Instantiate (Explosion, shield.position, transform.rotation);
			transform.position = new Vector3 (114514, 0, 0);
			flag = true;
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
