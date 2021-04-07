using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnGameFreezed : MonoBehaviour
{
    public void FreezeGame()
    {
        GGSM.Instance.FireOnGameFreezed();
    }
}
