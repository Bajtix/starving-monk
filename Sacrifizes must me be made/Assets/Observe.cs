using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observe : MonoBehaviour {

    public Vector3 offset;
    public Transform target;

	void Update () {
        if(target != null)
        transform.position = new Vector3(0, target.position.y + offset.y, transform.position.z);
        
	}
}
