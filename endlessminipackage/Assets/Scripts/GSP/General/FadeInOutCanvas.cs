using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutCanvas : MonoBehaviour
{
    public bool disableOnStart;
    private CanvasGroup canvasgroup;
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvasgroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        if (disableOnStart)
            DisableCanvas();
        else
            EnableCanvas();
    }

    public void FadeInCanvas(float duration, float delay)
    {
        canvas.enabled = true;
        LeanTween.alphaCanvas(canvasgroup, 1f, duration).setFrom(0f).setIgnoreTimeScale(true).setOnComplete(EnableCanvas).setDelay(delay);
    }

    public void FadeInCanvas(float duration, float delay,Action p)
    {
        canvas.enabled = true;
        LeanTween.alphaCanvas(canvasgroup, 1f, duration).setFrom(0f).setIgnoreTimeScale(true).setOnComplete(()=> { EnableCanvas(); p(); }).setDelay(delay);
    }

    private void EnableCanvas()
    {
        canvasgroup.alpha = 1f;
        canvasgroup.interactable = true;
        canvasgroup.blocksRaycasts = true;
    }

    public void FadeOutCanvas(float duration,float delay)
    {
        canvasgroup.interactable = false;
        canvasgroup.blocksRaycasts = false;
        LeanTween.alphaCanvas(canvasgroup, 0f, duration).setFrom(1f).setIgnoreTimeScale(true).setOnComplete(DisableCanvas).setDelay(delay);
    }

    public void FadeOutCanvas(float duration, float delay, Action p)
    {
        canvasgroup.interactable = false;
        canvasgroup.blocksRaycasts = false;
        LeanTween.alphaCanvas(canvasgroup, 0f, duration).setFrom(1f).setIgnoreTimeScale(true).setOnComplete(() => { DisableCanvas(); p(); }).setDelay(delay);
    }

    private void DisableCanvas()
    {
        canvasgroup.alpha = 0;
        canvas.enabled = false;
    }
}
