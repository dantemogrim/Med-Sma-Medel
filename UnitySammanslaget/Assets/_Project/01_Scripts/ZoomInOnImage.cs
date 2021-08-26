using System.Collections;
using UnityEngine;

namespace _Project._01_Scripts
{
    public class ZoomInOnImage : MonoBehaviour
    {
        private RectTransform rectTransform;
    
        public float zoomInTime = 3f;
    
        public float posX = 0f;
        public float posY = 450f;
        public float scaleX = 3f;
        public float scaleY = 3f;
    
        public GameObject[] gameObjectsToActivate;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void Execute()
        {
            StartCoroutine(ZoomInRoutine());
        }

        private IEnumerator ZoomInRoutine()
        {
            float time = 0;
            while (time < zoomInTime) {
                float newPosX = Mathf.SmoothStep(0, posX, time / zoomInTime);
                float newPosY = Mathf.SmoothStep(0, posY, time / zoomInTime);
                rectTransform.localPosition = new Vector3(newPosX, newPosY, 0);
            
                float newScaleX = Mathf.SmoothStep(1, scaleX, time / zoomInTime);
                float newScaleY = Mathf.SmoothStep(1, scaleY, time / zoomInTime);
                rectTransform.localScale = new Vector3(newScaleX, newScaleY, 0);
            
                time += Time.deltaTime;
                yield return null;
            }
        
            if (gameObjectsToActivate == null)
                yield break;
        
            foreach (GameObject go in gameObjectsToActivate)
                go.SetActive(true);
        }
    }
}
