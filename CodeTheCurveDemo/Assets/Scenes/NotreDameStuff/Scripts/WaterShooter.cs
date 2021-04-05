using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShooter : MonoBehaviour
{
    public GameObject waterPrefab;
    public float fireForce = 2000;

    float nextFireTime = 0;

    void FixedUpdate()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 0.1f;
            GameObject bulletObject = Instantiate(waterPrefab, transform.position, transform.rotation);
            Rigidbody bullet = bulletObject.GetComponent<Rigidbody>();
            bullet.AddForce(fireForce * Vector3.right);
            Destroy(bullet, 5);
        }
        
    }
}
