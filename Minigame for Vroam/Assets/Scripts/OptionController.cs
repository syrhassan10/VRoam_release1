using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionController : MonoBehaviour
{
    // Start is called before the first frame update
    public Question question;
    public int OptionNumber = 1;
    public string OptionText = "";
    public TextMeshPro text;

    void Start()
    {
        //the text that will appear for the option
        text.text = OptionText;
    }

    void OnTriggerEnter()
    {
        if (OptionNumber == 1)
        {
            question.PicketOp1();
        }
        if (OptionNumber == 2)
        {
            question.PicketOp2();
        }
        if (OptionNumber == 3)
        {
            question.PicketOp3();
        }
    }
}
