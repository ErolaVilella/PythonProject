using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] TMP_Text timer;

    private bool starts;
    private float startTime;

    /*private void Start()
    {
        startTime = Time.time;
    }*/

    private void Start()
    {
        starts = false;
    }

    public void StartTimer()
    {
        startTime = Time.time;
        starts = true;
        print(starts);

    }

    private void Update()
    {
        if (starts == true)
        {
            float TimerControl = Time.time - startTime;
            string mins = ((int)TimerControl / 60).ToString("00");
            string segs = (TimerControl % 60).ToString("00");
            string milisegs = ((TimerControl * 100) % 100).ToString("00");

            string TimerString = string.Format("{00}:{01}:{02}", mins, segs, milisegs);

            //print(TimerString);
            timer.text = TimerString;
        }

    }




}
