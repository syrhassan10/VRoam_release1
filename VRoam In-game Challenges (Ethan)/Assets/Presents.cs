using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Presents : MonoBehaviour
{
    public static int points;
    public Text point_counter;
    private GameObject X_mark;
    // Start is called before the first frame update
    void Start()
    {
        
        X_mark = this.gameObject.transform.GetChild(0).gameObject;
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(points);
        X_mark.SetActive(false);
        point_counter.text = "Points: " + points.ToString();
        if (Hint.X == true)
        {
            X_mark.SetActive(true);
        }
    }
    //gameObject[index].transform.GetChild(1)
    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right click on this object");
            points++;
            
            Destroy(gameObject);
        }
    }

}
