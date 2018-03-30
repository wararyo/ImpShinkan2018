using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

	public CanvasGroup g;
	public ScoreUI score1P,score2P;

	public AudioSource BGM;

	int phase = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			switch(phase){
			case 0:
				score1P.setScore (Commander.score [0]);
				score2P.setScore (Commander.score [1]);
				g.alpha = 1;
				GetComponent<AudioSource> ().Play ();
				StartCoroutine (coroutineWork ());
				break;
			case 1:
				new GameObject().AddComponent<SceneNavigator>();
				SceneNavigator.Instance.Change("Title",1);
				break;
			}
			phase++;
		}
	}

	IEnumerator coroutineWork(){
		yield return new WaitForSecondsRealtime (1);
		BGM.Play ();
	}

}
