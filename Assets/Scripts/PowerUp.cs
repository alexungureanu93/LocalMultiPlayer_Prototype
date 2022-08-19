using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool isHealth;
    public bool isInvincible;
    public bool isSpeed, isGravity;


    public float powerUpLength,powerUpAmount;

    public GameObject pickUpEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            if (isHealth)
            {
                other.GetComponent<PlayerHealthController>().FillHealth();
                AudioManager.instance.PlaySFX(8);

            }
            if (isInvincible) 
            {
                other.GetComponent<PlayerHealthController>().MakeInvincible(powerUpLength);
                AudioManager.instance.PlaySFX(9);
            }
            if (isSpeed) 
            {
                PlayerController player=other.GetComponent<PlayerController>();
                player.moveSpeed = powerUpAmount;
                player.powerUpCounter = powerUpLength;
                AudioManager.instance.PlaySFX(10);
            }
            if (isGravity) 
            {
                PlayerController player = other.GetComponent<PlayerController>();
                player.powerUpCounter = powerUpLength;
                player.rigidBody2D.gravityScale = powerUpAmount;
                AudioManager.instance.PlaySFX(11);
            }
            Instantiate(pickUpEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
