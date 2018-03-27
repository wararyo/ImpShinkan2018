using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyakurikuManager : MonoBehaviour {

    public GameObject ground1, ground2;
    public float rotateSpeed = 0.1f;
    private Vector3 rotateAngle;
    
	// Use this for initialization
	void Start () {
        rotateAngle = new Vector3(0, 0, rotateSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        RotateGround();

	}

    public void RotateGround()
    {
        ground1.transform.Rotate(rotateAngle);
        ground2.transform.Rotate(rotateAngle);
    }
}
