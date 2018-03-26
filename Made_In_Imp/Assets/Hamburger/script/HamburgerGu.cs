using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerGu : MonoBehaviour {

    bool isCatched;

	// Use this for initialization
	void Start () {
        isCatched = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col) {
        Debug.Log("!");
        if (isCatched) return;
        transform.parent = col.transform;
        GetComponent<Rigidbody2D>().isKinematic = true;
        isCatched = true;
    }
}
