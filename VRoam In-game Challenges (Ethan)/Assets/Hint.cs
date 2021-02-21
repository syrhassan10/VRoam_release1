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
        
        hints_text.text = "Hints: " + hints.ToString() + "/5";
        
        if (Input.GetKeyDown(hint_key) && hints > 0 && !in_hint)
        {
            in_hint = true;
            hints--;
        }
        if (in_hint)
        {
            timer -= Time.deltaTime;
           
            hint_time.gameObject.SetActive(true);
            hint_time.text = "Time Left = " + Mathf.FloorToInt(timer);//.ToString();
            hint_cam.gameObject.SetActive(true);
            main_cam.gameObject.SetActive(false);
            X = true;
            if (timer < 0)
            {
                hint_cam.gameObject.SetActive(false);
                main_cam.gameObject.SetActive(true);
                hint_time.gameObject.SetActive(false);
                in_hint = false;
                timer = 5f;
                X = false;
            }
            //point_counter.text = "Points: "+ points.ToString();

        
        }
    }
}
