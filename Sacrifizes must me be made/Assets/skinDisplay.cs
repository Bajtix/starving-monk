using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class skinDisplay : MonoBehaviour {

    int selectedSkin = 0;
    string content;
    string[] resultContent;
    int[] ids;
    public SkinID[] skins;
    public GameObject floor;
    Text name;
    float t = 0;
    Vector3 b;
    Vector3 f;
    private void Awake()
    {
        SwipeDetector.OnSwipe += nextSkin;
        
    }
    void Start () {
        name = GameObject.Find("name").GetComponent<Text>();
        if (File.Exists(Application.persistentDataPath + "uskin.nfo"))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "uskin.nfo");
            content = sr.ReadLine();
            sr.Close();
            Debug.Log(content);
            resultContent = content.Split(',');
            ids = new int[resultContent.Length];
            for (int i = 0; i < resultContent.Length; i++)
            {
                ids[i] = int.Parse(resultContent[i]);
                Debug.Log("Loaded skins:"+ids[i]);
            }
            int x = 0;
            foreach (int id in ids)
            {
                
                
                Debug.Log(id);
                Instantiate(floor, new Vector3(x, 2, 1),Quaternion.identity);
                GameObject m =Instantiate(skins[id].skin.monk,new Vector3(x + skins[id].skin.monk.transform.position.x * 3, 0 + skins[id].skin.monk.transform.position.y * 3,0),Quaternion.identity);
                m.transform.localScale = new Vector3(9, 9, 1);
                x += 5;
                
            }
        }
        else
        {
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "uskin.nfo");
            sw.Write("0");
            sw.Close();
        }

        StreamReader skinl = new StreamReader(Application.persistentDataPath + "/selectdSkin.nfo");
        selectedSkin = int.Parse(skinl.ReadLine());
        skinl.Close();
        b = new Vector3(selectedSkin * 5, 0, -10);
        f = new Vector3(selectedSkin * 5, 0, -10);
    }

    void nextSkin(SwipeData data)
    {
        if (data.Direction == SwipeDirection.Left && selectedSkin < ids.Length - 1)
            selectedSkin++;
        if (data.Direction == SwipeDirection.Right && selectedSkin > 0)
            selectedSkin--;

        f = new Vector3(selectedSkin * 5, 0, -10);
        b = Camera.main.transform.position;
        t = 0;
    }

    private void Update()
    {
        SwipeData l = new SwipeData();
        l.Direction = SwipeDirection.Left;
        SwipeData r = new SwipeData();
        r.Direction = SwipeDirection.Right;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            nextSkin(l);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            nextSkin(r);

        t += 2f * Time.deltaTime;
        Camera.main.transform.position = Vector3.Lerp(b,f,t);
        name.text = skins[selectedSkin].name;
    }

    public void Select()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/selectdSkin.nfo");
        sw.Write(selectedSkin);
        sw.Close();
        SceneManager.LoadScene(0);
    }


}
