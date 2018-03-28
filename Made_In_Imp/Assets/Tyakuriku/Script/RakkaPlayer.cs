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

	// Use this for initialization
	void Start () {
       
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


	private void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject == ground) {
			//成功
			land.Invoke ();
		}else{
			//失敗
			failed.Invoke();
		}
	}
}
