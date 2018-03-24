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

	static Commander(){
		result = new resultState[2]{ resultState.Undefined, resultState.Undefined };
	}

	public static void Succeed(int player) {
		result [player] = resultState.Succeed;
	}

	public static void Failed(int player) {
		result [player] = resultState.Failed;
	}
}
