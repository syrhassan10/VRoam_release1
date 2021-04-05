/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    [Tooltip("Place an empty gameobject in here")]
    public GameObject direction;
    private GameObject cameraContainer;
    private Quaternion rot;
    [Tooltip("Speed of player. Recommended value is 4")]
    public int movespeed;
    
    public int counter = 0;
    public string[] info = {"", "", "", ""};
    public Text information;

    void Start()
    {
        cameraContainer = new GameObject("Camera Container"); //create the gameobject that stores the player
        cameraContainer.transform.position = transform.position;//set the new gameobject to the location of the player
        transform.SetParent(cameraContainer.transform);//make the new gameobject the player's parent

        //make the direction gameobject 
        gyroEnabled = EnableGyro(); //intialize the gyroscope
        //StartCoroutwine(orientDirection()); //orient the direction gameobject to where the player is looking and do it every 0.5sec (to prevent lag)
    }
    IEnumerator orientDirection()
    {
        direction.transform.eulerAngles = new Vector3(0, cameraContainer.transform.eulerAngles.y, 0); //orient direction gameobject
        yield return new WaitForSeconds(0.5f);
        orientDirection(); //recursive loop
    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro; //so i dont have to write "Input" every time i access it
            gyro.enabled = true;//enable da gyro

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f); //make sure the player is looking forward
            rot = new Quaternion(0, 0, 1, 0);//create a quaternion for rotation purposes
            return true;
        }
        return false;
    }
    
    public void OnTriggerExit(Collider other) {
        if (other.tag == "NewText") {
            counter++;
            other.isTrigger = false;
        }
    }
    void Update()
    {
        if (gyroEnabled)
        {
            
            int shaking = (int)(Input.acceleration.y*20);//taking in the shaking value
            if (shaking < -25 || shaking > -15)
            {
                transform.position -= transform.forward * Time.deltaTime * (shaking/20) * movespeed; //make the player move forward based on shaking value
            }
            //transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            cameraContainer.transform.GetChild(0).transform.localRotation = gyro.attitude * rot; //use the gyroscope to orient the player
        }
    }
}*/


using UnityEngine;

public class GyroControl : MonoBehaviour 
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject cameraContainer;
    private Quaternion rot;

    private void Start()
    {
        cameraContainer = new GameObject ("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent (cameraContainer.transform);

        gyroEnabled = EnableGyro ();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope) 
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler (90f, 90f, 0f);
            rot = new Quaternion (0, 0, 1, 0);

            return true;
        }
        return false;
    }
    private void Update()
    {
        if (gyroEnabled)
        {
            int shaking = (int)(Input.acceleration.y*20);//taking in the shaking value
            if (shaking < -25 || shaking > -15)
            {
                transform.position -= transform.forward * Time.deltaTime * (shaking/20); //make the player move forward based on shaking value
            }
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
