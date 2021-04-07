using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentGameScore;

    public static event Action<int> OnScoreChanged = delegate { };

    public static ScoreManager Instance;

    void Start()
    {
        if (Instance)
            Destroy(this);
        else
            Instance = this;

        currentGameScore = 0;
        GGSM.OnGameStarted += ResetCurrentScore;
        GGSM.OnGameEnded += HighScoreCheckSet;
    }

    private void OnDestroy()
    {
        GGSM.OnLevelStarted -= ResetCurrentScore;
        GGSM.OnGameEnded -= HighScoreCheckSet;
    }

    public int GetGameScore()
    {
        return currentGameScore;
    }

    public void UpdateGameScore(int i)
    {
        currentGameScore += i;
        OnScoreChanged(currentGameScore);
    }

    public void ResetCurrentScore()
    {
        currentGameScore = 0;
        OnScoreChanged(currentGameScore);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.HasKey("GESMPHighScore") ? PlayerPrefs.GetInt("GESMPHighScore") : 0;
    }

    public void HighScoreCheckSet()
    {
        if(!(PlayerPrefs.HasKey("GESMPHighScore")) || (PlayerPrefs.HasKey("GESMPHighScore") && PlayerPrefs.GetInt("GESMPHighScore") < currentGameScore))
        {
            PlayerPrefs.SetInt("GESMPHighScore", currentGameScore);
        }
    }
}
