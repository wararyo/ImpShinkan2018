using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CabbageCabbage : MonoBehaviour {

	int cutCount = 0;
	[System.NonSerialized()]
	public int cutCountGoal = 40;
	public UnityEvent onCutAll;

    public ParticleSystem burst;
    public ParticleSystem sengiri;

    public List<Sprite> cabbageSprites;

	bool isCutAll = false;
    new SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Cut() {
        if (isCutAll == false)
        {
            //ParticleEffect
            burst.Emit(24);
            sengiri.Emit(32);

            cutCount++;
            int spriteIndex = (int)Mathf.Lerp(0, cabbageSprites.Count - 1, (float)cutCount / cutCountGoal);
            //Debug.Log (hoge);
            renderer.sprite = cabbageSprites[spriteIndex];
            if (cutCountGoal <= cutCount)
            {
                onCutAll.Invoke();
                isCutAll = true;
            }
        }
	}
}
