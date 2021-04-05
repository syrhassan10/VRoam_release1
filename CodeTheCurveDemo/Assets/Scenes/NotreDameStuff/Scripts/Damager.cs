using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        FireDamage fire = other.GetComponent<FireDamage>();
        if (fire != null)
        {
            fire.ApplyDamage();
            Debug.Log("hit fire");
        }
    }
}
