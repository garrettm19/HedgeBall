using UnityEngine;

public class GameSM : StateMachine
{

    // Start is called before the first frame update
    void Start()
    {
        //ChangeState<SetupGameState>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(CurrentState is PauseState)
            {
                ChangeState<PlayState>();
            } else
            {
                ChangeState<PauseState>();
            }
        }
    }
}
