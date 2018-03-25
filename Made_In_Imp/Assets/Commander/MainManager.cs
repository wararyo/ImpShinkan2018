using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    public List<MiniGame> minigames;
    public Text textbox;
    public TimeCounterUI timeCounter;

	// Use this for initialization
	void Start () {
		StartCoroutine (coroutineWork());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator coroutineWork(){
        foreach (MiniGame mg in minigames)
        {
            textbox.text = mg.name;
            yield return new WaitForSecondsRealtime(4);
            SceneManager.LoadSceneAsync(mg.sceneName,LoadSceneMode.Additive);
            timeCounter.StartCounting(8);
            yield return new WaitForSecondsRealtime(8);
            SceneManager.UnloadSceneAsync(mg.sceneName);
        }
        textbox.text = "終わり";
	}
}
