using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanpukuDog : MonoBehaviour {

    public int playerNum;
    int dir = -1; //左向いてるとマイナス、右向いてるとプラス
    bool isJumping = false, isClear = false;
    public int clearCount;
    int c = 0;

    public Sprite left_g, right_g, mofu_g;
    public AudioClip bunbun_se, clear_se;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        Commander.onMinigameEnd += () => {
            if (isClear) Commander.Succeed(playerNum);
            else Commander.Failed(playerNum);
            StopAllCoroutines();
        };
        StartCoroutine(Vibration());
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        var v = Input.GetAxis((playerNum + 1).ToString() + "Horizontal");

        //向いている方向に対して逆方向の入力をした場合、跳ぶ！
		if(!isJumping && !isClear && dir * v < 0) {
            StartCoroutine(Jump());
            if (c >= clearCount) StartCoroutine(Clear());
        }
	}

    IEnumerator Jump() {
        isJumping = true;
        dir *= -1;
        c++;
        audio.clip = bunbun_se;
        audio.Play();
        GetComponent<SpriteRenderer>().sprite = dir > 0 ? right_g : left_g;
        int frame = 10;
        for(int i = 0; i <= frame; i++) {
            Vector3 jumpDir = new Vector3(0.05f * dir, Mathf.Cos(i * (Mathf.PI / frame)) * 0.3f, 0);
            transform.position += jumpDir;
            yield return null;
        }
        isJumping = false;
    }

    IEnumerator Clear() {
        isClear = true;
        audio.clip = clear_se;
        audio.Play();
        GetComponent<SpriteRenderer>().sprite = mofu_g;
        float time = 0f;
        var base_pos = transform.position + Vector3.down;
        while (true) {
            transform.position = base_pos + Vector3.up * Mathf.Max(0, Mathf.Sin(time * 10) * 1.5f);
            time += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Vibration() {
        while (!isClear) {
            Vector3 offset = Quaternion.Euler(Vector3.forward * Random.Range(0, 360)) * Vector3.up * 0.1f;
            transform.position += offset;
            yield return new WaitForSeconds(0.01f);
            transform.position -= offset;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
