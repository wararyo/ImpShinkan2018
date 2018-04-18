using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {

    public List<MiniGame> minigames;
    public Text textbox;
    public TimeCounterUI timeCounter;
    public ScoreUI score1P, score2P;
    public Text gameCount;
	public Animator canvasAnim;
    public Image orderImage;
    public Sprite backSucceed1, backFailed1, backSucceed2, backFailed2;
    public Image backLeft, backRight;
	public Animator character1,character2;
	public AudioSource se1, se2;
    public Sprite A, Cross, Horizontal;
    public Image buttonImage;

	// Use this for initialization
	void Start () {
		StartCoroutine (coroutineWork());
		Commander.onMinigameSucceed += (p) => {
			if(p == 0) se1.Play();
			else se2.Play();
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator coroutineWork(){
        int i = 1;
		character1.SetBool ("Succeed", true);
		character2.SetBool ("Succeed", true);
		canvasAnim.Play ("Start");
		yield return new WaitForSecondsRealtime(4);
		character1.SetBool ("Succeed", false);
		character2.SetBool ("Succeed", false);
        foreach (MiniGame mg in minigames)
        {
			//読み込み始めるけど表示はしない
			AsyncOperation async = SceneManager.LoadSceneAsync(mg.sceneName,LoadSceneMode.Additive);
			async.allowSceneActivation = false;

            gameCount.text = i.ToString();
            orderImage.sprite = mg.orderImage;

            if (mg.buttonUsage == MiniGame.ButtonUsage.A) buttonImage.sprite = A;
            else if (mg.buttonUsage == MiniGame.ButtonUsage.Horizontal) buttonImage.sprite = Horizontal;
            else if (mg.buttonUsage == MiniGame.ButtonUsage.Cross) buttonImage.sprite = Cross;

            character1.SetBool ("Succeed", false);
			character2.SetBool ("Succeed", false);
			character1.SetBool ("Failed", false);
			character2.SetBool ("Failed", false);

			yield return new WaitForSecondsRealtime(1.5f);
            //yield return async;これつけたら永遠に読み込み終わらないのなんでや
            //4秒経ったらミニゲーム開始
			Commander.InitializeMinigame();
            async.allowSceneActivation = true;
			yield return new WaitForSecondsRealtime(0.5f);
			timeCounter.StartCounting(8);
			Commander.onMinigameStart ();//イベント発行
            yield return new WaitForSecondsRealtime(8);
			Commander.onMinigameEnd ();//イベント発行
            //背景とキャラクターの更新
            backLeft.sprite = Commander.result[0] == Commander.resultState.Succeed ? backSucceed1 : backFailed1;
            backRight.sprite = Commander.result[1] == Commander.resultState.Succeed ? backSucceed2 : backFailed2;
			if(Commander.result[0] == Commander.resultState.Succeed) character1.SetBool ("Succeed", true);
			else character1.SetBool ("Failed", true);
			if(Commander.result[1] == Commander.resultState.Succeed) character2.SetBool ("Succeed", true);
			else character2.SetBool ("Failed", true);
			if (i == minigames.Count)
				canvasAnim.Play ("End");
			else canvasAnim.SetTrigger("Transition");
			yield return new WaitForSecondsRealtime(1);
            SceneManager.UnloadSceneAsync(mg.sceneName);
            //ミニゲーム終了後
            i++;
            Commander.AddScore();

			//点数の更新
			textbox.text = mg.name;
			score1P.setScore(Commander.score[0]);
			score2P.setScore(Commander.score[1]);
			yield return new WaitForSecondsRealtime(1f);
        }
		character1.SetBool ("Succeed", false);
		character2.SetBool ("Succeed", false);
		character1.SetBool ("Failed", false);
		character2.SetBool ("Failed", false);
		yield return new WaitForSecondsRealtime(4);
		new GameObject().AddComponent<SceneNavigator>();
		SceneNavigator.Instance.Change("Result",1);
	}
}
