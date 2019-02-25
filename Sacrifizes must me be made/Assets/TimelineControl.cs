using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineControl : MonoBehaviour {
    public float lenght;
    public int scene;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1.5f;
        GetComponent<PlayableDirector>().Play();
        StartCoroutine("c");
        
	}
    IEnumerator c()
    {
        yield return new WaitForSeconds(lenght);
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
	
	
}
