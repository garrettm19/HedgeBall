using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{
    bool _activated = false;

    public override void Enter()
    {
        Debug.Log("Playing");
    }

    //public override void Tick()
    //{
    //    if (_activated == false)
    //    {
    //        _activated = true;
    //    }
    //}

    public override void Exit()
    {
        _activated = false;
        Debug.Log("Not Playing");
    }
}
