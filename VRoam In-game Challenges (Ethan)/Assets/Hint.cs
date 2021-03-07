using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Hint : MonoBehaviour
{

    public Camera hint_cam;
    public Camera main_cam;
    private bool in_hint;
    private float time;
    private float timer;
    public KeyCode hint_key;
    private int hints;
    public Text hints_text;
    public Text hint_time;
    public static bool X;
   
    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
        hint_cam.gameObject.SetActive(false);
        main_cam.gameObject.SetActive(true);
        in_hint = false;
        hints = 5;
        hint_time.gameObject.SetActive(false);
        X = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Shows how many hints you have on the screen
        hints_text.text = "Hints: " + hints.ToString() + "/5";
        //when you press the hint key you have chosen, you still have hints remaining, and if you are not already in a hint, it sets the in_hint bool to true and changes the amount of hints you have left
        if (Input.GetKeyDown(hint_key) && hints > 0 && !in_hint)
        {
            in_hint = true;
            hints--;
        }
        
        if (in_hint)
        {
            //This 5 second timer runs when you are currently in a hint 
            timer -= Time.deltaTime;
            // Displays how much time you have left in the hint on screen
            hint_time.gameObject.SetActive(true);
            hint_time.text = "Time Left = " + Mathf.FloorToInt(timer);
            // Enables the bird eye view for the hint
            hint_cam.gameObject.SetActive(true);
            main_cam.gameObject.SetActive(false);
            //Sets X to true, which enables the x marks that are above the presents
            X = true;
            
            if (timer < 0)
            {
                //resets everything once the timer is done
                hint_cam.gameObject.SetActive(false);
                main_cam.gameObject.SetActive(true);
                hint_time.gameObject.SetActive(false);
                in_hint = false;
                timer = 5f;
                X = false;
            }
            

        
        }
    }
}
