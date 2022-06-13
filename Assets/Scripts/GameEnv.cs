using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnv
{
    public static GameEnv instance;

    public GameObject HUDCanvas {get; set;}
    public GameObject lights {get; set;}
    public GameObject ball {get; set;}
    public GameObject maze {get; set;}
    public GameObject clouds {get; set;}
    public GameObject spawnPoint {get; set;}
    public GameObject endPoint {get; set;}

    private List<GameObject> enemies;

    public static GameEnv Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new GameEnv();
            }
            return instance;
        }
    }

    public void AddEnemies()
    {
    
    }

    public void RemoveEnemies()
    {
        
    }
}
