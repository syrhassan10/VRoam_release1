using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class carNavigation : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> wayPoints;
    public int locationIndex = 1;
    private NavMeshAgent agent;
    public Transform tourguide;

    void Start()
    {
        InitializePatrolRoute();
        agent = GetComponent<NavMeshAgent>();


    }
    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            wayPoints.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        if (locationIndex == wayPoints.Count)
        {
            locationIndex = 0;

        }
        agent.destination = wayPoints[locationIndex].position;
    }
    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            Debug.Log(locationIndex);
            locationIndex++;
            MoveToNextPatrolLocation();
        }
    }
}