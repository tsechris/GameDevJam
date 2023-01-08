using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StopWatch : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stopwatch;
    private bool stopwatchOn = false;
    private float timer;
    private float milliseconds;
    private float seconds;
    private float minutes;

    void Update()
    {
        if (stopwatchOn)
        {
            timer += Time.deltaTime;
            stopwatch.text = DisplayTime();
        }
    }

    string DisplayTime()
    {
        milliseconds = (int)(timer * 100 % 100);
        seconds = (int)(timer % 60);
        minutes = (int)(timer / 60 % 60);

        string millisecondsString = milliseconds.ToString();
        string secondsString = seconds.ToString();
        string minutesString = minutes.ToString();

        if (millisecondsString.Length == 1)
        {
            millisecondsString = "0" + millisecondsString;
        }
        if (secondsString.Length == 1)
        {
            secondsString = "0" + secondsString;
        }
        if (minutesString.Length == 1)
        {
            minutesString = "0" + minutesString;
        } 
        return minutesString + ":" + secondsString + ":" + millisecondsString;
    }
    public void StartStopwatch()
    {
        stopwatchOn = true;
    }
    public void StopStopwatch()
    {
        stopwatchOn = false;
    }
}
