using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CabbageCabbage : MonoBehaviour {

	int cutCount = 0;
	[System.NonSerialized()]
	public int cutCountGoal = 40;
	public UnityEvent onCutAll;

	public List<Sprite> cabbageSprites;

	bool isCutAll = false;

	SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Cut() {
		cutCount++;
		int spriteIndex = (int)Mathf.Lerp (0, cabbageSprites.Count - 1, (float)cutCount / cutCountGoal);
		//Debug.Log (hoge);
		renderer.sprite = cabbageSprites [spriteIndex];
		if (cutCountGoal <= cutCount) {
			if (isCutAll == false) {
				onCutAll.Invoke ();
				isCutAll = true;
			}
		}
	}
}
