using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCountAdvanced : MonoBehaviour
{
    [SerializeField] private Text lapCount;
    public int lapCounter = 0;
    private int lap;
    void Start()
    {
        lapCounter = 0;
        lap = 1;
        lapCount.text = lap + "/3 Laps";
    }

    void Update()
    {
      
        
    }

    private void OnTriggerEnter(Collider other)
    {
        lapCounter++;
        if (lapCounter == 8)
        {
            lap++;
            lapCount.text = lap + "/3 Laps";
            lapCounter = 0;
            Debug.Log(lapCounter + " " + lap);
        }
    }
}
