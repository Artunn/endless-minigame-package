using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUIUpdate : MonoBehaviour
{
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        GGSM.OnGameEnded += HandleGameEnd;
        GGSM.OnGameOpened += HandleGameEnd;
        HandleGameEnd();
    }

    private void OnDestroy()
    {
        GGSM.OnGameEnded -= HandleGameEnd;
        GGSM.OnGameOpened -= HandleGameEnd;
    }

    private void HandleGameEnd()
    {
        if (ScoreManager.Instance)
            tmp.text = ScoreManager.Instance.GetHighScore().ToString();
        else
            Debug.Log("GESMP No ScoreManager found.");
    }
}
