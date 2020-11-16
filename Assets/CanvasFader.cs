using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanvasFader : MonoBehaviour
{
    private bool isFadingOut = false;
    private Action fadeOutCallback = null;

    public void FadeOut(Action callback)
    {
        if (isFadingOut)
        {
            return;
        }

        fadeOutCallback = callback;
        isFadingOut = true;
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        CanvasGroup canvasGroup = this.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("canvas renderer was null when trying to fade it out");
            yield break;
        }

        var totalAnimationTime = 2f;
        var elapsedTime = 0f;
        var startingAlpha = canvasGroup.alpha;

        while (elapsedTime < totalAnimationTime)
        {
            elapsedTime += Time.deltaTime;
            var pctDone = elapsedTime / totalAnimationTime;
            canvasGroup.alpha = Mathf.Lerp(startingAlpha, 0, pctDone);
            yield return null;
        }

        if (fadeOutCallback == null)
        {
            Debug.LogError("fade out finished but there was no callback!");
        } else
        {
            fadeOutCallback();
        }
    }
}
