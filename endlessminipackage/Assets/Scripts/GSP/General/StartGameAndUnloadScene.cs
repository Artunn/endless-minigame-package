using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameAndUnloadScene : MonoBehaviour
{
    public string scenename;
    public float duration, delay;
    public void OnClick()
    {
        GetComponentInParent<FadeInOutCanvas>().FadeOutCanvas(duration, delay, () => { GGSM.Instance.FireOnGameStarted(); SceneManager.UnloadSceneAsync(scenename); });
    }
}
