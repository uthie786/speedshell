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
    [SerializeField] private Text endText;
    [SerializeField] private Text endTime;
    [SerializeField] private Image colourOverlay;
    private Color col;
    void Start()
    {
        timer = timerDuration;
        col = colourOverlay.GetComponent<Image>().color;
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
        if (checkpointList.IsEmpty)
        {
            Victory();
        }
    }

    private void Awake()
    {
        trigger.transform.position = emptyArray[0].transform.position;
        checkpointList = new StackController<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snail"))
        {
            GameObject attachedEmpty = trigger.transform.parent.gameObject;
            if(checkpointList.Peek() == attachedEmpty)
            {
                count++;
                checkpointList.Pop();
                trigger.transform.SetParent(emptyArray[count].transform);
                trigger.transform.position = emptyArray[count].transform.position;
                
                
            }
            Debug.Log(count);
            Debug.Log(emptyArray.Length);
            

        } 



        if(count >= 4)
        {
            count = 0;
        }
        timer += 5;
        DisplayTimer();
        //Debug.Log("+5s");
       // Debug.Log(timer);
        
    }

    private void DisplayTimer()
    {
        timerText.text = timer.ToString();
    }

    public void Defeat()
    {
        Time.timeScale = 0f;
        col = Color.red;
        endText.text = "YOU LOSE";
        endTime.text = "0.0 Seconds";
        uiDefeatScreen.SetActive(true);
    }
    public void Victory()
    {
        Time.timeScale = 0f;
        col = Color.green;
        endText.text = "YOU WIN";
        endTime.text = timer.ToString() + " Seconds";
        uiDefeatScreen.SetActive(true);
    }


}
