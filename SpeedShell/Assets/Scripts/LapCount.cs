using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCount : MonoBehaviour
{
    [SerializeField] private SFXManager sfx;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private Text endText;
    [SerializeField] private Color win;
    [SerializeField] private Image colourOverlay;
    [SerializeField] private Text lapCount;
    public int lapCounter = 0;
    void Start()
    {
        lapCounter = 0;
    }

    void Update()
    {
        if (lapCounter == 4)
        {
            Victory();
        }

        lapCount.text = lapCounter + " /3 Laps";
        /* if (lapCounter >= 11 && lapCounter < 21)
         {
             lapCount.text = "LAP: 2/3";
         }
 
         if (lapCounter >= 21 && lapCounter < 31)
         {
             lapCount.text = "LAP: 3/3";
         }
         if (lapCounter >= 31)
         {
             Time.timeScale = 0;
         }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            lapCounter++;
            Debug.Log("lap completed");
        }
        
    }
    public void Defeat()
    {
        if (Time.timeScale == 1)
        {
            sfx.PlaySound("fail");
        }
        endText.text = "YOU LOSE";
        colourOverlay.color = Color.red;
        endScreen.SetActive(true);
    }
    public void Victory()
    {
        if (Time.timeScale == 1)
        {
            sfx.PlaySound("win");
        }
        
        Time.timeScale = 0f;
        endText.text = "YOU WIN";
        colourOverlay.color = win;
        endScreen.SetActive(true);
    }
}
