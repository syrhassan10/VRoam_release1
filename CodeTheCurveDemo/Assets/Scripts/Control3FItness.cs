using System;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class Control3FItness : MonoBehaviour
{
    // Settings
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 3f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float FOV = 60.0f;
    
    //UI text
    public Text uiDISTANCE;
    public Text uiSPEED;
    public Text uiMET;
    public Text uiCALORIES;

    // References
    CharacterController characterController;
    public Camera playerCamera;
    public Transform posTrack;
    public Transform playerBody;

    [HideInInspector]
    // Variables
    Vector3 moveDirection = Vector3.zero;
    public bool canMove = true;
    float rotationX = 0;
    float distanceWalked = 0;
    float timePassed = 0;
    public float playerSpeed = 0;
    public float MET = 0;
    public float caloriesBurned = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        posTrack.SetParent(null,true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        posTrack.position = playerBody.position;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isRunning)
        {   
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 90.0f, 0.1f);

        }
        else
        {
            Camera.main.fieldOfView =  Mathf.Lerp(Camera.main.fieldOfView, 70.0f, 0.1f); 

        }
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX)  + (right * curSpeedY);

        if (Input.GetKey(KeyCode.Space) && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Distance Tracking
        timePassed += Time.deltaTime;
        float distanceTraveled = Vector3.Distance(posTrack.position, playerBody.position);
        distanceWalked += distanceTraveled;
        playerSpeed = distanceTraveled / Time.deltaTime;
        MET = (float)1.7844 * Mathf.Pow(Mathf.Exp(1), (float)(0.1683 * playerSpeed * 3.6));
        if (playerSpeed == 0)
        {
            MET = 0;
        }
        caloriesBurned += (float)(MET * 3.5 * 60 / 200 / 60 * Time.deltaTime);
        posTrack.position = playerBody.position;

        uiDISTANCE.text = "Distance Walked: "+((int)distanceWalked).ToString();
        uiSPEED.text = "Speed: " + ((int)playerSpeed).ToString();
        uiMET.text = "MET: " + ((int)MET).ToString() + "";
        uiCALORIES.text = "Calories Burned: " + ((int) caloriesBurned).ToString() + "Cal";
    }
}