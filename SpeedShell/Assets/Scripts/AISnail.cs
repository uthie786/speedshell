using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AISnail : MonoBehaviour
{
    public AIRacerFactory factory;
    [SerializeField] private int aiRacerAmount;
    private int count;
    private int rand;
   
    void Start()
    {
        count = 0;
        
        while(count <= aiRacerAmount)
        { 
            Debug.Log("working");
            rand = Random.Range(1, 4);
            factory.Create(rand);
            count++;

        }
       

    }

    
}
