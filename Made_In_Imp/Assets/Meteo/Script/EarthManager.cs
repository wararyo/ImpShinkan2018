using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour {

	public EarthEarth Earth1;
	public EarthEarth Earth2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Earth1.move (Input.GetAxisRaw ("1Horizontal"),Input.GetAxisRaw("1Vertical"));
		Earth2.move (Input.GetAxisRaw ("2Horizontal"),Input.GetAxisRaw("2Vertical"));
	}
}
