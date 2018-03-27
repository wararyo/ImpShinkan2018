using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyakurikuManager : MonoBehaviour {

    public Ground ground1,ground2;
    public RakkaPlayer player1, player2;
    
	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        ground1.RotateGround();
        ground2.RotateGround();
        player1.Rakka();
        player2.Rakka();
    }
}
