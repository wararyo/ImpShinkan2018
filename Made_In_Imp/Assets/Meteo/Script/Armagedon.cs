using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armagedon : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float playtime = anim.GetCurrentAnimatorStateInfo (0).normalizedTime;

		if (playtime >= 1)
			transform.position = new Vector3 (114514, 0, 0);
	}
}
