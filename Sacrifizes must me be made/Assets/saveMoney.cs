using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class saveMoney : MonoBehaviour {
    int unihajs;
    Hajs mnich;
    
    void Start()
    {
        mnich = GameObject.Find("Mnich").GetComponent<Hajs>();

        if (File.Exists(Application.persistentDataPath + "/s"))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/s");
            unihajs = Int32.Parse(sr.ReadLine());
            sr.Close();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(Application.persistentDataPath + "-saved " + (unihajs + mnich.hajs / 2).ToString());
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/s");
        unihajs = unihajs + mnich.hajs / 2;
        mnich.hajs = 0;
        sw.Write(unihajs);
        sw.Close();
    }
}
