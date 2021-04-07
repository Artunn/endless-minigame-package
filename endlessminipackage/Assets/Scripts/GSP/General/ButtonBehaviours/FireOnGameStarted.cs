using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnGameStarted : MonoBehaviour
{
    public void OnClick()
    {
        GGSM.Instance.FireOnGameStarted();
    }
}
