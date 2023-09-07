using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{

    [SerializeField] private float timerTime = 5;

    [SerializeField] private GameObject[] triggerArray;

    [SerializeField] private Text timerText;
    private string timerTextString = "";

    void Update()
    {
        timerTextString = timerText.text;
        int timer = (int)timerTime;
        timerTextString = timer.ToString();
        timerTime -= Time.deltaTime;
        Time.timeScale = 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        timerTime += 5;
    }

    public void Defeat()
    {
        if (timerTime <= 0)
        {
            
        }
    }


}
