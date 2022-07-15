using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const float groundCheckRadius = .2f;
    private const float reduceJumpForce = .5f;
    private float velocity;
    private bool isGrounded;

    public float moveSpeed, jumpForce;
    public Rigidbody2D rigidBody2D;
    public Transform groundCheckPoint;
    public LayerMask groundLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayerMask);
        rigidBody2D.velocity = new Vector2(velocity * moveSpeed, rigidBody2D.velocity.y);

        //if (Input.GetButtonDown("Jump")) 
        //{
        //    rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
        //}
    }

    public void Move(InputAction.CallbackContext context) 
    {
        velocity = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context) 
    {
        if (context.started && isGrounded)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
        }
        if(!isGrounded && context.canceled && rigidBody2D.velocity.y>0) 
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, rigidBody2D.velocity.y * reduceJumpForce);
        }
    }
}
