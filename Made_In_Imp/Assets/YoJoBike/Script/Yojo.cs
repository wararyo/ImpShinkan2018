using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Yojo : MonoBehaviour {
	
	public GameObject endPosition;

	public UnityEvent hitEndPosition,hitObject;

	public float moveSpeed = 0.5f;
	private Vector3 position;
	private Vector3[] lanePosition = new Vector3[3];
	private float playerStartPositionY;
	private int laneNum = 1;


    public Sprite right,left,forward;
    new SpriteRenderer renderer;

    AudioSource hit;
   

    // Use this for initialization
    void Start () {

		playerStartPositionY = gameObject.transform.position.y;

        renderer = GetComponent<SpriteRenderer>();
        hit = GetComponent<AudioSource>();
		lanePosition [0] = new Vector3(-2.8f,playerStartPositionY,0);
		lanePosition [1] = new Vector3(0,playerStartPositionY,0);
		lanePosition [2] = new Vector3(2.8f,playerStartPositionY,0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveYojo(float x){
        if (x < 0)
        {
            renderer.sprite = right;
			laneNum--;
			renderer.sprite = forward;

        }
        else if (x > 0)
        {
            renderer.sprite = left;
			laneNum++;
			renderer.sprite = forward;
        }
        else
        {
            renderer.sprite = forward;
        }
		laneNum = Mathf.Clamp (laneNum, 0, 2);
		gameObject.transform.position = lanePosition [laneNum];
	}

	private void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject == endPosition) {
			Debug.Log ("hit");
			hitEndPosition.Invoke ();
		} else {
			Debug.Log ("Failed");
			hitObject.Invoke ();
            hit.Play();
		}
	}
}
