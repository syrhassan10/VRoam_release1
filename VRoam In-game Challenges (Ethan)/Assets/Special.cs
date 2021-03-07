using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Special : MonoBehaviour
{
    private GameObject X_mark;
    public GameObject floor;
    public GameObject player;
    //Script for the special presents
    void Start()
    {
        //The X_mark is for the hints
        X_mark = this.gameObject.transform.GetChild(0).gameObject;
        //Ensures that the presents do not destroy themselves when in contact with the floor and the player.
        Physics.IgnoreCollision(floor.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        Physics.IgnoreCollision(player.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
    }

    
    void Update()
    {
        
        X_mark.SetActive(false);
        //When the bool from the script "Hint" is true, the X_mark is active.
        if (Hint.X == true)
        {
            X_mark.SetActive(true);
        }

    }
    
    void OnMouseOver()
    {
        //When you right click on the item, you gain 5 points
        if (Input.GetMouseButtonDown(1))
        {
            
            Presents.points += 5;
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
