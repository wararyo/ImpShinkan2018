using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTransition : MonoBehaviour {

	public GameObject texts;
	private Vector3 transition;
	public float speed = 1.0f;



	private float textPositionY = 520;
	public RectTransform textTransform;

	// Use this for initialization
	void Start () {
		transition = new Vector3 (0, speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (textTransform.position.y);

		if (textTransform.position.y < textPositionY) {
			texts.transform.position += transition;
		}
	}
}
