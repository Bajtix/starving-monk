using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {
    float t;
    float xbef;
    float a;
    public float speed;
    public int tor;
    public GameObject mnich;
    public float y;
    bool _a;
    bool _s;
    bool _d;
    int presses;
    float nt;
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }
    void SwipeDetector_OnSwipe(SwipeData data)
    {
        if (data.Direction == SwipeDirection.Left && tor > -1)
        {
            xbef = mnich.transform.position.x;
            t = 0;
            tor--;
        }
        if (data.Direction == SwipeDirection.Right && tor < 1)
        {
            xbef = mnich.transform.position.x;
            t = 0;
            tor++;
        }

    }
    public void A()
    {
        presses++;
        Debug.LogWarning(presses);
        nt = Time.time + 0.2f;
        if(presses >= 2)
            _a = true;
    }
    public void S()
    {
        _s = true;

    }
    public void D()
    {
        presses++;
        Debug.LogWarning(presses);
        nt = Time.time + 0.2f;
        if (presses >= 2)
            _d = true;
    }
	void Update () {
        if (nt < Time.time)
            presses = 0;
        mnich.transform.position = new Vector3(a, y, -2);
        y += speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A) || _a)
        {
            xbef = mnich.transform.position.x;
            t = 0;
            tor = -1;
            _a = false;
        }
        else
            if (Input.GetKeyDown(KeyCode.D) || _d)
            {
                xbef = mnich.transform.position.x;
                t = 0;
                tor = 1;
            _d = false;
            }
        else
            if (Input.GetKeyDown(KeyCode.S) || _s)
            {
                xbef = mnich.transform.position.x;
                t = 0;
                tor = 0;
            _s = false;
            }



        a = Mathf.Lerp(xbef, tor * 5, t);
        t += 7 * Time.deltaTime;
        
	}
    public void un()
    {
        SwipeDetector.OnSwipe -= SwipeDetector_OnSwipe;
    }
}
