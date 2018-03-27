using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerGu : MonoBehaviour {

    public bool isCatched;

	// Use this for initialization
	void Start () {
        isCatched = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (isCatched) return;
        if (transform.position.y < col.transform.position.y) return;
        transform.parent = col.transform;
        var rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        isCatched = true;
    }
}
