
using System;
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

    public ParticleSystem playerWater;
    public bool isEnabled1,isEnabled2,isEnabled3;
    public Text enableTruckPrompt;
    private GameObject collied;
    private GameObject water;
    
    /*public static bool GameIsPaused = false;
    public GameObject pausemenuUI;
    public Button resume;
    public Button options;
    public Button quit;
    public string[] info = {};
    public Text information;*/

    //public GameObject crosshair;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerWater.enableEmission(false);
        /*resume.onClick.AddListener(Resume);
        options.onClick.AddListener(LoadMenu);
        quit.onClick.AddListener(quitGame);
        information.text = info[counter];
        crosshair.SetActive(true);*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("firetruck"))
        {
            collied = GameObject.Find("firetruck");
            water = collied.transform.GetChild(0).gameObject;
            enableTruckPrompt.gameObject.SetActive(true);
            isEnabled1 = true;
        }
        if (other.CompareTag("firetruck2"))
        {
            collied = GameObject.Find("firetruck2");
            water = collied.transform.GetChild(0).gameObject;
            enableTruckPrompt.gameObject.SetActive(true);
            isEnabled2 = true;
        }

        if (other.CompareTag("firetruck3"))
        {
            collied = GameObject.Find("firetruck3");
            water = collied.transform.GetChild(0).gameObject;
            enableTruckPrompt.gameObject.SetActive(true);
            isEnabled3 = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("firetruck"))
        {
            enableTruckPrompt.gameObject.SetActive(false);
            isEnabled1 = false;
        }
        if (other.CompareTag("firetruck2"))
        {
            enableTruckPrompt.gameObject.SetActive(false);
            isEnabled2 = false;
        }

        if (other.CompareTag("firetruck3"))
        {
            enableTruckPrompt.gameObject.SetActive(false);
            isEnabled3 = false;
        }
    }

    /*public void OnTriggerExit(Collider other)
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
    */
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }*/

        // is the controller on the ground?
        if (canMove) {
            if (Input.GetKey(KeyCode.E))
            {
                if (isEnabled1 || isEnabled2 || isEnabled3)
                {
                    water.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                playerWater.SetActive(true);
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                playerWater.SetActive(false);
            }

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
