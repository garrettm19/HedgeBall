using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnv
{
    public static GameEnv instance;
    private List<GameObject> objects = new(); //dummy list
    private List<GameObject> checkpoints = new(); //dummy list
    private List<GameObject> enemies = new(); //dummy list

    public List<GameObject> Objects { get => objects; }

    public static GameEnv Singleton
    {
        get 
        {
            if (instance == null)
            {
                instance = new GameEnv();
                instance.checkpoints.AddRange(GameObject.FindGameObjectsWithTag("checkpoints"));
                instance.enemies.AddRange(GameObject.FindGameObjectsWithTag("enemies"));
            }
            return instance;
        }
    }

    public void AddObjects(GameObject obj)
    {
        objects.Add(obj);
    }

    public void RemoveObjects(GameObject obj)
    {
        objects.Remove(obj);
    }
}
