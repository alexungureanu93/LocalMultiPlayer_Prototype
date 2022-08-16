using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite downPad, upPad;

    public float stayUpTime, bouncePower;
    private float upCounter;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (upCounter > 0)
        {
            upCounter -= Time.deltaTime;
            if (upCounter <= 0)
            {
                spriteRenderer.sprite = downPad;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            upCounter = stayUpTime;
            spriteRenderer.sprite = upPad;
            Rigidbody2D playerRGBD = other.GetComponent<Rigidbody2D>();
            playerRGBD.velocity = new Vector2(playerRGBD.velocity.x, bouncePower);
        }
    }
}
