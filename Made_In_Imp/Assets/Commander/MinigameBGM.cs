using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MinigameBGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Commander.onMinigameStart += () => {
			GetComponent<AudioSource>().Play();
		};
		Commander.onMinigameEnd += () => {
			GetComponent<AudioSource>().Stop();
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
