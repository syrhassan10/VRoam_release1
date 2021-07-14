using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript : MonoBehaviour
{
    float timer = 0;

    public GameObject outside;
    public GameObject theatre;

    public GameObject part0;
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject part4;
    public GameObject part5;
    public GameObject part6;
 
    public GameObject part8;
    public GameObject part9;
    public GameObject part10;
    public GameObject part11;
    public GameObject part12;

    public GameObject light;

    public AudioSource audience;
    public AudioSource fire;

    public ParticleSystem flame1;
  

    float thing = 1;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        thing = 1;

        Debug.Log("why");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Debug.Log(timer);
        
        if (timer <= 3) {
            audience.Play();
        }else if (timer <= 4) {
            outside.SetActive(false);
            theatre.SetActive(true);
            
            part0.SetActive(true);
            
        }
        else if (timer <= 10)   
        {
            audience.Stop();
            light.SetActive(false);
            part0.SetActive(false);
            part1.SetActive(true);
        }
        else if (timer <= 13)
        {

            part1.SetActive(false);
            part2.SetActive(true);
        }
        else if (timer <= 17)
        {
            part2.SetActive(false);
            part3.SetActive(true);
        }
        else if (timer <= 21)
        {
            flame1.Play(true);
            fire.Play();
            part3.SetActive(false);
            part4.SetActive(true);
        }
        else if (timer <= 25)
        {
            fire.Stop();
            flame1.Stop(true);
            part4.SetActive(false);
            part5.SetActive(true);
        }
        else if (timer <= 29)
        {
            flame1.Play(true);
            fire.Play();
            part5.SetActive(false);
            part6.SetActive(true);
        }
        else if (timer <= 33)
        {
            flame1.Stop(true);
            fire.Stop();
            part6.SetActive(false);
            part8.SetActive(true);
        }
        else if (timer <= 37)
        {
            
            part8.SetActive(false);
            part9.SetActive(true);
        }
        else if (timer <= 41)
        {
            part9.SetActive(false);
            part10.SetActive(true);
        }
        else if (timer <= 45)
        {
            part10.SetActive(false);
            part11.SetActive(true);
        }
        else if (timer <= 49)
        {
            light.SetActive(true);
            part11.SetActive(false);
            part12.SetActive(true);
        }
     

    }

    

}
