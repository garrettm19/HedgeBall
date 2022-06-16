using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private int countdownTime;
    [SerializeField] private int levelTime;
    
    [SerializeField] private TMP_Text countdownText; 
    [SerializeField] private TMP_Text levelTimeText;
    [SerializeField] private TMP_Text winLoseStatusText;

    //[SerializeField] private GameObject maze;

    private IEnumerator countdown;
    private IEnumerator levelTimer;

    private void Start()
    {
        countdown = Countdown();
        levelTimer = LevelTimer();
        StartCoroutine(countdown);
        
        GameEnv.instance.survey = Instantiate(ResourceLoader.survey, GameManager.manager.transform);
    }
    
    private IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);

        StartCoroutine(levelTimer);   // Call to levelTimer coroutine
    }

    private IEnumerator LevelTimer()
    {
        GameEnv.Instance.maze.GetComponent<MazeControl>().enabled = true; //Enable Controls
        levelTimeText.gameObject.SetActive(true);
        
        while (levelTime > 0)
        {
            levelTimeText.text = "00:00:"+levelTime.ToString();
            yield return new WaitForSeconds(1f);
            levelTime--;
        }
        levelTimeText.text = "00:00:00";
        SetWinLoseBanner("YOU LOSE"); // Set the game over banner
    }

    public void SetWinLoseBanner(string status)
    {
        if(status == "YOU WIN")StopCoroutine(levelTimer);
        GameEnv.Instance.maze.GetComponent<MazeControl>().enabled = false; //Disable Controls
        winLoseStatusText.text = status;
        winLoseStatusText.gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true); //Enable end-game Menu
    }

    public void OpenSurveyForm()
    {
        GameEnv.Instance.survey.SetActive(true);
    }
}
