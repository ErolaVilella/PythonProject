using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScore : MonoBehaviour
{

    [Range(0, 5000)] public float levelScore;
    [Range(1, 100)] public int scoreDepletionRate;
    [Range(0, 500)] public int scoreReductionPerFailed;
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        if (levelScore == 0) levelScore = 1000;
        if (scoreReductionPerFailed == 0) scoreReductionPerFailed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.isPaused && levelScore > 0)
        {
            levelScore -= scoreDepletionRate * Time.deltaTime;
        }
        if(levelScore <= 0)
        {
            levelScore = 0;
        }
    }

    public void lowerScore()
    {
        levelScore -= scoreReductionPerFailed;
    }
}
