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
    public GameObject floor;
    public GameObject player;
    // Script for the regular presents
    void Start()
    {
        //The X_mark is for hints
        X_mark = this.gameObject.transform.GetChild(0).gameObject;
        //Ensures that the presents do not destroy themselves when in contact with the floor and the player
        Physics.IgnoreCollision(floor.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        Physics.IgnoreCollision(player.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
    }
    
    
    void Update()
    {
        
        X_mark.SetActive(false);
        //This puts the amount of points you have into the Text
        point_counter.text = "Points: " + points.ToString();
        //When the bool "X" is true then 
        if (Hint.X == true)
        {
            X_mark.SetActive(true);
        }

    }
    
    void OnMouseOver()
    {
        //When you right click on the item, you gain 1 point
        if (Input.GetMouseButtonDown(1))
        {
            
            points++;
            //Destroys the gameobject after you right click it
            Destroy(gameObject);
        }
    }
    //Destroys the present if it spawns within the environment
    void OnCollisionEnter(Collision col)
    {
        
        Destroy(gameObject);
    }
}
