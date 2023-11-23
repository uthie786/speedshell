using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;
    [SerializeField] private AudioClip[] audioClips;
    private HashMap<string, AudioClip> sounds = new HashMap<string, AudioClip>();
    public AudioSource auSource;

    public float[] volumes;
   
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
            
        sounds.Add("BackgroundMusic",audioClips[0]);
      
    }

    public void PlaySound(string soundName)
    {
        auSource.PlayOneShot(sounds[soundName],volumes[Array.IndexOf(audioClips,sounds[soundName])]);
        Debug.Log("Audio");
    }
}
