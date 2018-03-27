using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakkaPlayer : MonoBehaviour {

    public GameObject player;
    public float rakkaSpeed = 1;

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
}
