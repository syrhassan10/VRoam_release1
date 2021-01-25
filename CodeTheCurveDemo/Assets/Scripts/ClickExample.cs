using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Lean.Gui;

public class ClickExample : MonoBehaviour
{
    public LeanButton btn;  
    // Start is called before the first frame update
    void Start()
    {
        btn.OnClick.AddListener(task);
    }   

    public void task() {
        SceneManager.LoadScene("Paris");
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0) && task != null) {
            SceneManager.LoadScene("Paris");
        }  
        */
    }
}
