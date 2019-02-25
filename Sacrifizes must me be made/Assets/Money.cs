using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {
    Hajs mnich;
    bool dajehajs;
    public GameObject coin;
    public GameObject particles;
    public GameObject deadmnich;
    GameObject curr;
    bool mapiniondz = false;
    bool mozehajs;
    GameObject x;

    public GameObject deathHolder;
    public Text score;
    public Text message;

    RectTransform rt;

    void Start()
    {
        mnich = GameObject.Find("Mnich").GetComponent<Hajs>();

        deathHolder = GameObject.Find("death");
        score = GameObject.Find("death").transform.GetChild(0).Find("score").gameObject.GetComponent<Text>();
        message = GameObject.Find("death").transform.GetChild(0).Find("msg").gameObject.GetComponent<Text>();

        if (UnityEngine.Random.Range(0, 5) < 3)
            mozehajs = true;
        else
            mozehajs = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (dajehajs && mnich != null)
        {
            mnich.hajs += 1;
            Destroy(x);
            Camera.main.GetComponent<AudioPlayer>().Sound(0);
        }
        else
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/s");

            message.text = generateDeathMessage(Int32.Parse(sr.ReadToEnd()));
            score.text = sr.ReadToEnd();
            StartCoroutine("showUi");
            sr.Close();
            mnich.GetComponent<Run>().un();
            curr = Instantiate(particles, mnich.transform.position + new Vector3(0, 2), Quaternion.identity);
            Instantiate(deadmnich, mnich.transform.position, Quaternion.identity);
            Destroy(mnich.gameObject);
            Destroy(curr, 3);
            Camera.main.transform.Find("music").GetComponent<AudioSource>().Stop();
            Camera.main.GetComponent<AudioPlayer>().Sound(1);

        }
        
    }
    void Update()
    {
        
        if(mozehajs && mnich!=null)
            if (Vector2.Distance(mnich.gameObject.transform.position, transform.position) < 15)
                dajehajs = true;


        if (dajehajs && !mapiniondz)
        {
            mapiniondz = true;
           x =  Instantiate(coin, transform.position + new Vector3(0,2,0), Quaternion.identity);
        }
    }
    IEnumerator showUi()
    {
        yield return new WaitForSeconds(2);
        deathHolder.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }
    string generateDeathMessage(int score)
    {
        int x = UnityEngine.Random.Range(1, 3);
        if (score < 10)
        {
            if (x == 1)
                return "I'm not sure you won't starve.";
            if (x == 2)
                return "Need more money...";
            if (x == 3)
                return "It could have been worse.....";
        }
        if (score >= 10 && score < 30)
        {
            if (x == 1)
                return "At least I will eat something...";
            if (x == 2)
                return "Still need more.";
            if (x == 3)
                return "For bread it's enought";
        }
        if (score >= 30 && score < 50)
        {
            if (x == 1)
                return "Now I can share the bread with the pidgeons.";
            if (x == 2)
                return "Maybe I cannot buy a horse, but it's always something";
            if (x == 3)
                return "Not bad";

        }
        if (score >= 50 && score < 100)
        {
            return "Now we are talking";
        }
        if (score >= 100)
        {
            if (x == 1)
                return "Now I can feel like Father Rydzyk!";
            if (x == 2)
                return "I'll start Radio Maryja.";
            if (x == 3)
                return "\"But i feel like a millionare...\"";
        }
        return "";
    }
}
