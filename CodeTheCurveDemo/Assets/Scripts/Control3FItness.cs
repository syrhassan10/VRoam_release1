using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public Gyroscope gyro;
    public GameObject UI;

    public bool isMobile = false;
    [HideInInspector]
    // Variables
    bool isUIactive = true;
    Vector3 moveDirection = Vector3.zero;
    public bool canMove = true;
    float rotationX = 0;
    public float distanceWalked = 0;
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

        StartCoroutine(DelayRefresh(1));
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "notredame":
                SceneManager.LoadScene("NotreDame");
                break;  
            case "manhole":
                SceneManager.LoadScene("Paris Catacomb");
                break;
            case "Start":
                SceneManager.LoadScene("Paris");
                break;
        }
    }

    IEnumerator DelayRefresh(int stoptime)
    {
        uiSPEED.text = "Speed: " + (Mathf.Round(playerSpeed)).ToString() + " m/s";
        uiMET.text = "MET: " + (Mathf.Round(MET)).ToString();

        yield return new WaitForSeconds(stoptime);

        StartCoroutine(DelayRefresh(1));


    }
    void Update()
    {

        if (SystemInfo.supportsGyroscope && isMobile)
        {
            //orient player using gyroscope outputs
            playerCamera.transform.localRotation = new Quaternion(gyro.attitude.x, 0f, 0f, 0f);
            transform.rotation *= new Quaternion(0f, gyro.attitude.y, 0f, 0f);
            
            //move player based on accelerometer outputs
            float acceleration = 0f;
            acceleration = Input.acceleration.x;
            if ((int)(acceleration*10) > 5)
            {
                transform.Translate(Vector3.down*acceleration);
            }
        }


        else
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

            //enable and disable the UI using key "P"
            if (Input.GetKeyDown(KeyCode.P))
            {
                isUIactive = !isUIactive;
                UI.SetActive(isUIactive);
            }
            if (Input.GetKeyDown(KeyCode.O)) {
                SceneManager.LoadScene("Paris");
            }
            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }

        }


        


        timePassed += Time.deltaTime;
        float distanceTraveled = Vector3.Distance(posTrack.position, playerBody.position);
        distanceWalked += distanceTraveled;
        playerSpeed = distanceTraveled / Time.deltaTime;
        MET = 1.7844f * Mathf.Pow(Mathf.Exp(1), (0.1683f * playerSpeed * 3.6f));
        if (playerSpeed == 0)
        {
            MET = 0;
        }
        caloriesBurned += (float)(MET * 3.5 * 60 / 200 / 60 * Time.deltaTime);
        posTrack.position = playerBody.position;
        
        uiDISTANCE.text = "Distance Walked: " + ((int)distanceWalked).ToString() + " m";
        uiCALORIES.text = "Calories Burned: " + (Mathf.Round(caloriesBurned)).ToString() + " Cal";
    }

}