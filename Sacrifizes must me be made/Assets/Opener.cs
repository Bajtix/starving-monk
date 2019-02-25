using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Opener : MonoBehaviour {
    GameObject caseAnimator;
    int destinationSkin = 0;
    int wonskin = 0;
    string skins;
    int[] ownedSkins;


    Vector3 bef;
    Vector3 des;
    float t;
    private void Start()
    {
        caseAnimator = GameObject.Find("caseAnimator");
    }
    public void open(Case c)
    {
        for(int c_ = 0; c_<caseAnimator.transform.childCount; c_++)
        {
            Destroy(caseAnimator.transform.GetChild(c_).gameObject);
        }
        int summoned = 0;
        for(int i = 0; i < 4; i++)
        foreach(SkinID id in c.skins)
        {
            
            GameObject x = Instantiate(id.skin.monk,caseAnimator.transform);
            x.transform.localPosition = new Vector3(summoned * 5 + id.skin.monk.transform.position.x * 5, id.skin.monk.transform.position.y * 5, 0);
            x.transform.localScale = new Vector3(15, 15, 0);
            
            summoned++;
        }
        StreamReader sr = new StreamReader(Application.persistentDataPath + "uskin.nfo");
        skins = sr.ReadLine();
        sr.Close();
        ownedSkins = new int[skins.Split(',').Length];
        int ll = 0;
        foreach(string s in skins.Split(','))
        {
            ownedSkins[ll] = int.Parse(s);
            ll++;
        }
        /*int skinId;
        foreach(SkinID id in c.skins)
        {
            if(id.id == )
        }*/


        destinationSkin = Random.Range(0, summoned);
        wonskin = destinationSkin % c.skins.Length;
        Debug.Log(wonskin);
        Debug.Log(destinationSkin + "%" + c.skins.Length);
        t = 0;
        bef = new Vector3(0, 0, 0);
        des = new Vector3(destinationSkin*-5,0,0);
        

    }
    private void Update()
    {
        caseAnimator.transform.position = Vector3.Lerp(bef, des, t);
        t += 2f * Time.deltaTime;
    }
}
