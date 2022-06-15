using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;
    private float secondsCount;
    private int minuteCount;
    private string finalTime;

    void Update()
    {
        UpdateTimerUI();
    }

    // Updates the timer display
    public void UpdateTimerUI()
    { 

            if (Time.realtimeSinceStartup >= 0)
            {
                secondsCount += Time.deltaTime;
            }
            if (secondsCount < 10)
            {
                timerDisplay.text = minuteCount + ":0" + (int)secondsCount;
            }
            else
            {
                timerDisplay.text = minuteCount + ":" + (int)secondsCount;
            }
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount = 0;
            }
 
    }

    public void resetTimer()
    {
        secondsCount = 0;
        minuteCount = 0;
    }

    public string getTime()
    {
        if (secondsCount < 10)
        {
            finalTime = (int)minuteCount + ":0" + (int)secondsCount;
        }
        else
        {
            finalTime = (int)minuteCount + ":" + (int)secondsCount;
        }
        return (finalTime);
    }

}
