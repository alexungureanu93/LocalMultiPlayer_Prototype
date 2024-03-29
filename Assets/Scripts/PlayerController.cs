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
    private float attackCounter;

    public float moveSpeed, jumpForce;
    public Rigidbody2D rigidBody2D;
    public Transform groundCheckPoint;
    public LayerMask groundLayerMask;

    public Animator animator;
    public bool isKeyboard2;
    public float timeBetweenAttacks = .25f;

    [HideInInspector]
    public float powerUpCounter;
    private float speedStore,gravStore;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GameManager.instance.AddPlayer(this);
        speedStore = moveSpeed;
        gravStore = rigidBody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKeyboard2) 
        {
            velocity = 0f;
            if (Keyboard.current.lKey.isPressed)
            {
                velocity += 1f;
            }
            if (Keyboard.current.jKey.isPressed)
            {
                velocity -= 1f;
            }
            if (isGrounded && Keyboard.current.rightShiftKey.wasPressedThisFrame)
            {
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            }
            if (!isGrounded && Keyboard.current.rightShiftKey.wasReleasedThisFrame && rigidBody2D.velocity.y > 0)
            {
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, rigidBody2D.velocity.y * reduceJumpForce);
            }
            if (Keyboard.current.enterKey.wasPressedThisFrame) 
            {
                animator.SetTrigger("Attack");
                attackCounter = timeBetweenAttacks;
                AudioManager.instance.PlaySFX(0);
            }
        }
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayerMask);
        rigidBody2D.velocity = new Vector2(velocity * moveSpeed, rigidBody2D.velocity.y);

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("yspeed", rigidBody2D.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rigidBody2D.velocity.x));

        if (rigidBody2D.velocity.x < 0) 
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(rigidBody2D.velocity.x > 0) 
        {
            transform.localScale = Vector3.one;
        }
        if (attackCounter > 0) 
        {
            attackCounter = attackCounter - Time.deltaTime;
            rigidBody2D.velocity = new Vector2(0f, rigidBody2D.velocity.y);
        }
        if(powerUpCounter > 0) 
        {
            powerUpCounter-= Time.deltaTime;
            if(powerUpCounter <= 0) 
            {
                moveSpeed = speedStore;
                rigidBody2D.gravityScale = gravStore;
            }
        }
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
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            animator.SetTrigger("Attack");
            attackCounter = timeBetweenAttacks;

            AudioManager.instance.PlaySFX(0);
        }
    }
}
