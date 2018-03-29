using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMiniGame.asset", menuName = "MiniGame Definition", order = 1)]
public class MiniGame : ScriptableObject {

    new public string name;
    public Sprite orderImage;
    public string sceneName;
}
