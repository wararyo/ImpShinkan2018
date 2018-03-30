using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounterUI : MonoBehaviour {

    public RectTransform progressBar;
    public RectTransform counter;
    public Text text;

    float time = 0;
    float timeCurrent = 0;

    bool isCounting = false;

    float height = 1080;

    void setIsVisible(bool isVisible)
    {
        foreach(var g in GetComponentsInChildren<MaskableGraphic>())
        {
            g.enabled = isVisible;
        }
    }

    public void StartCounting(float time)
    {
        isCounting = true;
        setIsVisible(true);
        this.time = time;
        this.timeCurrent = time;
    }

	// Use this for initialization
	void Start () {
        setIsVisible(false);
	}

	
	// Update is called once per frame
	void Update () {
        if (isCounting)
        {
            timeCurrent -= Time.deltaTime;
            text.text = ((int)timeCurrent + 1.0).ToString();//小数点以下を繰り上げるために+1
            progressBar.localScale = new Vector3(1,timeCurrent/time,1);
            counter.anchoredPosition = new Vector2(0,Mathf.Clamp(Mathf.Lerp(0, height, timeCurrent / time),48,1080-48));
            if(timeCurrent <= 0)
            {
                isCounting = false;
                setIsVisible(false);
            }
        }
	}
}
