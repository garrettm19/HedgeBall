using UnityEngine;

public static class ResourceLoader
{
    public static GameObject lights = Resources.Load("Prefabs/Lights") as GameObject;
    public static GameObject ball = Resources.Load("Prefabs/Ball") as GameObject;
    public static GameObject maze = Resources.Load("Prefabs/Maze") as GameObject;
    public static GameObject spawnPoint = Resources.Load("Prefabs/Start") as GameObject;
    public static GameObject endPoint = Resources.Load("Prefabs/End") as GameObject;
}
