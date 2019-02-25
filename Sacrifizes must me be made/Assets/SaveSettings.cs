using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;

public class SaveSettings : MonoBehaviour {
    public AudioMixer am;
    public void Save()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/settingData.setdat");
        float vol;
        am.GetFloat("mainVolume", out vol);
        sw.Write(vol);
        sw.Close();
        Debug.Log(Application.persistentDataPath);
    }

    
}
