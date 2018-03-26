using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Commander {

	enum resultState {
		Undefined,
		Succeed,
		Failed
	}

	static resultState[] result;
    static public int[] score;

    public static void Initialize()
    {
        ResetResultState();
        for (int i = 0; i < score.Length; i++)
        {
            score[i] = 0;
        }
    }

    public static void ResetResultState()
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
		result [player] = resultState.Succeed;
	}

	public static void Failed(int player) {
		result [player] = resultState.Failed;
	}

    public static void AddScore()
    {
        if (result[0] == resultState.Succeed) score[0]++;
        if (result[1] == resultState.Succeed) score[1]++;
    }
}
