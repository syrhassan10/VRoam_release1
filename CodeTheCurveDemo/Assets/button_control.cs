using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button_control : MonoBehaviour
{
    // Start is called before the first frame update
    public Button start;
    void Start()
    {

        start.onClick.AddListener(switch3);
        
    }


    void switch3(){
            SceneManager.LoadScene(1);
    }
}
