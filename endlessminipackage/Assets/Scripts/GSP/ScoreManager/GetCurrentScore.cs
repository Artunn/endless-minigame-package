using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetCurrentScore : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = ScoreManager.Instance.GetGameScore().ToString();
    }
}
