using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Commander {

	enum resultState {
		Undefined,
		Succeed,
		Failed
	}

	static resultState[] result;
    static public int[] score;

	public static Action onMinigameEnd = () => {};

	/// <summary>
	/// 全体の初期化 スコアが0になります
	/// </summary>
    public static void Initialize()
    {
        ResetResultState();
        for (int i = 0; i < score.Length; i++)
        {
            score[i] = 0;
        }
    }

	/// <summary>
	/// 各ミニゲームの初期化
	/// </summary>
	public static void InitializeMinigame(){
		ResetResultState ();
		onMinigameEnd = () => {};
	}

    static void ResetResultState()
    {
        for (int i = 0;i < result.Length;i++)
        {
            result[i] = resultState.Undefined;
        }
    }

	static Commander(){
		result = new resultState[2]{ resultState.Undefined, resultState.Undefined };
        score = new int[2] { 0, 0 };
        Initialize();
	}

	public static void Succeed(int player) {
		if (result [player] == resultState.Undefined)
			result [player] = resultState.Succeed;
	}

	public static void Failed(int player) {
		if (result [player] == resultState.Undefined)
			result [player] = resultState.Failed;
	}

    public static void AddScore()
    {
        if (result[0] == resultState.Succeed) score[0]++;
        if (result[1] == resultState.Succeed) score[1]++;
    }
}
