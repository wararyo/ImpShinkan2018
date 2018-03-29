using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachigaiChoice : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnChoiced() {
        Debug.Log(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void OnReleased() {
        Debug.Log(0);
        GetComponent<SpriteRenderer>().color = Color.black * 0.1f;
    }

    public IEnumerator OnClear() {
        int moveFrame = 10;
        Vector3 dir = (new Vector3(-1, 1, 0) - transform.position) / moveFrame;
        for(int i = 0; i < moveFrame; i++) {
            transform.position += dir;
            yield return null;
        }
        float time = 0;
        Vector3 base_pos = transform.position;
        while (true) {
            transform.position = base_pos + Vector3.up * Mathf.Abs(Mathf.Sin(time * 10)) * 1.5f;
            time += Time.deltaTime;
            yield return null;
        }
    }
}
