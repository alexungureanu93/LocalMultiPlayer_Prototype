using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArenaManager : MonoBehaviour
{
    public List<Transform> spawningPointsList=new List<Transform>();

    private bool roundOver;

    public TMP_Text playerWinText;
    public GameObject winBar, RoundCompleteText;

    public GameObject[] powerUps;
    public float timeBetweenPowerUp;
    private float powerUpCounter;

    // Start is called before the first frame update
    void Start()
    {
        foreach (PlayerController player in GameManager.instance.activePlayers)
        {
            int randomPoint = Random.Range(0, spawningPointsList.Count);
            player.transform.position = spawningPointsList[randomPoint].position;

            if (GameManager.instance.activePlayers.Count <= spawningPointsList.Count)
            {
                spawningPointsList.RemoveAt(randomPoint);
            }
        }
        GameManager.instance.canFight = true;
        GameManager.instance.ActivatePlayers();
        powerUpCounter =  timeBetweenPowerUp * Random.Range(.75f,1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.CheckActivePlayers() == 1 && !roundOver) 
        {
            roundOver = true;
            StartCoroutine(EndRoundCO());
        }
        if (powerUpCounter > 0) 
        {
            powerUpCounter-= Time.deltaTime;
            if(powerUpCounter <= 0) 
            {
                int randomPoint = Random.Range(0, spawningPointsList.Count);
                Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawningPointsList[randomPoint].position, spawningPointsList[randomPoint].rotation);
                powerUpCounter = timeBetweenPowerUp * Random.Range(.75f, 1.25f);
            }
        }
    }

    IEnumerator EndRoundCO()
    {       
        winBar.SetActive(true);
        RoundCompleteText.SetActive(true);
        playerWinText.gameObject.SetActive(true);
        playerWinText.text = "Player " + (GameManager.instance.lastPlayerNumber +1) + " wins!";
        GameManager.instance.AddRoundWin();

        yield return new WaitForSeconds(2f);

        GameManager.instance.GoToNextArena();
    }
}
