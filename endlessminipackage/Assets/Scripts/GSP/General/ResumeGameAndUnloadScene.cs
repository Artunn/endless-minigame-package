using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeGameAndUnloadScene : MonoBehaviour
{
    public float duration, delay;
    public string scenename;
    public void ResumeAndUnload()
    {
        GetComponentInParent<FadeInOutCanvas>().FadeOutCanvas(duration, delay, () => { GGSM.Instance.FireOnGameResumed(); SceneManager.UnloadSceneAsync(scenename); });
    }
}
