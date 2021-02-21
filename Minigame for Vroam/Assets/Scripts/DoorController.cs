using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject Player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.position = SpawnPoint.transform.position;
        }
    }
}
