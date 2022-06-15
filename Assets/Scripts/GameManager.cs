using UnityEngine;

public sealed class GameManager:MonoBehaviour
{
    public static GameManager manager;

    private void Start()
    {
        if (manager != null) Destroy(gameObject);
        manager = this;
        DontDestroyOnLoad(this);

        GameEnv.Instance.audioManager = Instantiate(ResourceLoader.audioManager, Vector3.zero, Quaternion.identity, transform);
        GameEnv.Instance.lights = Instantiate(ResourceLoader.lights, transform);
    }

    public void InitializeScene()
    {
        GameEnv.Instance.clouds = Instantiate(ResourceLoader.clouds, transform);
        GameEnv.Instance.maze = Instantiate(ResourceLoader.maze, Vector3.zero, Quaternion.identity, transform);
        GameEnv.Instance.HUDCanvas = Instantiate(ResourceLoader.HUDCanvas, transform);
    }
    
    public void ResetMaze()
    {
        GameEnv.Instance.maze.GetComponent<MazeRenderer>().ResetMaze();
    }
}
