using System;
using UnityEngine;

public static class ResourceLoader
{
    //UI and Lighting
    public static readonly GameObject HUDCanvas = Resources.Load("Prefabs/HUDCanvas") as GameObject;
    public static readonly GameObject lights = Resources.Load("Prefabs/Lights") as GameObject;
    public static readonly GameObject audioManager = Resources.Load("Prefabs/AudioManager") as GameObject;
    
    //Ingame
    public static readonly GameObject ball = Resources.Load("Prefabs/Ball") as GameObject;
    public static readonly GameObject maze = Resources.Load("Prefabs/Maze") as GameObject;
    public static readonly GameObject spawnPoint = Resources.Load("Prefabs/Start") as GameObject;
    public static readonly GameObject endPoint = Resources.Load("Prefabs/End") as GameObject;
    public static readonly GameObject clouds = Resources.Load("Prefabs/Clouds") as GameObject;
    
    //Survey
    public static readonly GameObject survey = Resources.Load("Prefabs/SurveyBuilder") as GameObject;
}
