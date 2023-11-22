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
            sounds.Add("button",audioClips[1]);
            sounds.Add("win",audioClips[2]);
            sounds.Add("fail",audioClips[3]);
            sounds.Add("checkpoint",audioClips[4]);
        }

        public void PlaySound(string soundName)
        {
            AudioSource.PlayClipAtPoint(sounds.Get(soundName),gameObject.transform.position);
            Debug.Log("yes");
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


