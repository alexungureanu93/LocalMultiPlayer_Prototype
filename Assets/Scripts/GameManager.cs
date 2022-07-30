using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxPlayers;
    public List<PlayerController> activePlayers = new List<PlayerController>();
    public ParticleSystem playerSpawnEffects;

    public bool canFight;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer(PlayerController newPlayer) 
    {
        if (activePlayers.Count < maxPlayers) 
        { 
            activePlayers.Add(newPlayer);
            Instantiate(playerSpawnEffects, newPlayer.transform.position, newPlayer.transform.rotation);
        }
        else 
        {
            Destroy(newPlayer.gameObject);
        }
    }
}
