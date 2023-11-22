using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    [SerializeField] private AudioClip[] audioClips;
    private HashMap<string, AudioClip> sounds = new HashMap<string, AudioClip>();
        public SFXManager()
        {
            

        }
        
        private void Awake()
        {
            sounds.Add("Thud",audioClips[0]);
            sounds.Add("Finish",audioClips[1]);
            sounds.Add("Lap",audioClips[2]);
            sounds.Add("Move",audioClips[3]);
            sounds.Add("Cheer",audioClips[4]);
        }

        public void PlaySound(string soundName)
        {
            AudioSource.PlayClipAtPoint(sounds.Get(soundName),gameObject.transform.position);
            //Debug.Log("Audio");
        }

        public static SFXManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SFXManager();
                }

                return instance;
            }
        }
}


