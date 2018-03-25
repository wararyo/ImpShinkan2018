using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMiniGame.asset", menuName = "MiniGame Definition", order = 1)]
public class MiniGame : ScriptableObject {

    public string name;
    public Sprite orderSprite;
    public string sceneName;
}
