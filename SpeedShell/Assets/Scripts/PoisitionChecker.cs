using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisitionChecker : MonoBehaviour
{
    public int waypointPassed;
    void Start()
    {
        waypointPassed = 0;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        waypointPassed++;
    }
}
