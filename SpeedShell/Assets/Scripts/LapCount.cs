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
        if (lapCounter == 4)
        {
            Time.timeScale = 0;
        }

        lapCount.text = lapCounter + " /3 Laps";
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            lapCounter++;
            Debug.Log("lap completed");
        }

    }
}