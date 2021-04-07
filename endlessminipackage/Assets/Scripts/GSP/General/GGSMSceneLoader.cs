using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GGSMSceneLoader : MonoBehaviour
{
    public static bool isInGameOpen, isFreezeOpen, isSettingsOpen;
    //public string mainscene;

    private void Start()
    {
        isInGameOpen = false;
        isFreezeOpen = false;
        isSettingsOpen = false;
        GGSM.OnGameFreezed += HandleFreezeScene;
        GGSM.OnGameStarted += HandleGameStart;
        GGSM.OnRestartGame += HandleGameRestart;
        GGSM.OnGameEnded += HandleGameEnd;
        HandleGameOpen();
    }

    private void OnDestroy()
    {
        GGSM.OnGameFreezed -= HandleFreezeScene;
        GGSM.OnGameStarted -= HandleGameStart;
        GGSM.OnRestartGame -= HandleGameRestart;
        GGSM.OnGameEnded -= HandleGameEnd;
    }

    void HandleGameStart()
    {
        if (!isInGameOpen)
        {
            SceneManager.LoadSceneAsync("GSInGameScene", LoadSceneMode.Additive);
            isInGameOpen = true;
        }
    }

    void HandleFreezeScene()
    {
        if (!isFreezeOpen)
        {
            SceneManager.LoadSceneAsync("GSGamePausedScene", LoadSceneMode.Additive);
            isFreezeOpen = true;
        }
    }

    void HandleGameRestart()
    {
        ScoreManager.Instance.HighScoreCheckSet();
        //SceneManager.LoadScene(mainscene);
        SceneManager.LoadScene(0);
    }

    void HandleGameOpen()
    {
        SceneManager.LoadSceneAsync("GSGameStartScene", LoadSceneMode.Additive);
    }

    void HandleGameEnd()
    {
        SceneManager.LoadSceneAsync("GSGameEndedScene", LoadSceneMode.Additive);
    }
}
