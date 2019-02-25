

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorInstantiation : MonoBehaviour {

    public GameObject floor;

    public GameObject[] przeszkody;

    public float a;
    public float b;
	void Start () {
        for (int i = 0; i < 400; i++)
        {
            Instantiate(floor, new Vector3(0, i * 20.5f, 0), Quaternion.identity);
        }

        for(int i = 10; i< 400; i++)
        {
            Instantiate(przeszkody[Random.Range(0, przeszkody.Length)], new Vector3(Random.Range(-1, 2) * a, i * 10 + 45, -2), Quaternion.identity);
            if(Random.Range(0,1) == 1)
                Instantiate(przeszkody[Random.Range(0, przeszkody.Length)], new Vector3(Random.Range(-1, 2) * a, i * 10 + 15, -2), Quaternion.identity);
            if(Random.Range(0,2)==1)
                Instantiate(przeszkody[Random.Range(0, przeszkody.Length)], new Vector3(Random.Range(-1, 2) * a, i * 10, -2), Quaternion.identity);
        }
	}
	
	
}
