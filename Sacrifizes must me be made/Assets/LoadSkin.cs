using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class LoadSkin : MonoBehaviour {
    string pth;
    int skin = 0;
    public SkinID[] skins;
    private void Start()
    {
        pth = Application.persistentDataPath + "/selectdSkin.nfo";
        if (File.Exists(pth))
        {
            StreamReader sr = new StreamReader(pth);
            skin = int.Parse(sr.ReadLine());
            sr.Close();
        }
        foreach(SkinID s in skins)
        {
            if (s.id == skin)
                s.skin.Load();
        }

    }
}
