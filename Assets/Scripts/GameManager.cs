using UnityEngine;

public sealed class GameManager:MonoBehaviour
{
    public static GameManager manager;

    private void Start()
    {
        if(manager != null) Destroy(this);
        manager = this;
        DontDestroyOnLoad(this);
    }

    public void InitializeScene()
    {
        GameEnv.Instance.HUDCanvas = Instantiate(ResourceLoader.HUDCanvas, transform);
        GameEnv.Instance.lights = Instantiate(ResourceLoader.lights, transform);
        GameEnv.Instance.clouds = Instantiate(ResourceLoader.clouds, transform);
        GameEnv.Instance.maze = Instantiate(ResourceLoader.maze, Vector3.zero, Quaternion.identity, transform);
    }
    
    public void ResetMaze()
    {
        GameEnv.Instance.maze.GetComponent<MazeRenderer>().ResetMaze();
    }
}
