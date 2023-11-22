using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCount : MonoBehaviour
{
    [SerializeField] private Text lapCount;
    public int lapCounter = 0;
    void Start()
    {
        lapCounter = 0;
    }

    void Update()
    {
        if (lapCounter >= 11 && lapCounter < 21)
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
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        lapCounter++;
    }
}
