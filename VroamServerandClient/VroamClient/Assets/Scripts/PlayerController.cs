using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform camTransform;
    public CharacterController characterController;
    public CameraController cameraController;
    public GameObject text;
    public Camera playerCamera;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float CameraFOV;
    public float zoomedInFOV;
    public bool DidInteract = false;
    public bool CanReport = false;
    bool test = false;
    bool canJump = true;
    bool isReloading = false;
    bool canMove = true;
    Vector3 velocity;

    bool canKill = false;


    
    public void Start()
    {




    }
    public void Update()
    {






        if (Input.GetButton("Fire2"))
        {

            playerCamera.fieldOfView = zoomedInFOV;
        }
        else
        {
            playerCamera.fieldOfView = CameraFOV;
        }
        if (canMove)
        {



            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 adjustedForward = camTransform.forward;
            adjustedForward.y = 0;
            Vector3 move = camTransform.right * x + adjustedForward * z;

            characterController.Move(move * speed * Time.deltaTime);




            characterController.Move(new Vector3(0,-1,0) * Time.deltaTime);


        }



        ClientSend.playerPosition(transform.position);
        ClientSend.playerRotation(transform.rotation);


          

        
        }













}
