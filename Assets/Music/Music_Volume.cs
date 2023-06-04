using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Volume : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 0.5f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }
    public void SetVolume(float vol){
        musicVolume = vol;
    }
}
