﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void setVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume); //Sets the master volume when the slider is changed
    }
}