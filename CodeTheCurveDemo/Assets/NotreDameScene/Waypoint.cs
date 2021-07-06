using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    public Image iconImg;
    public Text distanceText;

    public Transform player;
    public Transform target;
    public Camera cam;

    public float closeEnoughDist;

    public void Update()
    {
       	GetDistance();
        CheckOnScreen();	
    }
    public void GetDistance()
    {
        float dist = Vector3.Distance(player.position, target.position);
        distanceText.text = dist.ToString("f1") + "m";

        if (dist < closeEnoughDist)
        {
            Destroy(gameObject);
        }
    }	
    public void CheckOnScreen()
    {
        float _vector = Vector3.Dot((target.position - cam.transform.position).normalized, cam.transform.forward);

        if(_vector <= 0)
        {
            ToggleUI(false);
        }
        else
        {
            ToggleUI(true);
            transform.position = cam.WorldToScreenPoint(target.position);
        }
    }
    public void ToggleUI(bool _value)
    {
        iconImg.enabled = _value;
        distanceText.enabled = _value;
    }
}