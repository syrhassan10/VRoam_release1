using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShooter : MonoBehaviour
{
    public GameObject waterPrefab;
    public float fireForce = 2000;
    public Transform orientation;

    float nextFireTime = 0;
    GameObject bulletObject;

    void FixedUpdate()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 0.1f;
            bulletObject = Instantiate(waterPrefab, transform.position, orientation.rotation);
            Rigidbody bullet = bulletObject.GetComponent<Rigidbody>();
            bullet.AddForce(fireForce * orientation.forward * -1);
            Destroy(bullet, 15);
        }
        
    }
}
