using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickonGuide : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Transform cameraTransform = Camera.main.transform;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Guide")) 
                {
                    hit.collider.GetComponent<GuideNav>().GetClicked(true);
                }
            }
        }
    }
}
