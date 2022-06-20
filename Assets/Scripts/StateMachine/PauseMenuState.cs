using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuState : GameState
{
    private bool _activated = false;

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Enter()
    {
        GameEnv.instance.maze.GetComponent<MazeControl>().enabled = false;
        GameEnv.instance.ball.GetComponent<BallBehavior>().rb.isKinematic = true;
        GameEnv.instance.HUDCanvas.GetComponentInChildren<HUDController>().PauseMenu.SetActive(true);
    }

    public override void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StateMachine.RevertState(); //ChangeState<PlayState>();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Exit()
    {
        GameEnv.instance.maze.GetComponent<MazeControl>().enabled = true;
        GameEnv.instance.ball.GetComponent<BallBehavior>().rb.isKinematic = false;
        GameEnv.instance.HUDCanvas.GetComponentInChildren<HUDController>().PauseMenu.SetActive(false);
        _activated = false;
    }
}
