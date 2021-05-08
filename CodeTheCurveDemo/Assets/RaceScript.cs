using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceScript : MonoBehaviour
{

    public Transform finish;
    public static bool finishedRace;
    public GameObject arrow;
    public GameObject raceCanvas;
    public Button startButton;

    public int speed=3;

    // Start is called before the first frame update
    void Start()
    {
        finishedRace = false;
        startButton.onClick.AddListener(raceStart);
        
    }

    // Update is called once per frame
    void Update()
    {

        while (!finishedRace)
        {
            Vector3 TargetDirection = arrow.transform.position - transform.position;

            float SingleStep = speed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, TargetDirection, SingleStep, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        if (finishedRace) {
            arrow.SetActive(false);

        }

    }

    void onTrigegerEnter(Collider other) {
        
        raceCanvas.SetActive(true);

    }

    void raceStart() { 
        arrow.SetActive(true);
    }
}
