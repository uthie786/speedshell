using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedWaypointsPath : MonoBehaviour
{

    private Graph<GameObject> advancedWaypointList = new Graph<GameObject>();
    [SerializeField] private GameObject[] waypoints;
    //public NavMeshAgent navmeshagent;
    public GameObject waypointPos;
    
    
    private void Awake()
    {
        foreach(GameObject point in waypoints)
        {
            advancedWaypointList.AddVertex(point);
            
        }
        Debug.Log(advancedWaypointList);
        
        advancedWaypointList.AddEdge(waypoints[0],waypoints[1]);
        advancedWaypointList.AddEdge(waypoints[1],waypoints[2]);
        advancedWaypointList.AddEdge(waypoints[2],waypoints[3]);
        advancedWaypointList.AddEdge(waypoints[2],waypoints[4]);
        advancedWaypointList.AddEdge(waypoints[3],waypoints[5]);
        advancedWaypointList.AddEdge(waypoints[4],waypoints[5]);
        advancedWaypointList.AddEdge(waypoints[5],waypoints[6]);
        advancedWaypointList.AddEdge(waypoints[6],waypoints[7]);
        advancedWaypointList.AddEdge(waypoints[6],waypoints[8]);
        advancedWaypointList.AddEdge(waypoints[7],waypoints[9]);
        advancedWaypointList.AddEdge(waypoints[8],waypoints[9]);
        advancedWaypointList.AddEdge(waypoints[9],waypoints[0]);
        
        Debug.Log(advancedWaypointList.GetConnectedVertices(waypoints[0]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
