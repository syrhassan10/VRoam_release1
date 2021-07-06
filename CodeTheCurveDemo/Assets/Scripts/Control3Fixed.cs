/*
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]

public class Control3Fixed: MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public static bool GameIsPaused = false;
    public GameObject pausemenuUI;
    public Button resume;
    public Button options;
    public Button quit;


    public int counter = 0;
    public string[] info = {"", "", "", ""};
    public Text information;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public Gyroscope gyro;
    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
            
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        resume.onClick.AddListener(Resume);
        options.onClick.AddListener(LoadMenu);
        quit.onClick.AddListener(quitGame);


    }
    public void OnTriggerExit(Collider other) {
        if (other.tag == "NewText") {
            counter++;
            other.isTrigger = false;
        }
    }
    void Resume() {
        pausemenuUI.SetActive(false);
        canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pause() {
        pausemenuUI.SetActive(true);
        canMove = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void quitGame() {
        Application.Quit();
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control3Fixed : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    public float sensitivity;
    public bool canMove = false;
    public int counter = 0;
    public CharacterController controller;

    public static bool GameIsPaused = false;
    public GameObject pausemenuUI;
    public Button resume;
    public Button options;
    public Button quit;
    public string[] info = {};
    public Text information;

    public GameObject crosshair;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        resume.onClick.AddListener(Resume);
        options.onClick.AddListener(LoadMenu);
        quit.onClick.AddListener(quitGame);
        information.text = info[counter];
        crosshair.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NewText"))
        {
            counter++;
            information.text = info[counter];
            Destroy(other.gameObject);
        }
    }
    void Resume()
    {
        pausemenuUI.SetActive(false);
        crosshair.SetActive(true);
        canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pause()
    {
        pausemenuUI.SetActive(true);
        crosshair.SetActive(false);
        canMove = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;     
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

        // is the controller on the ground?
        if (canMove) {
            if (controller.isGrounded)
            {
                //Feed moveDirection with input.
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                //Multiply it by speed.
                moveDirection *= speed;
                //Jumping
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            }
            turner = Input.GetAxis("Mouse X") * sensitivity;
            looker = -Input.GetAxis("Mouse Y") * sensitivity;
            if (turner != 0)
            {
                //Code for action on mouse moving right
                transform.eulerAngles += new Vector3(0, turner, 0);
            }
            if (looker != 0)
            {
                //Code for action on mouse moving right
                transform.eulerAngles += new Vector3(looker, 0, 0);
            }
            //Applying gravity to the controller
            moveDirection.y -= gravity * Time.deltaTime;
            //Making the character move
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}
