using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WaypointLinkedList : MonoBehaviour
{
    private int count;
    public NavMeshAgent navmeshagent;
    public GameObject waypointPos;
    private LinkedListadt1<GameObject> waypointList = new LinkedListadt1<GameObject>();
    [SerializeField] public GameObject[] waypoints;
    void Start()
    {
        
        
        count = 1;
        navmeshagent = GetComponent<NavMeshAgent>();
        
        foreach(GameObject point in waypoints)
        {
            waypointList.Insert(point);
            Debug.Log(point);
        }

        GetNextWayPoint(count);
        //navmeshagent.SetDestination(waypointList[0].transform.position); 
    }
    
    public void GetNextWayPoint(int waypointCount)
    {
        //Debug.Log(waypointList[waypointCount]);
        
        waypointPos = waypointList[waypointCount];
        
        //Debug.Log(waypointPos.transform.position);

        navmeshagent.SetDestination(waypointPos.transform.position); 
    }

    private void OnTriggerEnter(Collider other)
    {
        count++;
        if (count >= 9)
        {
            count = 0;
            
        }
        GetNextWayPoint(count);
    }
}
