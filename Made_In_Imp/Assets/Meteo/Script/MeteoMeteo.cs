using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoMeteo : MonoBehaviour {

	public Vector2 start;
	public Vector2 aim;
	public Vector2 angle;
	public float speed;
	public float aim_range;

	// Use this for initialization
	void Start () {
		start = transform.position;
		float a, b;
		a = Random.Range (-aim_range, aim_range);
		b = Random.Range (-aim_range, aim_range);
		aim = new Vector2 (a,b);
		angle = aim - start;
		angle.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 unsa = speed * angle;
		transform.position += unsa;
		Vector3 aho = new Vector3 (0, 0, speed * 30);
		transform.eulerAngles += aho;
	}

}
