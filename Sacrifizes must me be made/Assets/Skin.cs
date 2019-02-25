using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Skin")]
public class Skin : ScriptableObject{

    public GameObject monk;

    public void Load()
    {
        Instantiate(monk, GameObject.Find("Mnich").transform);
    }
	
}
