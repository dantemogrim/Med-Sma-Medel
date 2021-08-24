using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInTextObj : MonoBehaviour
{
    public float fadeInTime = 1f;

    public bool autoFadeOut;
    public float visibleTime = 3f;
    public float fadeOutTime = 1f;
    
    public GameObject[] gameObjectsToActivate;

    private void OnEnable()
    {
        StartCoroutine(FadeInRoutine());
    }

    private IEnumerator FadeInRoutine()
    {
        CanvasGroup canvasGroup = TryGetComponent(out CanvasGroup canvas)
            ? canvas
            : gameObject.AddComponent<CanvasGroup>();

        float time = 0;
        while (time < fadeInTime) {
            canvasGroup.alpha = Mathf.SmoothStep(0, 1, time / fadeInTime);
            time += Time.deltaTime;
            yield return null;
        }

        if (!autoFadeOut)
            yield break;

        yield return new WaitForSeconds(visibleTime);
        
        time = 0;
        while (time < fadeOutTime) {
            canvasGroup.alpha = Mathf.SmoothStep(1, 0, time / fadeOutTime);
            time += Time.deltaTime;
            yield return null;
        }

        if (gameObjectsToActivate == null)
            yield break;
        
        foreach (GameObject go in gameObjectsToActivate)
            go.SetActive(true);
    }
}
