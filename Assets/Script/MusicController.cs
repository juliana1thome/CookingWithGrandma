using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    public AudioMixer mixer;

    public void AudioSetter(float slide)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(slide) * 20);
    }
}
