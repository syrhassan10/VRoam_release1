using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string username;
    public CharacterController controller;
    public Transform shootOrigin;

    public float gravity = -9.81f;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    public float health;
    public float maxHealth = 100f;

    
    public  string GunEquipped;
    public Vector3 playerPosition;
    public Quaternion playerRotation;


    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
        health = maxHealth;


    }

    /// <summary>Processes player input and moves the player.</summary>
    public void FixedUpdate()
    {

        transform.position = playerPosition;
        transform.rotation = playerRotation;
        UpdatePlayer();
    }

    private void UpdatePlayer()
    {

       
        ServerSend.PlayerPosition(id,this);
        ServerSend.PlayerRotation(id,this);
    }

    /// <summary>Updates the player input with newly received input.</summary>
    /// <param name="_inputs">The new key inputs.</param>
    /// <param name="_rotation">The new rotation.</param>






}
