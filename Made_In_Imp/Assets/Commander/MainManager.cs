using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (coroutineWork());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator coroutineWork(){
		yield return new WaitForSecondsRealtime(8);
	}
}
