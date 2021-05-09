using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    // References
    public GameObject pBody, pBarFill;
    public Text SpeedText, DistText, CalText;
    public Text highMark, midHighMark, midMark, midLowMark, lowMark;

    // Settings
    float timePassed = 0, updateFreq = 0.2f;

    // Variables
    int calories, goal = 20;// in meters
    float distance, speed, pFilled = 0;
    bool meterUnit = true;
    bool[] markFlag = new bool[6];

    void Start()
    {
        if (goal >= 2000) { meterUnit = false; }
        if (meterUnit) // Lesser Units
        {
            lowMark.text = "- 0m";
            midLowMark.text = "";
            midMark.text = (goal / 2).ToString("- 0m");
            midHighMark.text = "";
            highMark.text = goal.ToString("- 0m");
        } else // More Units
        {
            lowMark.text = "- 0km";
            midLowMark.text = ((float)goal / 4000).ToString("- 0.0km");
            midMark.text = ((float)goal / 2000).ToString("- 0.0km");
            midHighMark.text = ((float)goal * 3 / 4000).ToString("- 0.0km");
            highMark.text = ((float)goal / 1000).ToString("- 0.0km");
        }
    }

    void Update()
    {
        // Logic
        timePassed += Time.deltaTime;
        speed = pBody.GetComponent<Control3FItness>().playerSpeed;
        distance = pBody.GetComponent<Control3FItness>().distanceWalked;
        calories = (int)pBody.GetComponent<Control3FItness>().caloriesBurned;

        // Display Update
        if (goal >= distance)
        {
            pFilled = distance / goal;
            pBarFill.transform.localScale = new Vector3(1, pFilled, 1);
        }
        if (timePassed >= updateFreq)
        {
            timePassed = 0;
            SpeedText.text = (speed * (float)3.6).ToString("0.0 km/h");
            DistText.text = ((int)distance).ToString("0 m");
            CalText.text = calories.ToString("0 cals");
        }
        // Marks
        if (distance >= 1 && !markFlag[1]) { removeGoal(lowMark); markFlag[1] = true; }
        if (distance >= goal/4 && !markFlag[2]) { removeGoal(midLowMark); markFlag[2] = true; }
        if (distance >= goal/2 && !markFlag[3]) { removeGoal(midMark); markFlag[3] = true; }
        if (distance >= goal*3/4 && !markFlag[4]) { removeGoal(midHighMark); markFlag[4] = true; }
        if (distance >= goal && !markFlag[5]) { removeGoal(highMark); markFlag[5] = true; }

        // Debug
        Debug.Log(speed);
        Debug.Log(distance);
        Debug.Log(calories);
        Debug.Log("distance:" + distance);
        Debug.Log("goal: " + goal);
        Debug.Log("d/g: " + distance/goal);
    }

    void removeGoal(Text t)
    {
        t.text = "";
        /*t.color = Color.grey;
        t.transform.LeanScale(new Vector2(1.5f, 1.5f), 2f).setEaseInBack();
        Debug.Log(t);*/
    }
}
