using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour


{
    public GameObject target;
    float speed = 3;
    
    public List<Transform> locations;
    public Transform trivia_parent;
    public int totalQuestions;
    

    // Start is called before the first frame update
    void Start()
    {

        InitializeTriviaRoute();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TriviaScript.index < totalQuestions)
        {
            Vector3 TargetDirection = locations[TriviaScript.index].transform.position - transform.position;

            float SingleStep = speed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, TargetDirection, SingleStep, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else {
            Debug.Log("Finished Trivia Game");
        }

    }

    void InitializeTriviaRoute() {
        foreach (Transform child in trivia_parent) {
            locations.Add(child);
            Debug.Log("added new location");
        }    
    }
}
