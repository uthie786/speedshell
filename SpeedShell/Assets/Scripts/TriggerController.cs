using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    private int count = 0;
    private float timer = 0f;
    private StackController<GameObject> checkpointList;
    
    [SerializeField] private float timerDuration = 15f;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject[] emptyArray;
    [SerializeField] private GameObject uiDefeatScreen;
    [SerializeField] private GameObject trigger;

    void Start()
    {
        timer = timerDuration;
        
        for (int i = emptyArray.Length - 1; i >= 0; i--)
        {
            checkpointList.Push(emptyArray[i]);
            Debug.Log(checkpointList.Peek());
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

    private void Awake()
    {
        trigger.transform.position = emptyArray[0].transform.position;
        checkpointList = new StackController<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject attachedEmpty = trigger.transform.parent.gameObject;
            if(checkpointList.Peek() == attachedEmpty)
            {
                count++;
                Debug.Log(count);
                checkpointList.Pop();
                trigger.transform.SetParent(emptyArray[count].transform);
                trigger.transform.position = emptyArray[count].transform.position;
            } 

        } 



        if(count >= 4)
        {
            count = 0;
        }
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
        //if (timer == 0)
        //{
          // uiDefeatScreen.
       // }
    }


}
