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

		Vector3 v1 = new Vector3(Input.GetAxis("1Horizontal"),Input.GetAxis("1Vertical"),0);
		Vector3 v2 = new Vector3(Input.GetAxis("2Horizontal"),Input.GetAxis("2Vertical"),0);

		if (v1.magnitude > 0.5) {
			Shield1.transform.rotation = Quaternion.Lerp(Shield1.transform.rotation,Quaternion.FromToRotation (new Vector3(1.53f,1.28f,0), v1),0.15f);
		}
		if (v2.magnitude > 0.5) {
			Shield2.transform.rotation = Quaternion.Lerp(Shield2.transform.rotation,Quaternion.FromToRotation (new Vector3(1.53f,1.28f,0), v2),0.15f);
		}
	}
}
