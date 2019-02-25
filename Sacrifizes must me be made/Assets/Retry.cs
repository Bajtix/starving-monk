using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour {

	public void Reload(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
