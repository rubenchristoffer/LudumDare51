using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{

    public Slider audioSlider;

    void Start ()
    {
        AudioListener.volume = audioSlider.value;
    }

    public void ChangeAudio (float newValue) {
        AudioListener.volume = newValue;
    }

}
