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
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.CheckActivePlayers() == 1 && !roundOver) 
        {
            roundOver = true;
            StartCoroutine(EndRoundCO());

           // GameManager.instance.GoToNextArena();
        }
    }

    IEnumerator EndRoundCO()
    {       
        winBar.SetActive(true);
        RoundCompleteText.SetActive(true);
        playerWinText.gameObject.SetActive(true);
        playerWinText.text = "Player " + (GameManager.instance.lastPlayerNumber +1) + " wins!";

        yield return new WaitForSeconds(2f);

        GameManager.instance.GoToNextArena();
    }
}
