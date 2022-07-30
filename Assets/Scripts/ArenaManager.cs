using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.canFight = true;
        GameManager.instance.ActivatePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
