    //////////////////////////////////////////////////////*
///how to use:
///make a gameobject
///attach the game object
///attach the destinations
////////////////////////////////////////////////////// Note This Script is not complete;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GuideNav : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Character;
    public NavMeshAgent Agent;

    public Animator animator;

    public Transform DestinationContainer;

    public bool DoesLoop;

    List<Transform> Destination = new List<Transform>();
    [Tooltip("Time to wait after getting to each destinations")] public float timeToWait;

    private int Counter = 0;

    private float lastTimeCounter;
    [Tooltip("How close the guide have to be to the Destination")] public float offsetThreshHold;
    [Tooltip("How close the guide have to be to the main player")] public float PlayeroffsetThreshHold;

    public Transform MainPlayer;
    void Start() { 
    
        Agent=GetComponent<NavMeshAgent>();
        foreach (Transform child in DestinationContainer)
        {
            Destination.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Destination[Counter].position, transform.position);
        float dist2 = Vector3.Distance(MainPlayer.position, transform.position);
        if (dist2 > PlayeroffsetThreshHold) 
        {
            Agent.isStopped = true;
        }
        else
        {
            Agent.isStopped = false;
        }
        if (dist > offsetThreshHold)
        {
            Agent.SetDestination(Destination[Counter].position);
        }
        else
        {
                if (Counter == Destination.Count-1 && DoesLoop)
                {
                    Counter = 0;
                }
        }
    }

    public void GetClicked(bool clicked) 
    {   
        float dist = Vector3.Distance(Destination[Counter].position, transform.position);
        if (clicked&& dist < offsetThreshHold) 
        {
            Counter++;
        }
    }
}
