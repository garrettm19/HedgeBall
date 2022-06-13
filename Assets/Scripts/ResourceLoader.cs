using UnityEngine;

public static class ResourceLoader
{
    //UI and Lighting
    public static GameObject HUDCanvas = Resources.Load("Prefabs/HUDCanvas") as GameObject;
    public static GameObject lights = Resources.Load("Prefabs/Lights") as GameObject;
    
    //Ingame
    public static GameObject ball = Resources.Load("Prefabs/Ball") as GameObject;
    public static GameObject maze = Resources.Load("Prefabs/Maze") as GameObject;
    public static GameObject spawnPoint = Resources.Load("Prefabs/Start") as GameObject;
    public static GameObject endPoint = Resources.Load("Prefabs/End") as GameObject;
    public static GameObject clouds = Resources.Load("Prefabs/Clouds") as GameObject;
}
