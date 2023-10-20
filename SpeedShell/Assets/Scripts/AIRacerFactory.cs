using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerFactory : MonoBehaviour
{
    [SerializeField] private GameObject aiSnail1;
    [SerializeField] private GameObject aiSnail2;
    [SerializeField] private GameObject aiSnail3;

    public void Create(int num)
    {
        if (num == 1)
        {
            Instantiate(aiSnail1);
            Debug.Log("Instantiated");
        }
        if (num == 2)
        {
            Instantiate(aiSnail2).GetComponent<AISnail>();
            Debug.Log("Instantiated");
        }
        if (num == 3)
        {
            Instantiate(aiSnail3).GetComponent<AISnail>();
            Debug.Log("Instantiated");
        }
        
        //return null;
        
        
        
    }
}
