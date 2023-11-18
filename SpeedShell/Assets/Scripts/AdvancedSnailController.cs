using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AdvancedSnailController : MonoBehaviour
{
    
    private NavMeshAgent navmesh;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
        navmesh = gameObject.GetComponent<NavMeshAgent>();
        num = 1;
        navmesh.SetDestination(AdvancedWaypointsPath.Instance.waypoints[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(num);
        List<GameObject> tempWay;
        tempWay = AdvancedWaypointsPath.Instance.advancedWaypointList.GetConnectedVertices(other.gameObject);
        int rand = Random.Range(0, tempWay.Count);
        SetNextWaypoint(tempWay.ElementAt(rand));
        Debug.Log(rand + " " + tempWay);
        
    }

    void SetNextWaypoint(GameObject nextWaypoint)
    {
        navmesh.SetDestination(nextWaypoint.transform.position);
    }
}
