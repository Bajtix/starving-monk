using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSet : MonoBehaviour {
    public AudioMixer am;
    void Start()
    {
        float x;
        am.GetFloat("mainVolume", out x);
        GetComponent<UnityEngine.UI.Slider>().value = x;
    }
    public void change(float value)
    {
        am.SetFloat("mainVolume", value);
    }
}
