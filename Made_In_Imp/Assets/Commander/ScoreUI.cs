using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ScoreUI : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void setScore(int score)
    {
        var t = GetComponent<Text>();
        if (t.text != score.ToString())
        {
            t.text = score.ToString();
            GetComponent<Animator>().SetTrigger("Added");
        }
    }
}
