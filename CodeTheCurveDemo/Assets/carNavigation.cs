using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class carNavigation : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    public int locationIndex = 1;
    private NavMeshAgent agent;
    public Transform tourguide;

    // Start is called before the first frame update
    void Start()
    {
        InitializePatrolRoute();
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPatrolLocation();

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
        agent.destination = locations[locationIndex].position;
        if (locationIndex == locations.Count - 1)
        {
            locationIndex = 0;
        }
        else {
            locationIndex++;
        }

    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        if (agent.remainingDistance < 1)
        {
            MoveToNextPatrolLocation();

        }
    }
}