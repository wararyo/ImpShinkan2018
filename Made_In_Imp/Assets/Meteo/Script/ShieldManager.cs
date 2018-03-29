using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

	public ShieldRotate Shield1;
	public ShieldRotate Shield2;
	bool L1;
	bool R1;
	bool L2;
	bool R2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		L1 = Input.GetButton ("1L");
		R1 = Input.GetButton ("1R");
		L2 = Input.GetButton ("2L");
		R2 = Input.GetButton ("2R");
		Shield1.Role (L1, R1);
		Shield2.Role (L2, R2);


	}
}
