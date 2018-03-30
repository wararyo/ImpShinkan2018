using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour {

	public MazePlayer player1;
	public MazePlayer player2;
    public SpriteRenderer thankyou1, thankyou2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player1.Move (Input.GetAxisRaw ("1Horizontal"),Input.GetAxisRaw("1Vertical"));
		player2.Move (Input.GetAxisRaw ("2Horizontal"),Input.GetAxisRaw("2Vertical"));
	}

	public void Succeed1P(){
		Commander.Succeed (0);
        thankyou1.enabled = true;
	}

	public void Succeed2P(){
		Commander.Succeed (1);
        thankyou2.enabled = true;
    }
}
