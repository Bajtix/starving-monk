using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomImage : MonoBehaviour {
    public Sprite[] images;
	// Use this for initialization
	void Start () {
        GetComponent<Image>().sprite = images[Random.Range(0, images.Length - 1)];
	}
	
	
}
