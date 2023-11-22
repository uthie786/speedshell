using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class WaypointLinkedList : MonoBehaviour
{
    public int count;
    public NavMeshAgent navmeshagent;
    public GameObject waypointPos;
    private LinkedListadt1<GameObject> waypointList = new LinkedListadt1<GameObject>();
    [SerializeField] public GameObject[] waypoints;

    private void Awake()
    {
        count = 0;
        navmeshagent = GetComponent<NavMeshAgent>();
        
        foreach(GameObject point in waypoints)
        {
            waypointList.Insert(point);
            Debug.Log(point);
        }
    }

    void Start()
    {
        GetNextWayPoint(count);
        //navmeshagent.SetDestination(waypointList[0].transform.position); 
    }

    
    private void Update()
    {
        if (count >= 9)
        {
            count = 0;
            
        }
    }
    
    public void GetNextWayPoint(int waypointCount)
    {
        Debug.Log(waypointList[waypointCount]);
        Debug.Log(waypointCount);
        
        waypointPos = waypointList[waypointCount];
        
        //Debug.Log(waypointPos.transform.position);

        navmeshagent.SetDestination(waypointPos.transform.position); 
        
        count++;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetNextWayPoint(count);
    }
}
