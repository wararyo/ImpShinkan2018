using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TyakurikuManager : MonoBehaviour {

    public Ground ground1,ground2;
    public RakkaPlayer player1, player2;

	private bool tyakuriku1P,tyakuriku2P;

	// Use this for initialization
	void Start () {
		tyakuriku1P = false;
		tyakuriku2P = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (tyakuriku1P == false) {
			ground1.RotateGround();
			player1.Rakka();
		}
       
		if (tyakuriku2P == false) {
			ground2.RotateGround();
			player2.Rakka();
		}
    }

	public void LandEvent1P(){
		Debug.Log ("1P着陸成功");
		tyakuriku1P = true;
		Commander.Succeed (0);
	}

	public void LandEvent2P(){
		Debug.Log ("2P着陸成功");
		tyakuriku2P = true;
		Commander.Succeed (1);
	}

	public void failedEvent1P(){
		Debug.Log ("1P着陸失敗");
		tyakuriku1P = true;
		Commander.Succeed (0);
	}

	public void failedEvent2P(){
		Debug.Log ("2P着陸失敗");
		tyakuriku2P = true;
		Commander.Succeed (1);
	}
}
