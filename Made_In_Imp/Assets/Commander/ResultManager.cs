using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {

	public CanvasGroup g;
	public ScoreUI score1P,score2P;

	public AudioSource BGM;
    public AudioSource drumRoll;

	int phase = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("1A")) {
			switch(phase){
            case 0:
                drumRoll.Play();
                break;
			case 1:
				drumRoll.Stop ();
				score1P.setScore (Commander.score [0]);
				score2P.setScore (Commander.score [1]);
				g.alpha = 1;
				GetComponent<AudioSource> ().Play ();
				StartCoroutine (coroutineWork ());
				break;
			case 2:
                SceneManager.LoadSceneAsync("Credit", LoadSceneMode.Additive);
				break;
            case 3:
                new GameObject().AddComponent<SceneNavigator>();
                SceneNavigator.Instance.Change("Title", 2);
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
