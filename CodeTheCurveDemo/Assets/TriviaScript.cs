using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaScript : MonoBehaviour
{

    public GameObject theCanvas;

    public Button optionOne;
    public Button optionTwo;
    public Button optionThree;
    public Button optionFour;

    public Text questionText;
    public Text answerOneText;
    public Text answerTwoText;
    public Text answerThreeText;
    public Text answerFourText;

    public string question;
    public string answerOne;
    public string answerTwo;
    public string answerThree;
    public string answerFour;

    public int correctAnswer;

    static int score=0;
    public Text scoreLabel;

    //public GameObject answeredCorrectly;

    bool finishedQuestion;

    public static int index=0;
    


    // Start is called before the first frame update
    void Start()
    {
        questionText.text = question;
        answerOneText.text = answerOne;
        answerTwoText.text = answerTwo;
        answerThreeText.text = answerThree;
        answerFourText.text = answerFour;

        
        index = 0;

        finishedQuestion = false;


        optionOne.onClick.AddListener(() => checkAnswer(1));
        optionTwo.onClick.AddListener(() => checkAnswer(2));
        optionThree.onClick.AddListener(() => checkAnswer(3));
        optionFour.onClick.AddListener(() => checkAnswer(4));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            if (finishedQuestion == true)
            {
                Debug.Log("Already did this question");
                theCanvas.SetActive(false);
            }
            else
            {
                theCanvas.SetActive(true);
                Debug.Log("Walked into Trigger");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            theCanvas.SetActive(false);
            Debug.Log("Left Trigger");
            //answeredCorrectly.SetActive(false);
        }
    }


    void checkAnswer(int optNumber) {
        if (optNumber == correctAnswer)
        {
            Debug.Log("Correct Answer");
            score++;
            scoreLabel.text = score.ToString();
            Debug.Log("score" + score);
            theCanvas.SetActive(false);
            //answeredCorrectly.SetActive(true);
            finishedQuestion = true;
            index++;
            Debug.Log("index:"+ index);
        }
        else {
            Debug.Log("False");
            finishedQuestion = true;
            index++;
            Debug.Log("Wrong Answer");
            Debug.Log("index" + index);
            theCanvas.SetActive(false);
        }

    }

}

