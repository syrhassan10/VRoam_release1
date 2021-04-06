using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public string NextScene = "";
    public string FailScene = "";
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
        if (CorrectChoice == 1 && canPick)
        {
            Debug.Log("Correct op 1");
            StartCoroutine(PickedCorrect());
        }
        else
        {
            Debug.Log("wrong op 1");
            StartCoroutine(PickedWrong());
        }
    }

    //A function for if the player picks the second option
    public void PicketOp2()
    {
        //The if the player choose the correct choice
        if (CorrectChoice == 2 && canPick)
        {
            Debug.Log("Correct op 2");
            StartCoroutine(PickedCorrect());
        }
        else
        {
            Debug.Log("wrong op 2");
            StartCoroutine(PickedWrong());
        }
    }

    //A function for if the player picks the third option
    public void PicketOp3()
    {
        //The if the player choose the correct choice
        if (CorrectChoice == 3 && canPick == true)
        {
            Debug.Log("Correct op 3");
            StartCoroutine(PickedCorrect());
        }
        else
        {
            Debug.Log("wrong op 3");
            StartCoroutine(PickedWrong());         
        }
    }

    IEnumerator PickedCorrect()
    {
        Debug.Log("IEnumerator correct");
        canPick = false;
        text.text = winText;
        audio.clip = WinAudio;
        audio.Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(NextScene);
    }

    IEnumerator PickedWrong()
    {
        Debug.Log("IEnumerator wrong");
        canPick = false;
        text.text = failText;
        audio.clip = FailAudio;
        audio.Play();
        yield return new WaitForSeconds(2.25f);
        SceneManager.LoadScene(FailScene);
    }
}
