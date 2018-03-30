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


    public Sprite[] character = new Sprite[3];
    new SpriteRenderer renderer;

    AudioSource hit;
   

    // Use this for initialization
    void Start () {

		playerStartPositionY = gameObject.transform.position.y;

        renderer = GetComponent<SpriteRenderer>();
        hit = GetComponent<AudioSource>();
		lanePosition [0] = new Vector3(-3f,playerStartPositionY,0);
		lanePosition [1] = new Vector3(0,playerStartPositionY,0);
		lanePosition [2] = new Vector3(3f,playerStartPositionY,0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveYojo(float x){
        if (x < 0)
        {
			laneNum--;

        }
        else if (x > 0)
        {
			laneNum++;
        }
		laneNum = Mathf.Clamp (laneNum, 0, 2);
		gameObject.transform.position = lanePosition [laneNum];
        renderer.sprite = character[laneNum];
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
