using System.Collections;
using UnityEngine;

namespace _Project._01_Scripts
{
    public class FadeOutTextObj : MonoBehaviour
    {
        public float fadeOutTime = 1f;
        public bool deactivateAfterFadeOut;
        
        private Coroutine fadeOutRoutine;

        public void Execute()
        {
            if (fadeOutRoutine != null)
                StopCoroutine(fadeOutRoutine);

            fadeOutRoutine = StartCoroutine(FadeOutRoutine());
        }

        private IEnumerator FadeOutRoutine()
        {
            CanvasGroup canvasGroup = TryGetComponent(out CanvasGroup canvas)
                ? canvas
                : gameObject.AddComponent<CanvasGroup>();

            float time = 0;
            while (time < fadeOutTime) {
                canvasGroup.alpha = Mathf.SmoothStep(1, 0, time / fadeOutTime);
                time += Time.deltaTime;
                yield return null;
            }

            canvasGroup.alpha = 1;
            fadeOutRoutine = null;
            
            if (deactivateAfterFadeOut && gameObject.activeInHierarchy)
                gameObject.SetActive(false);
        }
    }
}