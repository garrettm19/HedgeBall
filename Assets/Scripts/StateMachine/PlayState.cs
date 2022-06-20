using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{
    bool _activated = false;

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Enter()
    {
        Debug.Log("Playing");
    }

    public override void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateMachine.ChangeState<PauseState>(); //ChangeState<PlayState>();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StateMachine.ChangeState<PauseMenuState>(); //ChangeState<PlayState>();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ButtonClick.Click(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ButtonClick.Click(0);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Exit()
    {
        _activated = false;
    }
}
