using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotate : MonoBehaviour {

	public float speed;
	public EarthLREarth Earth;
	public Transform shield;
	public GameObject Explosion;
	public GameObject zangai;
	GameObject unsa;
	bool destroy;
	bool flag;
	float count=0;

	// Use this for initialization
	void Start () {
		Commander.onMinigameEnd += onMinigameEnd;
		
	}
	
	// Update is called once per frame
	void Update () {

		count += Time.deltaTime;
		
		if (Earth.dead)
			destroy = true;

		if (count > 7)
			destroy = true;

		if (destroy && !flag) {
			unsa = Instantiate (zangai, shield.position, transform.rotation);
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

	void onMinigameEnd(){
		Destroy(unsa);
	}
}
