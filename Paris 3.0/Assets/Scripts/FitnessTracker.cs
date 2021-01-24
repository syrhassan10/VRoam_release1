using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FitnessTracker : MonoBehaviour
{
    [Tooltip("Put Your Character here")] public GameObject Character;
    [Tooltip("Weight Input for calculations (put kg as the weight)")] public float weight;
    //[Tooltip("Height Input for calculations")] public float height;

    CharacterController controller;

    [HideInInspector]
    public float timeLapsed;
    [HideInInspector]
    public float walkDistance = 0;
    [HideInInspector]
    public float runDistance = 0;
    [HideInInspector]
    public float caloriesUsed;

    [Tooltip("Put the text you want to display time passed here")] public Text TimePassed;
    [Tooltip("Put the text you want to display walking distance here")] public Text WalkingDis;
    [Tooltip("Put the text you want to display running distance here")] public Text RunningDis;
    [Tooltip("Put the text you want to display calorie here")] public Text Calorie;

    private Vector3 lastPos;
    private Vector3 currentPos;

    public void Start()
    {
        controller = Character.GetComponent<CharacterController>();
        lastPos = controller.transform.position;
        currentPos = controller.transform.position;
        Time.timeScale = 1;
    }
    public void Update()
    {
        currentPos = controller.transform.position;
        if (controller.isGrounded == false)
        {
            lastPos.y = 0;
            currentPos.y = 0;
        }
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S);
        if (Input.GetKey(KeyCode.LeftShift)==false && isMoving)
        {
            walkDistance += Vector3.Distance(currentPos, lastPos);
        }
        else if (Input.GetKey(KeyCode.LeftShift)==true && isMoving)
        {
            runDistance += Vector3.Distance(currentPos, lastPos);
        }
        else 
        {
            walkDistance += Vector3.Distance(Vector3.zero, Vector3.zero);
        }

        timeLapsed += Time.deltaTime;
        TimePassed.text = ("TimePassed: " + ((int)timeLapsed).ToString()+ " Seconds");
        WalkingDis.text = ("Walking Distance: " + ((int)walkDistance).ToString() + " Meters");
        RunningDis.text = ("Running Distance: " + ((int)runDistance).ToString() + " Meters");
        Calorie.text = ("Approximate Calories Burnt: " + ((int)((runDistance+walkDistance)* 0.0012*weight)).ToString() + " Cals");

        lastPos = currentPos;
    }
}
