using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{

    private float timer = 0f;
    [SerializeField] private float timerDuration = 15f;

    //[SerializeField] private GameObject[] triggerArray;
    
    [SerializeField] private Text timerText;
    //private string timerTextString = "";

    void Start()
    {
        timer = timerDuration;
    }
    void FixedUpdate()
    {
        timer -=Time.deltaTime;
        if (timer <= 0)
        {
            Defeat();
        }
        DisplayTimer();

    }

    private void OnTriggerEnter(Collider other)
    {
        timer += 5;
        DisplayTimer();
        Debug.Log("+5s");
        Debug.Log(timer);
    }

    private void DisplayTimer()
    {
        timerText.text = timer.ToString();
    }

    public void Defeat()
    {
        
    }


}
