using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class MachigaiManager : MonoBehaviour {

    public int playerNum;
    List<MachigaiChoice> choices = new List<MachigaiChoice>();
    MachigaiTarget target;
    public List<Sprite> types_g = new List<Sprite>();
    public GameObject target_obj, choice_obj;
    int nowChoice = 2;
    bool isSelected = false;
    public AudioClip ok_m, ng_m;

    // Use this for initialization
    void Start () {
        QuizSetting();
        for(int i = 0; i < 5; i++) {
            Debug.Log(2);
            if (i == nowChoice) choices[i].OnChoiced();
            else choices[i].OnReleased();
        }
        StartCoroutine(Move());
        StartCoroutine(Select());
        Commander.onMinigameEnd += () => {
            if (!isSelected)
            {
                isSelected = true;
                var ans = target.GetComponent<SpriteRenderer>().sprite;
                var choice = choices[nowChoice].GetComponent<SpriteRenderer>().sprite;
                if (ans == choice) OnClear();
                else OnFailed();
            }
            //StopAllCoroutines();
            //choices[nowChoice].StopAllCoroutines();
            //target.StopAllCoroutines();
        };

    }
	
	// Update is called once per frame
	void Update () { }

    void QuizSetting() {
        var order = new int[] { 0, 1, 2, 3, 4, 5 }.OrderBy(i => System.Guid.NewGuid()).ToArray();
        for(int i = 0; i < 5; i++) {
            var pos = new Vector3(1.6f * (i + 1) - 4.8f, (i + 1) % 2 - 3.5f, 0);
            var obj = Instantiate(choice_obj, transform);
            obj.transform.position = pos;
            obj.GetComponent<SpriteRenderer>().sprite = types_g[order[i]];
            obj.layer = gameObject.layer;
            choices.Add(obj.GetComponent<MachigaiChoice>());
        }
        target = target_obj.GetComponent<MachigaiTarget>();
        target_obj.GetComponent<SpriteRenderer>().sprite = types_g[order[Random.Range(0, 5)]];
    }

    IEnumerator Move() {
        float prevInput = 0;
        while (true) {
            if (isSelected) yield break;
                var v = Input.GetAxisRaw((playerNum + 1).ToString() + "Horizontal");
            if (prevInput == 0 && v != 0) {
                choices[nowChoice].OnReleased();
                nowChoice = (int)Mathf.Max(Mathf.Min(nowChoice + v, 4), 0);
                choices[nowChoice].OnChoiced();
            }
            prevInput = v;
            yield return null;
        }
    }

    IEnumerator Select() {
        while (!Input.GetButtonDown((playerNum + 1).ToString() + "A")) yield return null;
        isSelected = true;
        var ans = target.GetComponent<SpriteRenderer>().sprite;
        var choice = choices[nowChoice].GetComponent<SpriteRenderer>().sprite;
        if (ans == choice) OnClear();
        else OnFailed();
    }

    void OnClear() {
        GetComponent<AudioSource>().clip = ok_m;
        GetComponent<AudioSource>().Play();
        Commander.Succeed(playerNum);
        choices[nowChoice].StartCoroutine(choices[nowChoice].OnClear());
        target.StartCoroutine(target.OnClear());
    }

    void OnFailed() {
        GetComponent<AudioSource>().clip = ng_m;
        GetComponent<AudioSource>().Play();
        Commander.Failed(playerNum);
        target.StartCoroutine(target.OnFailed());
    }
}
