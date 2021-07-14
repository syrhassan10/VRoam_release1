using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    /* state 0: idle ------> Corresponding input: default
    state 1: walking                               : W
    state 2: shooting
    state 3: jumping
    state 4: dancing
    state 5: dying
    state 6: getting punched 
*/
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.W)){
            anim.SetInteger("state", 1);
        }
        else if (Input.GetKeyUp(KeyCode.W)){
            anim.SetInteger("state", 0);
        }
        
    }
}
