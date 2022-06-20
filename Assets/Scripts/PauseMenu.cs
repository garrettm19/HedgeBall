using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        GameManager.manager.GetComponent<GameSM>().RevertState();
    }

    public void ResetLevel()
    {
        GameManager.manager.GetComponent<GameSM>().ChangeState<PlayState>();
        //GameEnv.instance = null;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        GameManager.manager.GetComponent<GameSM>().ChangeState<PlayState>();
        SceneManager.LoadScene(0);
        //GameEnv.instance = null;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
