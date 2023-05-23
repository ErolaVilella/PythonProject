using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] TMP_Text timer;

    public bool starts;
    private float startTime;
    public int timeScore;

    private void Start()
    {
        starts = false;
        timeScore = 0;
    }

    public void StartTimer()
    {
        startTime = Time.time;
        starts = true;
        //print(starts);

    }

    private void Update()
    {
        timerFunction();

    }

    public void timerFunction()
    {
        if (starts == true)
        {
            float TimerControl = Time.time - startTime;
            string mins = ((int)TimerControl / 60).ToString("00");
            string segs = (TimerControl % 60).ToString("00");
            string milisegs = ((TimerControl * 100) % 100).ToString("00");

            string TimerString = string.Format("{00}:{01}:{02}", mins, segs, milisegs);

            timeScore++;

            //print(TimerString);
            timer.text = TimerString;
        }

        if (starts == false)
        {
            return;
        }
    }




}
