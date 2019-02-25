using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class Przeszkoda : MonoBehaviour {
    GameObject mnich;
    public GameObject deadmnich;
    public GameObject particles;
    GameObject curr;

    public GameObject deathHolder;
    public Text score;
    public Text message;

    RectTransform rt;
    void Start()
    {

        mnich = GameObject.Find("Mnich");
        deathHolder = GameObject.Find("death");
        score = GameObject.Find("death").transform.GetChild(0).Find("score").gameObject.GetComponent<Text>();
        message = GameObject.Find("death").transform.GetChild(0).Find("msg").gameObject.GetComponent<Text>();

        deathHolder.GetComponent<RectTransform>().localPosition = new Vector2(100, 10000);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Mnich")
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/s");
            string scoreR = sr.ReadLine();
            message.text = generateDeathMessage(Int32.Parse(scoreR));
            score.text = scoreR;
            StartCoroutine("showUi");
            curr = Instantiate(particles, mnich.transform.position + new Vector3(0, 2), Quaternion.identity);
            Instantiate(deadmnich, mnich.transform.position, Quaternion.identity);
            mnich.GetComponent<Run>().un();
            sr.Close();
            Destroy(mnich);
            Destroy(curr, 3);
            Camera.main.transform.Find("music").GetComponent<AudioSource>().Stop();
            Camera.main.GetComponent<AudioPlayer>().Sound(1);
        }
        else
            Destroy(collision.gameObject);






    }

   
    IEnumerator showUi()
    {
        yield return new WaitForSeconds(2);
        deathHolder.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }

    string generateDeathMessage(int score)
    {
        int x = UnityEngine.Random.Range(1,3);
        if (score < 10)
        {
            if (x == 1)
                return "I'm not sure you won't starve.";
            if (x == 2)
                return "Need more money...";
            if (x == 3)
                return "It could have been worse.....";
        }
        if(score >= 10 && score < 30)
        {
            if(x == 1)
                return "At least I will eat something...";
            if (x == 2)
                return "Still need more.";
            if (x == 3)
                return "For bread it's enought";
        }
        if (score >= 30 && score < 50)
        {
            if(x == 1)
                return "Now I can share the bread with the pidgeons.";
            if (x == 2)
                return "Maybe I cannot buy a horse, but it's always something";
            if (x == 3)
                return "Not bad";

        }
        if(score >= 50 && score < 100)
        {
            return "Now we are talking";
        }
        if(score >= 100)
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
