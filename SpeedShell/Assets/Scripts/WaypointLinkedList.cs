using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointLinkedList : MonoBehaviour
{
    public LinkedList<GameObject> waypointList;
    [SerializeField] public GameObject[] waypoints;
    void Start()
    {
        foreach(GameObject point in waypoints)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
