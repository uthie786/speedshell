using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterPositionChecker : MonoBehaviour
{
    private GameObject[] Snails;
    
    void Start()
    {
        //Snails = GameObject.FindGameObjectsWithTag("Snail");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Snails = GameObject.FindGameObjectsWithTag("Snail");
            PositionChecker();
        }
    }
    
    private void PositionChecker()
    {
        
        for(int x = 1; x <= Snails.Length; x++)
        {
            if (Snails[x - 1].GetComponent<PoisitionChecker>().waypointPassed < Snails[x].GetComponent<PoisitionChecker>().waypointPassed)
            {
                GameObject temp = Snails[x - 1];
                Snails[x - 1] = Snails[x];
                Snails[x] = temp;
            }
            
        }
        Debug.Log(Snails);
    }
}
