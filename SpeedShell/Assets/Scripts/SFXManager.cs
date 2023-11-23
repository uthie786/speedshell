using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
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
            
            sounds.Add("bounce",audioClips[0]);
            sounds.Add("cheer",audioClips[1]);
            sounds.Add("Click",audioClips[2]);
            sounds.Add("LapSound",audioClips[3]);
            sounds.Add("Bump",audioClips[4]);
        }

        public void PlaySound(string soundName)
        {
            auSource.PlayOneShot(sounds[soundName],volumes[Array.IndexOf(audioClips,sounds[soundName])]);
            Debug.Log("Audio");
        }
        
}


