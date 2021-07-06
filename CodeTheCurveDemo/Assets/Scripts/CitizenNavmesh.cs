using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CitizenNavmesh : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    public Transform patrolRoute;
    public List<Transform> locations;
    private int locationIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }
    
    void Update()
    {
        if (agent.remainingDistance < 0.5f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }   
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;

        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }
}
