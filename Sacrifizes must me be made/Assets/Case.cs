using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Case")]
public class Case : ScriptableObject {

    public SkinID[] skins;
    public int cost = 10;
}
