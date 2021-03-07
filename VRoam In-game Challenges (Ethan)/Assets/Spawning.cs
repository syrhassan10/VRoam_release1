using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Spawning : MonoBehaviour
{
    public GameObject special_present;
    public GameObject normal_present;
    public int number_of_presents;
    private int random;
    private GameObject treasure;
   
    void Start()
    {
        Presents.points = 0;
    }

    
    void Update()
    {

        number_of_presents = GameObject.FindGameObjectsWithTag("X").Length;
        //if the number of presents is below or equal to 2, it runs Spawn and randomly spawns a present. 
        // The number of presents need to be below or equal than 2 because there are two original presents that will be copied already on the map; the normal present and the special present.
        if (number_of_presents <= 2) 
        {
            Spawn();
        }
        
    }

    //This script randomly spawns presents within the map
    void Spawn()
    {
        //Randomizes the coordinates for the present that will be instantiated
        Vector3 randomizer = new Vector3(Random.Range(-90f, 30.0f), 0.11f, Random.Range(10f, -120.0f));
        //Randomizes if a special or normal present will be spawned (special present has a 10% chance of spawning)
        random = Random.Range(0, 10);
        if (random == 4)
        {
            treasure = special_present;
        }
        else
        {
            treasure = normal_present;
        }
        //instantiates the treasure
        GameObject clone = Instantiate(treasure, randomizer, transform.rotation);
        treasure = null;
    }
}