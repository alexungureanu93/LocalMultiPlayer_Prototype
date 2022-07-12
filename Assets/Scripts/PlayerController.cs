using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, jumpForce;
    public Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidBody2D.velocity.y);
    }
}
