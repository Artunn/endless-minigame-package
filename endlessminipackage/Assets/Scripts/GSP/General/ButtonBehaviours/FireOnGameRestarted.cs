using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnGameRestarted : MonoBehaviour
{
    public void RestartGame()
    {
        GGSM.Instance.FireOnRestartGame();
    }
}
