using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabbageGirl : MonoBehaviour {

    public Sprite up, down;
    new SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Up()
    {
        renderer.sprite = up;
    }

    public void Down()
    {
        renderer.sprite = down;
    }
}
