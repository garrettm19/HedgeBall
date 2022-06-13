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

    private IEnumerator couroutine;

    private void Start()
    {
        couroutine = CountdownToStart(); 
        StartCoroutine(couroutine);
    }

    IEnumerator CountdownToStart()
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

        GameEnv.Instance.maze.GetComponent<MazeControl>().enabled = true; //Enable Controls
        levelTimeText.gameObject.SetActive(true);
        
        while (levelTime > 0)
        {
            levelTimeText.text = "00:00:"+levelTime.ToString();
            yield return new WaitForSeconds(1f);
            levelTime--;
        }
        levelTimeText.text = "00:00:00";
        
        winLoseStatusText.gameObject.SetActive(true);
        winLoseStatusText.text = "YOU LOSE!!!";
        GameEnv.Instance.maze.GetComponent<MazeControl>().enabled = false; //Disable Controls
    }

    public void SetWinBanner()
    {
        StopCoroutine(couroutine);
        GameEnv.Instance.maze.GetComponent<MazeControl>().enabled = false; //Disable Controls
        winLoseStatusText.gameObject.SetActive(true);
        winLoseStatusText.text = "YOU WIN";
    }

    public void ToggleButtons(bool state)
    {
        transform.GetChild(0).gameObject.SetActive(state);
    }
}
