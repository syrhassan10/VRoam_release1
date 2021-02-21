using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    public string question = "";
    public string failText = "You failed, pay more attention to your tour guide next time";
    public string winText = "Congratulations! You got it right!";
    public Text text;
    public int CorrectChoice = 1;
    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public AudioClip WinAudio;
    public AudioClip FailAudio;
    AudioSource audio;
    

    bool canPick = true;

    // Start is called before the first frame update
    void Start()
    {
        //Changes the UI text to the question
        audio = GetComponent<AudioSource>();
        text.text = question;
    }

    //A function for if the player picks the fist option
    public void PicketOp1()
    {
        //The if the player choose the correct choice
        if (CorrectChoice == 1 && canPick == true)
        {
            canPick = false;
            text.text = winText;
            audio.clip = WinAudio;
            audio.Play();
        }
        else
        {
            canPick = false;
            audio.clip = FailAudio;
            audio.Play();
            text.text = failText;
        }
    }

    //A function for if the player picks the second option
    public void PicketOp2()
    {
        //The if the player choose the correct choice
        if (CorrectChoice == 2 && canPick == true)
        {
            //Makes it so the player can only choose once
            canPick = false;
            text.text = winText;
            audio.clip = WinAudio;
            audio.Play();
        }
        else
        {
            canPick = false;
            audio.clip = FailAudio;
            audio.Play();
            text.text = failText;
        }
    }

    //A function for if the player picks the third option
    public void PicketOp3()
    {
        //The if the player choose the correct choice
        if (CorrectChoice == 3 && canPick == true)
        {
            //Makes it so the player can only choose once
            canPick = false;
            text.text = winText;
            audio.clip = WinAudio;
            audio.Play();
        }
        else
        {
            //Makes it so the player can only choose once
            canPick = false;
            audio.clip = FailAudio;
            audio.Play();
            text.text = failText;
        }
    }
}
