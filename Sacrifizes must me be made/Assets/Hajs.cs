using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hajs : MonoBehaviour {

    public int hajs;
    public Text score;
    void Update()
    {
        score.text = hajs.ToString();
    }
}
