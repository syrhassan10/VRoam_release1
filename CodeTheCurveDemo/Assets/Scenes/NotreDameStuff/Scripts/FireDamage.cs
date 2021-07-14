using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public float FireHealth = 100;

    public void ApplyDamage()
    {
        FireHealth -= 5;

        if(FireHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
