using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Movement")]
    public float runSpeed = 12;
    public float jumpHeight = 8.0f;

    [Header("World settings")]
    public float gravity = - 9.81f;
    public Camera playerCamera;
    public float MouseSensitivity = 10.0f;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private float xRotation = 0f;
    bool isGrounded; 


    Vector3 velocity;
    float x = 0;
    float z = 0;
    
    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;

    [HideInInspector]
    public bool canMove = true;



    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (canMove)
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
            transform.Rotate(Vector3.up * mouseX);
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            Vector3 movement = transform.right * x + transform.forward * z;

            controller.Move(movement * runSpeed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}
