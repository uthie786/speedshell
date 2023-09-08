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
    
    private Queue<Transform> checkpointQueue;

    [SerializeField] private Transform[] emptyArray;

    private int count = 0;

    void Start()
    {
        count = 1;
        timer = timerDuration;
        
        foreach (Transform empty in emptyArray)
        {
            checkpointQueue.Enqueue(empty);
        }
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
        if (count <= 4)
        {
            gameObject.transform.position = emptyArray[count].position;
            gameObject.transform.rotation = emptyArray[count].rotation;
            count++;
        }
        if(count >= 4)
        {
            count = 0;
        }
        timer += 5;
        DisplayTimer();
        Debug.Log("+5s");
        Debug.Log(timer);
        
        checkpointQueue.Dequeue();
        checkpointQueue.Enqueue(emptyArray[count]);
    }

    private void DisplayTimer()
    {
        timerText.text = timer.ToString();
    }

    public void Defeat()
    {
        
    }


}
