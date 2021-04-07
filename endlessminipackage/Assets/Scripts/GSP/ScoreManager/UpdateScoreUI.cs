using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UpdateScoreUI : MonoBehaviour
{

    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        ScoreManager.OnScoreChanged += HandleScoreChange;
    }

    private void HandleScoreChange(int obj)
    {
        text.text = obj.ToString();
    }
}
