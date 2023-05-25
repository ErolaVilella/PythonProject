using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public string time;
    public float score;
}

[System.Serializable]
public class Leaderboard
{
    public List<ScoreEntry> entries = new List<ScoreEntry>();
}

public class Score : MonoBehaviour
{
    [SerializeField] TMP_InputField Name;
    public string thisLevelName;
    public Timer time;
    private string thisTime;
    public LevelScore levelScore;
    private string lvlScore;
    private int thisScore;

    public Leaderboard board;

    public TMP_Text leaderboardEntryPrefab;
    public Transform leaderboardContainer;

    public class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.items;
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] items;
        }
    }

    public void SaveLeaderboard(Leaderboard leaderboard, string levelName)
    {
        string json = JsonUtility.ToJson(leaderboard);
        string filePath = Path.Combine(Application.persistentDataPath, levelName + "_leaderboard.json");
        File.WriteAllText(filePath, json);
    }


    public Leaderboard LoadLeaderboard(string levelName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, levelName + "_leaderboard.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<Leaderboard>(json);
        }
        else
        {
            return new Leaderboard();
        }
    }



    public void AddScoreToLeaderboard(string playerName, int score, string levelName, string time)
    {
        // Load the existing leaderboard
        Leaderboard leaderboard = LoadLeaderboard(levelName);

        // Add the new score
        ScoreEntry entry = new ScoreEntry { playerName = playerName, score = score, time = time };
        leaderboard.entries.Add(entry);

        // Optional: sort the leaderboard by score
        leaderboard.entries.Sort((a, b) => b.score.CompareTo(a.score));

        // Optional: limit the leaderboard to a certain number of entries
        if (leaderboard.entries.Count > 5)
        {
            leaderboard.entries.RemoveAt(5);
        }

        // Save the updated leaderboard
        SaveLeaderboard(leaderboard, levelName);
    }

    public void DisplayLeaderboard(Leaderboard leaderboard)
    {
        foreach (Transform child in leaderboardContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (ScoreEntry entry in leaderboard.entries)
        {
            TMP_Text text = Instantiate(leaderboardEntryPrefab, leaderboardContainer);
            text.text = $"{entry.playerName}: {entry.score} :{entry.time}";
        }
    }

    public void LoadBoard()
    {
        board = LoadLeaderboard(thisLevelName);
        //LoadScoreEntries(thisLevelName);
        //LoadLeaderboard(thisLevelName);
        DisplayLeaderboard(board);

    }

    public void SavaData()
    {
        thisTime = time.GetComponent<Timer>().timerText.text;
        lvlScore = levelScore.GetComponent<LevelScore>().scoreText.text;
        thisScore = int.Parse(lvlScore);
        AddScoreToLeaderboard(Name.text, thisScore, thisLevelName, thisTime);
        LoadBoard();
        //SaveScoreEntry(board, thisLevelName);
        //AddScoreToLeaderboard(Name.text, thisTime, thisScore, thisLevelName);
    }
}

