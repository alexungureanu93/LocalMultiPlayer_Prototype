using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartGameChecker : MonoBehaviour
{
    public string levelToLoad;
    public TMP_Text startCountText;
    public float timeToStart = 3f;


    //we will use to keep track of how many players are in zone
    private int playerInZone;
    private float startCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInZone >1 && playerInZone == GameManager.instance.activePlayers.Count) 
        {
            startCountText.gameObject.SetActive(true);
            startCounter -= Time.deltaTime;

            startCountText.text = Mathf.CeilToInt(startCounter).ToString();
            if(startCounter <= 0)
            {
                //SceneManager.LoadScene(levelToLoad);
                GameManager.instance.GoToNextArena();
            }
        }
        else 
        {
            startCountText.gameObject.SetActive(false);
            startCounter = timeToStart;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            playerInZone++;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInZone--;

        }
    }
}
