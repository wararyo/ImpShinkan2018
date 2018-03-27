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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GameCoroutine() {
        //上バンズ以外の具材の順番をシャッフル
        var order = new int[] { 0, 1, 2, 3, 4, 5, 6 }.OrderBy(i => System.Guid.NewGuid()).Concat(new int[] { 7 }).ToArray();
        for (int i = 0; i < order.Length; i++) {
            ProvideGu(order[i]);
            yield return new WaitForSeconds(1);
        }
        JudgeResult();
    }

    void ProvideGu(int index) {
        Vector3 pos = new Vector3(Random.Range(-4, 4), 6, 0);
        GameObject obj = Instantiate(gu_obj, transform);
        obj.layer = gameObject.layer;
        obj.transform.position = pos;
        var sr = obj.GetComponent<SpriteRenderer>();
        sr.sprite = gu_sprites[index];
        var col = obj.GetComponent<BoxCollider2D>();
        col.size = new Vector2(sr.bounds.size.x * 0.5f, sr.bounds.size.y * 0.5f);
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
