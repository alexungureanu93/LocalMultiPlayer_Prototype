using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public SpriteRenderer[] heartDisplay;
    public Sprite heartFull,heartEmpty;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DamagePlayer(1);
    }
    public void UpdateHealthDisplay() 
    {
        switch(currentHealth)
        {
            case 3:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartFull;
                heartDisplay[2].sprite = heartFull;
                break;
            case 2:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartFull;
                heartDisplay[2].sprite = heartEmpty;
                break;
            case 1:
                heartDisplay[0].sprite = heartFull;
                heartDisplay[1].sprite = heartEmpty;
                heartDisplay[2].sprite = heartEmpty;
                break;
            case 0:
                heartDisplay[0].sprite = heartEmpty;
                heartDisplay[1].sprite = heartEmpty;
                heartDisplay[2].sprite = heartEmpty;
                break;



        }
    }
    public void DamagePlayer(int damageToTake) 
    {
        currentHealth -= damageToTake;

        if (currentHealth < 0) 
        {
            currentHealth = 0;
        }
        UpdateHealthDisplay();

        if (currentHealth == 0) 
        {
            gameObject.SetActive(false);
        }
    }
}
