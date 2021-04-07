using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnGameQuit : MonoBehaviour
{
   public void QuitGame()
    {
        GGSM.Instance.FireOnGameQuit();
    }
}
