using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public GameObject ground;
    public float rotateSpeed = 0.1f;
    private Vector3 rotateAngle;

    // Use this for initialization
    void Start () {
        rotateAngle = new Vector3(0, 0, rotateSpeed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotateGround()
    {
        ground.transform.Rotate(rotateAngle);
    }
}
