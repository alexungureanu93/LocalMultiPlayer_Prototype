using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool isHealth;
    public bool isInvincible;

    public float powerUpLength;

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
                
            }
            if (isInvincible) 
            {
                other.GetComponent<PlayerHealthController>().MakeInvincible(powerUpLength);
            }
            Instantiate(pickUpEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
