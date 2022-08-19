using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectButton : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite buttonUp, buttonDown;

    public bool isPressed;
    public float waitToPopUp;
    private float popCount;

    public AnimatorOverrideController animOverride;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed) 
        { 
            popCount-=Time.deltaTime;
            if(popCount <= 0) 
            {
                isPressed = false;
                spriteRenderer.sprite = buttonUp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isPressed)
        {
            PlayerController thePlayer = other.GetComponent<PlayerController>();
            if (thePlayer.rigidBody2D.velocity.y < -.1f)
            {
                thePlayer.animator.runtimeAnimatorController = animOverride;
                isPressed = true;
                spriteRenderer.sprite = buttonDown;
                popCount = waitToPopUp;
            }
            AudioManager.instance.PlaySFX(2);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player" && isPressed) 
        {
            isPressed=false;
            spriteRenderer.sprite = buttonUp;
            
        }
    }
}
