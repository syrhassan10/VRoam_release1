using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public float FireHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage()
    {
        FireHealth -= 5;

        if(FireHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
