using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour
{
    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            myAnimator.SetInteger("animatorState", 1);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            myAnimator.SetInteger("animatorState", 0);
        }
    }
}
