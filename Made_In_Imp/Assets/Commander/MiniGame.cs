using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMiniGame.asset", menuName = "MiniGame Definition", order = 1)]
public class MiniGame : ScriptableObject {

    public enum ButtonUsage
    {
        A,
        Cross,
        Horizontal
    }

    new public string name;
    public Sprite orderImage;
    public string sceneName;
    public ButtonUsage buttonUsage;
}
