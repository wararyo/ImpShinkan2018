using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAudioBridge : MonoBehaviour {

	public void PlaySound(AudioClip clip){
		GetComponent<AudioSource> ().PlayOneShot (clip);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
