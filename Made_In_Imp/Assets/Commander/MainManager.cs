using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    public List<MiniGame> minigames;
    public Text textbox;
    public TimeCounterUI timeCounter;
    public Text score1P, score2P, gameCount;
	public Animator canvasAnim;

	// Use this for initialization
	void Start () {
		StartCoroutine (coroutineWork());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator coroutineWork(){
        int i = 0;
		yield return new WaitForSecondsRealtime(1);
        foreach (MiniGame mg in minigames)
        {
            //UIの更新
            textbox.text = mg.name;
            score1P.text = Commander.score[0].ToString();
            score2P.text = Commander.score[1].ToString();
            gameCount.text = i.ToString();

            //読み込み始めるけど表示はしない
            AsyncOperation async = SceneManager.LoadSceneAsync(mg.sceneName,LoadSceneMode.Additive);
            async.allowSceneActivation = false;
            yield return new WaitForSecondsRealtime(2.5f);
            //yield return async;これつけたら永遠に読み込み終わらないのなんでや
            //4秒経ったらミニゲーム開始
			Commander.InitializeMinigame();
            async.allowSceneActivation = true;
			yield return new WaitForSecondsRealtime(0.5f);
			timeCounter.StartCounting(8);
			Commander.onMinigameStart ();//イベント発行
            yield return new WaitForSecondsRealtime(8);
			Commander.onMinigameEnd ();//イベント発行
			canvasAnim.SetTrigger("Transition");
			yield return new WaitForSecondsRealtime(1);
            SceneManager.UnloadSceneAsync(mg.sceneName);
            //ミニゲーム終了後
            i++;
            Commander.AddScore();
        }
        textbox.text = "終わり";
	}
}
