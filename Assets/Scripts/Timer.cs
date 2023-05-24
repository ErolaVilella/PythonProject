using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    [SerializeField] TMP_Text timerText;

    [HideInInspector] public bool isPaused;
    float timer;
    private float startTime;
    //public int timeScore;

    private void Start()
    {
        isPaused = true;
        //timeScore = 0;
    }

    private void Update()
    {
        if (!isPaused)
        {
            timer += Time.deltaTime;
            timerText.text = string.Format("{00}:{01}:{02}", ((int)timer / 60).ToString("00"), (timer % 60).ToString("00"), ((timer * 100) % 100).ToString("00"));
        }
    }

    public void StartTimer()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void pauseTimer()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

}
