using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameOver : MonoBehaviour
{

    // Start is called before the first frame update
    public TMP_Text stonks;
    public GameObject endscreen;
    public float timeRemaining = 10;
    private bool timerIsRunning = false;
    public Text timeText;
    public int number_of_presents = Presents.points;
    private int money;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        endscreen.SetActive(false);
        
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                endscreen.SetActive(true);
                money = number_of_presents * 2;
                stonks.text = "You gathered a total of " + number_of_presents.ToString() + " presents, earning a total of " + money + " in-game coins!";

                GameObject.Find("Player").GetComponent <Control3Fixed>().enabled = false;

            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = ("Time Remaining: " + string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}