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
    // Start is called before the first frame update
    void Start()
    {
        Presents.points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        number_of_presents = GameObject.FindGameObjectsWithTag("X").Length;
        //Debug.Log(number_of_presents);
        if (number_of_presents <= 2) 
        {
            Spawn();
           
        }
        
    }


    void Spawn()
    {
        Vector3 randomizer = new Vector3(Random.Range(-90f, 30.0f), 0.11f, Random.Range(10f, -120.0f));
        random = Random.Range(0, 10);
        if (random == 1)
        {
            treasure = special_present;
        }
        else
        {
            treasure = normal_present;
        }
        Instantiate(treasure, randomizer, transform.rotation);
        treasure = null;
    }
}