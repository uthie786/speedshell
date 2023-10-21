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
        
    }

    void Update()
    {
        if (lapCounter > 9)
        {
            lapCount.text = "LAP: 2/3";
        }
        if (lapCounter > 18)
        {
            lapCount.text = "LAP: 3/3";
        }
        if (lapCounter > 27)
        {
            Time.timeScale = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        lapCounter++;
    }
}
