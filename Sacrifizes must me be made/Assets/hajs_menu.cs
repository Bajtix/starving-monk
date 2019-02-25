using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class hajs_menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(File.Exists(Application.persistentDataPath + "/s"))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/s");
            GetComponent<UnityEngine.UI.Text>().text = sr.ReadLine();
            sr.Close();
        }
	}
	
	
}
