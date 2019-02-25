using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;

public class DzwiekiMnicha : MonoBehaviour {
    public AudioMixer am;
	
	void Start () {
        if (File.Exists(Application.persistentDataPath + "/settingData.setdat"))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/settingData.setdat");
            string x = sr.ReadLine();
            am.SetFloat("mainVolume", float.Parse(x));
            
            sr.Close();
            
        }
        
	}
	
	
}
