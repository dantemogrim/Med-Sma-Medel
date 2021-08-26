using System.Collections;
using UnityEngine;

namespace _Project._01_Scripts
{
    public class FadeInObj : MonoBehaviour
    {
        public float delayTime = 0f;
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
            canvasGroup.alpha = 0;

            yield return new WaitForSeconds(delayTime);

            float time = 0;
            while (time < fadeInTime) {
                canvasGroup.alpha = Mathf.SmoothStep(0, 1, time / fadeInTime);
                time += Time.deltaTime;
                yield return null;
            }
        
            if (gameObjectsToActivate == null)
                yield break;
        
            yield return new WaitForSeconds(visibleTime);

            foreach (GameObject go in gameObjectsToActivate)
                go.SetActive(true);

            if (!autoFadeOut)
                yield break;
        
            time = 0;
            while (time < fadeOutTime) {
                canvasGroup.alpha = Mathf.SmoothStep(1, 0, time / fadeOutTime);
                time += Time.deltaTime;
                yield return null;
            }


        }
    }
}
