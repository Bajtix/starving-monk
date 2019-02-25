using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public Sound[] sounds;
    
    public void Sound(int id)
    {
        sounds[id].Play();
    }
}
