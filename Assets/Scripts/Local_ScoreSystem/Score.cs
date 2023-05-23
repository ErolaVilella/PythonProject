using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public string time;
    public int score;
}

[System.Serializable]
public class Leaderboard
{
    public List<ScoreEntry> entries = new List<ScoreEntry>();
}

public class Score : MonoBehaviour
{
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

    public void AddScoreToLeaderboard(string playerName, string time, int score, string levelName)
    {
        Leaderboard leaderboard = LoadLeaderboard(levelName);

        ScoreEntry entry = new ScoreEntry { playerName = playerName, time = time, score = score };
        leaderboard.entries.Add(entry);

        leaderboard.entries.Sort((a, b) => b.score.CompareTo(a.score));

        if (leaderboard.entries.Count > 10)
        {
            leaderboard.entries.RemoveAt(10);
        }

        SaveLeaderboard(leaderboard, levelName);
    }
}
