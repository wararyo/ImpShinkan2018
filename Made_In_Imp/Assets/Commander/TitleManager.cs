using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("1A")) {
			//シーンの遷移とフェードを管理するオブジェクトの作成
			new GameObject().AddComponent<SceneNavigator>(); 
			//シーンの遷移&フェード
			SceneNavigator.Instance.Change("main",1);
		}
	}
}
