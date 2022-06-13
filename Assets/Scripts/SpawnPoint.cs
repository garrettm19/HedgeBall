using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] 
    private Vector3 ballOffset;
    
    void Start()
    {
        GameEnv.Instance.ball = Instantiate(ResourceLoader.ball, GameEnv.Instance.maze.transform);
        GameEnv.Instance.ball.transform.position = GameEnv.Instance.spawnPoint.transform.position + ballOffset; 
    }
}
