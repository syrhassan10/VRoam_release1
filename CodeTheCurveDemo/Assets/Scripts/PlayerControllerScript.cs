     using UnityEngine;
     using System.Collections;
     
     [RequireComponent(typeof(Rigidbody))]
     [RequireComponent(typeof(CapsuleCollider))]
     public class PlayerControllerScript : MonoBehaviour
     {
         //Character Settings
         public float defaultWalkSpeed = 5f;
         public float defaultRunSpeed = 10f;
         public float defaultCrouchSpeed = 1.5f;
         public float defaultSwimSpeed = 4f;
         public float defaultAirSpeed = 0.85f;
         public float defaultJumpForce = 2.1f;
         public float defaultPlayerMass = 20f;
         public float playerFallSpeed = 0f;
         public float currentMoveSpeed = 0f;
         public float currentAirSpeed = 0f;
         public float neckHorizontalLimit = 30f;
         public float neckVerticalLimit = 35f;
         public float backboneVerticalLimit = 45f;
         public float maxVelocityChange = 10.0f;
         public float maxAirVelocityChange = 5.0f;
         public LayerMask CharacterLayerMask;
         private Vector3 groundVelocity;
         float neckHorizontalRotation = 0.0f;
         float neckVerticalRotation = 0.0f;
         float backboneVerticalRotation = 0.0f;
         float cameraVerticalRotation = 0.0f;
         float playerCameraHeight = 0f;
         float playerContactSlope = 1f;
     
         //Control and Mouse
         float defaultMouseSensivitity = 1f;
         Vector3 previousVelocity;
         public float customMouseSensivitity = 2.5f;
         public float cameraVerticalLimit = 80.0f;
     
         //Components
         Rigidbody playerRigidbody;
         CapsuleCollider playerCapsuleCollider;
         Animator playerAnimator;
         public GameObject playerCamera;
         public GameObject CameraObjects;
         public GameObject playerBody;
     
         //Booleans
         public bool isPaused = false;
         public bool isGrounded;
         public bool isWalking;
         public bool isSwimming;
         public bool isRunning;
         public bool canRun;
         public bool isCrouching;
         public bool canCrouch;
         public bool isInAir;
         public bool canJump;
         private bool jumpFlag;
         private bool landedFlag;
     
         void Start()
         {
             //Cursor.lockState = CursorLockMode.Locked;
             if (playerRigidbody == null) {playerRigidbody = gameObject.GetComponent<Rigidbody>(); }
             if (playerCamera == null) {playerCamera = gameObject.GetComponentInChildren<Camera>().gameObject; }
             if (playerCapsuleCollider == null) { playerCapsuleCollider = gameObject.GetComponent<CapsuleCollider>(); }
             if (playerAnimator == null) { playerAnimator = gameObject.GetComponent<Animator>(); }
             playerFallSpeed = Physics.gravity.y;
         }
     
         void Update()
         {

             float mouseHorizontal = Input.GetAxisRaw("Mouse X") * defaultMouseSensivitity;
             float mouseVertical = Input.GetAxisRaw("Mouse Y") * defaultMouseSensivitity;
             
             //Player Camera Movement
             cameraVerticalRotation -= mouseVertical;
             cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -cameraVerticalLimit +30, +cameraVerticalLimit);
             
                 CameraObjects.transform.Rotate(0, mouseHorizontal, 0);
                 playerCamera.transform.localRotation = Quaternion.Euler(cameraVerticalRotation, -90, 0);
                 playerCamera.transform.localPosition = new Vector3(0, Mathf.Lerp(playerCamera.transform.localPosition.y, playerCameraHeight, 5f * Time.deltaTime), 0);
             //END PLAYER CAMERA
             
             //PLAYER JUMP CONTROL
             if (isGrounded) {
                 canJump = true;
                 if(!isCrouching || !isSwimming) {
                     canRun = true;
                 }
                 else {
                     canRun = false;
                 }
                 if (Input.GetButtonDown("Jump"))
                 {
                     jumpFlag = true;
                 }
             }
             if (Input.GetButtonDown("Crouch"))
             {
                 isRunning = false;
                 isCrouching = true;
             }
             if (Input.GetButtonUp("Crouch"))
             {
                 if (!Physics.Raycast(new Ray(transform.position + new Vector3(0, 1f, 0), Vector3.up), 1f, CharacterLayerMask))
                 {
                     isCrouching = false;
                 }
             }
 
             playerAnimator.SetBool("isCrouching", isCrouching);
             playerAnimator.SetBool("isGrounded", isGrounded);
 
             //PLAYER OUT OF WORLD CHECKS
             if (playerBody.transform.position.y < -25
               || playerBody.transform.position.z < -5000
               || playerBody.transform.position.z > 5000
               || playerBody.transform.position.x < -5000
               || playerBody.transform.position.x > 5000)
             {
                 playerRigidbody.position = new Vector3(0, 10, 0);
             }
         }
         
         void FixedUpdate()
         {
             //PLAYER MOVEMENT
             float verticalSpeed = Input.GetAxis("Vertical");
             float horizontalSpeed = Input.GetAxis("Horizontal");
             
             if (verticalSpeed !=0 || horizontalSpeed !=0)
             {
                 if (isGrounded)
                 {
                     if (!isRunning)
                     {
                         if (!isCrouching)
                         {
                             currentMoveSpeed += defaultWalkSpeed * Time.fixedDeltaTime;
                             currentMoveSpeed = Mathf.Clamp(currentMoveSpeed, 0f, defaultWalkSpeed);
                         }
                         else
                         {
                             currentMoveSpeed += defaultCrouchSpeed * Time.fixedDeltaTime;
                             currentMoveSpeed = Mathf.Clamp(currentMoveSpeed, 0f, defaultCrouchSpeed);
                         }
                     }
                     else
                     {
                         currentMoveSpeed += defaultRunSpeed * Time.fixedDeltaTime;
                         currentMoveSpeed = Mathf.Clamp(currentMoveSpeed, 0f, defaultRunSpeed);
                     }
                 }
             }
             else
             {
                 currentMoveSpeed -= defaultWalkSpeed * Time.fixedDeltaTime;
                 currentMoveSpeed = Mathf.Clamp(currentMoveSpeed, 0f, Mathf.Infinity);
             }
             
             Vector3 inputVector = new Vector3(-verticalSpeed, 0, horizontalSpeed).normalized;
             inputVector *= playerContactSlope;
     
             if (!isPaused)
             {
                 if (isGrounded)
                 {
                     if (!landedFlag)
                     {
                         currentMoveSpeed *= 0.75f;
                         landedFlag = true;
                     }
                     Vector3 velocityChange = CalculateVelocityChange(inputVector);
                     
                     playerRigidbody.AddRelativeForce(velocityChange, ForceMode.VelocityChange);
                     if(verticalSpeed != 0) {
                         playerBody.transform.localRotation = new Quaternion(CameraObjects.transform.localRotation.x, Mathf.Lerp(playerBody.transform.localRotation.y, CameraObjects.transform.localRotation.y, 4f * Time.deltaTime), CameraObjects.transform.localRotation.z, CameraObjects.transform.localRotation.w);
                     }
                     if (canJump && jumpFlag)
                     {
                         jumpFlag = false;
                         landedFlag = false;
                         if(!isRunning && !isCrouching) { 
                             playerAnimator.SetTrigger("jumpFlag");
                         }
                         previousVelocity = playerRigidbody.velocity;
                         currentAirSpeed = currentMoveSpeed;
                         playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, playerRigidbody.velocity.y + CalculateJumpVerticalSpeed(), playerRigidbody.velocity.z);
                     }
     
                     //Crouch on ground
                     float playerHitboxHeight = 2f;
                     if (isCrouching)
                     {
                         playerHitboxHeight = 1.5f;
                         playerCameraHeight = -0.5f;
                     }
                     else {
                         playerHitboxHeight = 2f;
                         playerCameraHeight = 0f;
                     }
                     float lastHeight = playerCapsuleCollider.height;
                     playerCapsuleCollider.height = Mathf.Lerp(playerCapsuleCollider.height, playerHitboxHeight, 10f * Time.deltaTime);
                     transform.position += new Vector3(0, (playerCapsuleCollider.height - lastHeight) / 2.1f, 0);
                 }
                 else
                 {
                     Vector3 velocityChange = CalculateAirVelocityChange(previousVelocity, inputVector);
                     playerRigidbody.AddRelativeForce(velocityChange, ForceMode.VelocityChange);
     
                     //Crouch in air
                     float playerHitboxHeight = 2f;
                     if (isCrouching)
                     {
                         playerHitboxHeight = 1.5f;
                         playerCameraHeight = -0.5f;
                     }
                     else {
                         playerHitboxHeight = 2f;
                         playerCameraHeight = 0f;
                     }
                     float lastHeight = playerCapsuleCollider.height;
                     playerCapsuleCollider.height = Mathf.Lerp(playerCapsuleCollider.height, playerHitboxHeight, 15f * Time.deltaTime);
                     transform.position += new Vector3(0, (playerCapsuleCollider.height - lastHeight) / 2.1f, 0);
                 }
     
                 isGrounded = false;
             }
             
             if (!isPaused)
             {
                 if (verticalSpeed != 0 || horizontalSpeed != 0)
                 {
                     if (!Input.GetButton("Crouch"))
                     {
                         if (!Physics.Raycast(new Ray(transform.position + new Vector3(0, 1f, 0), Vector3.up), 1f, CharacterLayerMask))
                         {
                             isCrouching = false;
                         }
                     }
                 }
                 if (canRun && Input.GetButton("Sprint"))
                 {
                     isRunning = true;
                 }
                 else
                 {
                     isRunning = false;
                 }
     
                 if (inputVector.magnitude > 0)
                 {
                     if (isRunning)
                     {
                         playerAnimator.SetFloat("Speed", 2);
                     }
                     else {
                         playerAnimator.SetFloat("Speed", 1);
                     }
                 }
                 else
                 {
                     playerAnimator.SetFloat("Speed", 0);
                 }
             }
             //END PLAYER MOVEMENT
         }
     
         void OnCollisionExit(Collision collision)
         {
             if (collision.transform == transform.parent)
             {
                 //transform.parent = null;
                 //gameObject.transform.localScale = new Vector3(1, 1, 1);
             }
         }
     
         void OnCollisionStay(Collision col)
         {
             TrackGrounded(col);
         }
     
         void OnCollisionEnter(Collision col)
         {
             TrackGrounded(col);
         }
     
         //CALCULATE VELOCITY CHANGE
         private Vector3 CalculateVelocityChange(Vector3 inputVector)
         {
             // Calculate how fast we should be moving
             Vector3 relativeVelocity = CameraObjects.transform.TransformDirection(inputVector);
             relativeVelocity.x *= currentMoveSpeed;
             relativeVelocity.z *= currentMoveSpeed;
     
             // Calcualte the delta velocity
             Vector3 currRelativeVelocity = playerRigidbody.velocity - groundVelocity;
             Vector3 velocityChange = relativeVelocity - currRelativeVelocity;
             velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
             velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
             velocityChange.y = 0;
     
             return velocityChange;
         }
     
         //CALCULATE AIRVELOCITY CHANGE
         private Vector3 CalculateAirVelocityChange(Vector3 previousVelocity, Vector3 inputVector)
         {
             // Calculate how fast we should be moving
             Vector3 relativeVelocity = previousVelocity;
             if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
             {
                 if (inputVector.z > 0 || inputVector.z < 0)
                 {
                     //strafing detected.
                     relativeVelocity = (currentAirSpeed * Mathf.Clamp(Mathf.Abs(Input.GetAxis("Mouse X")), 0f, 2f)) * CameraObjects.transform.TransformDirection(inputVector);
                     previousVelocity = -CameraObjects.transform.right * currentAirSpeed;
                     playerRigidbody.AddRelativeForce(previousVelocity, ForceMode.VelocityChange);
                 }
             }
     
             relativeVelocity.z *= defaultAirSpeed;
             relativeVelocity.x *= defaultAirSpeed;
     
             // Calcualte the delta velocity
             Vector3 velocityChange = relativeVelocity - playerRigidbody.velocity;
             velocityChange.x = Mathf.Clamp(velocityChange.x, -maxAirVelocityChange, maxAirVelocityChange);
             velocityChange.z = Mathf.Clamp(velocityChange.z, -maxAirVelocityChange, maxAirVelocityChange);
             velocityChange.y = 0;
     
             return velocityChange;
         }
     
         //PLAYER JUMP MACHANICS
         private float CalculateJumpVerticalSpeed()
         {
             return Mathf.Sqrt(2f * defaultJumpForce * Mathf.Abs(Physics.gravity.y));
         }
     
         //ISGROUNDED CHECKER
         private void TrackGrounded(Collision collision)
         {
             float maxHeight = playerCapsuleCollider.bounds.min.y + playerCapsuleCollider.radius * 0.4f;
             foreach (var contact in collision.contacts)
             {
                 //print("test contact slope: " + Vector3.Dot(Vector3.up, contact.normal));
                 if (contact.point.y < maxHeight)
                 {
                     float contactSlope = Vector3.Dot(Vector3.up, contact.normal);
                     if (contactSlope < 0.75 && contactSlope > 0)
                     {
                         playerContactSlope = contactSlope;
                     }
                     else
                     {
                         playerContactSlope = 1;
                     }
                     if (isKinematic(collision))
                     {
                         groundVelocity = collision.rigidbody.velocity;
                         print("GV: " + groundVelocity.ToString());
                         //transform.parent = collision.transform;
                         //print("isKine");
                     }
                     else if (isStatic(collision))
                     {
                         //transform.parent = collision.transform;
                         //print("isStatic");
                     }
                     else
                     {
                         groundVelocity = Vector3.zero;
                         //print("isGroundZero");
                     }
     
                     isGrounded = true;
                 }
     
                 break;
             }
         }
     
         private bool isKinematic(Collision collision)
         {
             //print("getKeneTrans");
             return isKinematic(collision.transform);
         }
     
         private bool isKinematic(Transform contacttransform)
         {
             return contacttransform.GetComponent<Rigidbody>() && contacttransform.GetComponent<Rigidbody>().isKinematic;
         }
     
         private bool isStatic(Collision collision)
         {
             return isStatic(collision.transform);
         }
     
         private bool isStatic(Transform transform)
         {
             return transform.gameObject.isStatic;
         }
     }