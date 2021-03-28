using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public bool isImposter = false;


    public string username;

    public MeshRenderer model;
    public GameObject text;
    public GameObject startTextButton;
    float i = 0;

    Color color;
    public bool revealedRole = false;
    public Vector3 spawn = new Vector3(3.34f,-17.65f,-4.35f);


    public bool pauseDownload = false;
    public GameObject DeadBody;






    public void Initialize(int _id, string _username)
    {

        id = _id;
        username = _username;


    }



   public void Update()
    {
        if (id != 1 && gameObject.name == "LocalPlayer(Clone)")
        {


            if(GameObject.Find("StartGame") !=null)
            GameObject.Find("StartGame").SetActive(false);
        }


    }

  
        

}
