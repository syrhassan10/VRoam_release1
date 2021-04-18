using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TourGuide : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    public GameObject player;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    public Rigidbody rb;
    public Transform tourguide;

    // Start is called before the first frame update
    void Start()
    {
        InitializePatrolRoute();
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPatrolLocation();
        AudioListener playerSouund = player.GetComponent<AudioListener>();

    }
    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    // Update is called once per frame
    void MoveToNextPatrolLocation()
    {
        agent.destination = locations[locationIndex].position;
        locationIndex++;
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        if (agent.remainingDistance<1)
        {
            MoveToNextPatrolLocation();

        }
        tourguide.LookAt(locations[locationIndex-1].position);

    }
}