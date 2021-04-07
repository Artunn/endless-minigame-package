using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSExampleScene : MonoBehaviour
{
   public void FireGameEnded()
    {
        GGSM.Instance.FireOnGameEnded();
    }

    public void AddScore()
    {
        ScoreManager.Instance.UpdateGameScore(4);
    }
}
