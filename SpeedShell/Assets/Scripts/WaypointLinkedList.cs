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
    public LinkedListadt1<GameObject> waypointList = new LinkedListadt1<GameObject>();
    
    [SerializeField] public GameObject[] waypoints;
    void Start()
    {
        count = 1;
        navmeshagent = GetComponent<NavMeshAgent>();
        
        foreach(GameObject point in waypoints)
        {
            waypointList.Insert(point);
        }
        Debug.Log(waypointList);
        
        GetNextWayPoint(count);
    }
    
    public void GetNextWayPoint(int waypointCount)
    {
        Debug.Log(waypointList[waypointCount]);
        
        waypointPos = waypointList[waypointCount];
        
        Debug.Log(waypointPos.transform.position);

        navmeshagent.SetDestination(waypointPos.transform.position); //bloodymanu bloody
    }

    private void OnTriggerEnter(Collider other)
    {
        count++;
        GetNextWayPoint(count);
        Debug.Log(count);

        if (count == 10)
        {
            count = 0;
            
        }
    }
}
