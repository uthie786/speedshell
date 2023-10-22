using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterPositionChecker : MonoBehaviour
{
    public GameObject[] Snails;
    [SerializeField] private Text posUI;
    private int index;
    private bool gameRunning;
    
    void Start()
    {
        StartCoroutine(GameCoroutine());
        gameRunning = true;
        StartCoroutine(PositionCoroutine());
    }
    private void Update()
    {

    }

    IEnumerator GameCoroutine()
    {
        yield return new WaitForSeconds(3f);
        
        Snails = GameObject.FindGameObjectsWithTag("Snail");
        
        Debug.Log("Coroutine Finished");
    }

    IEnumerator PositionCoroutine()
    {
        while (gameRunning)
        {
            PositionChecker();
            yield return new WaitForSeconds(1f);
            Debug.Log("PositionChecked");
        }
    }
    
    private void PositionChecker()
    {
        Debug.Log(Snails.Length);
        for(int x = 1; x < Snails.Length; x++)
        {
            for (int j = 0; j < x; j++)
            {
                if (Snails[x - 1].GetComponent<PoisitionChecker>().waypointPassed < Snails[x].GetComponent<PoisitionChecker>().waypointPassed)
                {
                    GameObject temp = Snails[x - 1];
                    Snails[x - 1] = Snails[x];
                    Snails[x] = temp;
                }

                /*if (Snails[x - 1].GetComponent<PoisitionChecker>().waypointPassed ==
                    Snails[x].GetComponent<PoisitionChecker>().waypointPassed)
                {
                    if (Snails[x - 1].GetComponent<NavMeshAgent>().remainingDistance >
                        Snails[x].GetComponent<NavMeshAgent>().remainingDistance)
                    {
                        GameObject temp = Snails[x - 1];
                        Snails[x - 1] = Snails[x];
                        Snails[x] = temp;
                    }
                }*/

                
                //This is for the UI
                if (Snails[x - 1] == gameObject)
                {
                    index = x -1 ;
                }
                if (Snails[x] == gameObject)
                {
                    index = x;
                }
            }
//Vector3.Distance(Snails[x-1],Snails[x-1].GetComponent<NavMeshAgent>().destination
        }
        posUI.text = "Position: " + index + "/6";

    }


}
