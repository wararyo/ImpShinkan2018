using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RakkaPlayer : MonoBehaviour {

    public GameObject player;
    public float rakkaSpeed = 1;
	private float moveSpeed = 0.1f;
	public GameObject ground;
	public UnityEvent land;
	public UnityEvent failed;

	private Vector3 position;

	private bool coroutineRunning = false;

    AudioSource se;

	public Sprite succeeded;
	new SpriteRenderer renderer;

    // Use this for initialization
    void Start () {
        se = GetComponent<AudioSource>();
		renderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}


    public void Rakka()
    {
        player.transform.position += Vector3.down * rakkaSpeed * Time.deltaTime;
    }

	public void MovePlayer(float x)
    {
		player.transform.position += new Vector3 (x*moveSpeed, 0, 0);
		position = player.transform.position;
		position.x = Mathf.Clamp (position.x, -2.8f, 2.8f);
		player.transform.position = position;
    }

	IEnumerator SucceededMotionCoroutine(){
		if (coroutineRunning)
			yield break;
		coroutineRunning = true;
		for (int i = 0; i < 2; i++) {
			player.transform.position += Vector3.up;
			yield return new WaitForSeconds (0.2f);
			player.transform.position += Vector3.down;
			yield return new WaitForSeconds (0.3f);
		}
	}

	private void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject == ground) {
			//成功
			land.Invoke ();
			renderer.sprite = succeeded;
			StartCoroutine (SucceededMotionCoroutine());
		}else{
			//失敗
			failed.Invoke();
		}
        se.Play();
	}
}
