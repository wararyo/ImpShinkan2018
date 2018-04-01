using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HamburgerManager : MonoBehaviour {

    public List<Sprite> gu_sprites;
    public GameObject gu_obj;
    List<HamburgerGu> gu_set = new List<HamburgerGu>();
    public int playerNum;

	// Use this for initialization
	void Start () {
        StartCoroutine(GameCoroutine());
		Commander.onMinigameEnd += () => {
			JudgeResult();//全部具材が乗ったか判定 
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GameCoroutine() {
        //上バンズ以外の具材の順番をシャッフル
        var order = new int[] { 0, 1, 2, 3, 4, 5, 6 }.OrderBy(i => System.Guid.NewGuid()).Concat(new int[] { 7 }).ToArray();
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < order.Length; i++) {
            ProvideGu(order[i], i);
            yield return new WaitForSeconds(0.8f);　//一定間隔に...
        }
        //JudgeResult(); //全部具材が乗ったか判定
    }

    void ProvideGu(int index, int layer) {
		
        //具生成
        Vector3 pos = new Vector3(Random.Range(-3.6f, 3.6f), 6, 0);
        GameObject obj = Instantiate(gu_obj, transform);
        obj.layer = gameObject.layer;
        obj.transform.position = pos;
        var sr = obj.GetComponent<SpriteRenderer>();
        sr.sprite = gu_sprites[index];
        var col = obj.GetComponent<BoxCollider2D>();
		sr.sortingOrder = 10 + layer;
        //具の大きさによって当たり判定調整
        col.size = new Vector2(sr.bounds.size.x * 0.8f, sr.bounds.size.y * 0.65f);
        col.offset += Vector2.up * sr.bounds.size.y * 0.2f;
        gu_set.Add(col.GetComponent<HamburgerGu>());
    }

    void JudgeResult() {
        for(int i = 0; i < gu_set.Count; i++) {
            if (!gu_set[i].isCatched) {
                Commander.Failed(playerNum);
                return;
            }
        }
        Commander.Succeed(playerNum);
    }
}
