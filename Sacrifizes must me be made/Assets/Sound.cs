using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sound {

    public AudioClip sound;
    public float volume;
    public AudioSource audio;

    public void Play()
    {
        audio.clip = sound;
        audio.volume = volume;

        audio.Play();
    }
}
