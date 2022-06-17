using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : GameState
{
    private bool _activated = false;

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Enter()
    {
        GameEnv.instance.maze.GetComponent<MazeControl>().enabled = false;
        GameEnv.instance.ball.GetComponent<BallBehavior>().rb.isKinematic = true;
        Debug.Log("Paused");
    }

    //public override void Tick()
    //{
    //    if (_activated == false)
    //    {
    //        _activated = true;
    //    }
    //}

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Exit()
    {
        GameEnv.instance.maze.GetComponent<MazeControl>().enabled = true;
        GameEnv.instance.ball.GetComponent<BallBehavior>().rb.isKinematic = false;
        _activated = false;
        Debug.Log("UnPaused");
    }
}
