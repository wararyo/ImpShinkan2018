using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RakkaPlayer : MonoBehaviour {

    public GameObject player;
    public float rakkaSpeed = 1;
	public GameObject ground;
	public UnityEvent land;
	public UnityEvent failed;

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

    public void MovePlayer()
    {
  
    }


	private void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("hi");
		if (col.gameObject == ground) {
			//成功
			land.Invoke ();
		} else {
			//失敗
			failed.Invoke();
		}
	}
}
