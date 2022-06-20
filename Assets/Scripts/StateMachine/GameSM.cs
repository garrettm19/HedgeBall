using UnityEngine;

public class GameSM : StateMachine
{

    // Start is called before the first frame update
    void Start()
    {
        ChangeState<PlayState>();
    }
}
