using UnityEngine;

public sealed class GameManager:MonoBehaviour
{
    public static GameManager manager;

    private void Start()
    {
        if (manager != null) Destroy(gameObject);
        manager = this;
        DontDestroyOnLoad(this);

        Instantiate(ResourceLoader.audioManager, Vector3.zero, Quaternion.identity, transform);
        Instantiate(ResourceLoader.lights, transform);
    }

    public void InitializeScene()
    {
        Instantiate(ResourceLoader.clouds, transform);
        GameEnv.Instance.maze = Instantiate(ResourceLoader.maze, Vector3.zero, Quaternion.identity, transform);
        GameEnv.Instance.HUDCanvas = Instantiate(ResourceLoader.HUDCanvas, transform);
    }
    
    public void ResetMaze()
    {
        GameEnv.Instance.maze.GetComponent<MazeRenderer>().ResetMaze();
    }
}
