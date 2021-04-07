
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadASceneLoadBScene : MonoBehaviour
{
    public string scenea, sceneb;
    public float duration, delay;

    public void DoUnloadLoad()
    {
        GetComponentInParent<FadeInOutCanvas>().FadeOutCanvas(duration, delay, () => { SceneManager.LoadSceneAsync(sceneb, LoadSceneMode.Additive); SceneManager.UnloadSceneAsync(scenea); });
    }
}
