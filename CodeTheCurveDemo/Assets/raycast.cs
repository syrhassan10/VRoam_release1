using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class raycast : MonoBehaviour
{
    // Start is called before the first frame update

    public float distance = 2f;
    Vector3 offset = new Vector3(0,1,0);

    void Start()
    {

        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButton("Fire1")){
            RaycastHit hit;
           Debug.Log("poop");  
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position+offset, transform.TransformDirection(Vector3.forward), out hit, distance)) //shoots the raycast
            {
                Debug.DrawRay(transform.position+offset, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                if(hit.collider.tag=="Zombie"){ //checks if we hit the right object
                 //WRITE WHAT YOU WANT TO DO ONCE THE RAYCAST HITS THE NPC
                    Debug.DrawRay(transform.position+offset, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }


    }
}
