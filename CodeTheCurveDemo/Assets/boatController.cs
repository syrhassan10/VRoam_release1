using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boatController : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        InitializePatrolRoute();
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPatrolLocation();
        agent.destination = locations[locationIndex].position;

    }
    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    // Update is called once per frame
    void MoveToNextPatrolLocation()
    {
        locationIndex++;
        agent.destination = locations[locationIndex].position;
    }
    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            MoveToNextPatrolLocation();
            Debug.Log(agent.remainingDistance);
        }

    }
}