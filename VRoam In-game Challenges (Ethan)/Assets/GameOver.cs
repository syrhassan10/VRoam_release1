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
    private int number_of_presents;
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
            //This a timer which ends the game once the time is up.
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                //Obtains how many points you earned
                number_of_presents = Presents.points;
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                //stops the timer.
                timerIsRunning = false;
                endscreen.SetActive(true);
                //Calculates how much you earned from the presents collected
                money = number_of_presents * 2;
                stonks.text = "You gathered a total of " + number_of_presents.ToString() + " presents, earning a total of " + money + " in-game coins!";
                //Stops the player from moving
                GameObject.Find("Player").GetComponent <Control3Fixed>().enabled = false;

            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        //converts the seconds given into a 00:00 format and displays it on the screen. 
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = ("Time Remaining: " + string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}