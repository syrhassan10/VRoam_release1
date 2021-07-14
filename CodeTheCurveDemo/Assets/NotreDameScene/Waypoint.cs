using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    public Image iconImg;
    public Text distanceText;
    public int targetIndex = 0;

    public Transform player;
    public List<Transform> target;
    public Camera cam;

    public float closeEnoughDist;

    public void Update()
    {
       	GetDistance();
        CheckOnScreen();	
    }
    public void GetDistance()
    {
        float dist = Vector3.Distance(player.position, target[targetIndex].position);
        distanceText.text = dist.ToString("f1") + "m";

        if (dist < closeEnoughDist)
        {
            if (targetIndex < target.Count-1    )
            {
                targetIndex++;
            }
            else {
                //completed message
                Debug.Log("finished");
            }

        }
    }	
    public void CheckOnScreen()
    {
        float _vector = Vector3.Dot((target[targetIndex].position - cam.transform.position).normalized, cam.transform.forward);

        if(_vector <= 0)
        {
            ToggleUI(false);
        }
        else	
        {
            ToggleUI(true);
            iconImg.transform.position = cam.WorldToScreenPoint(target[targetIndex].position);
        }
    }
    public void ToggleUI(bool _value)
    {
        iconImg.enabled = _value;
        distanceText.enabled = _value;
    }
}