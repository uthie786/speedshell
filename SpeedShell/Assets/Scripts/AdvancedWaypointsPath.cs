using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AdvancedWaypointsPath : MonoBehaviour
{

    public Graph<GameObject> advancedWaypointList = new Graph<GameObject>();
    [SerializeField] public GameObject[] waypoints;
    private NavMeshAgent navmesh;
    private int count;

    public static AdvancedWaypointsPath Instance;

    //public NavMeshAgent navmeshagent;
    public GameObject waypointPos;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        navmesh = gameObject.GetComponent<NavMeshAgent>();
        foreach (GameObject point in waypoints)
        {
            advancedWaypointList.AddVertex(point);

        }

        Debug.Log(advancedWaypointList);

        advancedWaypointList.AddEdge(waypoints[0], waypoints[1]);
        advancedWaypointList.AddEdge(waypoints[1], waypoints[2]);
        advancedWaypointList.AddEdge(waypoints[2], waypoints[3]);
        advancedWaypointList.AddEdge(waypoints[2], waypoints[4]);
        advancedWaypointList.AddEdge(waypoints[3], waypoints[5]);
        advancedWaypointList.AddEdge(waypoints[4], waypoints[5]);
        advancedWaypointList.AddEdge(waypoints[5], waypoints[6]);
        advancedWaypointList.AddEdge(waypoints[6], waypoints[7]);
        advancedWaypointList.AddEdge(waypoints[6], waypoints[8]);
        advancedWaypointList.AddEdge(waypoints[7], waypoints[9]);
        advancedWaypointList.AddEdge(waypoints[8], waypoints[9]);
        advancedWaypointList.AddEdge(waypoints[9], waypoints[0]);

        Debug.Log(advancedWaypointList.GetConnectedVertices(waypoints[0]));
    }


    private void Start()
    {
        SFXManager.instance.PlaySound("bounce");
    }
}
/* Update is called once per frame
void Update()
{
    
}

private void OnTriggerEnter(Collider other)
{
    Debug.Log(count);
    List<GameObject> tempWay;
    tempWay = advancedWaypointList.GetConnectedVertices(other.gameObject);
    int rand = Random.Range(0, tempWay.Count);
    SetNextWaypoint(tempWay.ElementAt(rand));
    Debug.Log(rand + " " + tempWay);
    
}

void SetNextWaypoint(GameObject nextWaypoint)
{
    navmesh.SetDestination(nextWaypoint.transform.position);
}
}*/
