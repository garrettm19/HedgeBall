using System;
using UnityEngine;

public sealed class ButtonClick: MonoBehaviour
{
    private static MazeControl mazeControl;
    private enum Choice
    {
        LEFT,
        RIGHT
    }

    public void Start()
    {
        mazeControl = GameEnv.Instance.maze.GetComponent<MazeControl>();
    }

    public static void Click(int choice)
    {
        switch ((Choice)choice)
        {
            case Choice.LEFT: mazeControl.RotateLeft(); break;
            case Choice.RIGHT: mazeControl.RotateRight(); break;
            default: throw new NotImplementedException();
        }
    }
}
