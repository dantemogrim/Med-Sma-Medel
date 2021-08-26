using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace _Project._01_Scripts
{
    public class SlideImage : MonoBehaviour
    {
        public float slideTime = 3f;
    
        public float newPosX = 0f;
        public float newPosY = 450f;

        public GameObject[] gameObjectsToActivate;

        private RectTransform rectTransform;
        private float originalPosX;
        private float originalPosY;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            Vector3 localPosition = rectTransform.localPosition;
            originalPosX = localPosition.x;
            originalPosY = localPosition.y;
        }

        public void SlideVertical()
        {
            StartCoroutine(SlideVerticalRoutine());
        }
        
        public void SlideHorizontal()
        {
            StartCoroutine(SlideHorizontalRoutine());
        }

        public void ResetPosition()
        {
            StartCoroutine(ResetPositionRoutine());
        }

        private IEnumerator SlideVerticalRoutine()
        {
            float time = 0;
            while (time < slideTime) {
                float posY = Mathf.SmoothStep(originalPosY, newPosY, time / slideTime);
                rectTransform.localPosition = new Vector3(originalPosX, posY, 0);
                time += Time.deltaTime;
                yield return null;
            }
        
            if (gameObjectsToActivate == null)
                yield break;

            foreach (GameObject go in gameObjectsToActivate)
                go.SetActive(true);
        }
        
        private IEnumerator SlideHorizontalRoutine()
        {
            float time = 0;
            while (time < slideTime) {
                float posX = Mathf.SmoothStep(originalPosX, newPosX, time / slideTime);
                rectTransform.localPosition = new Vector3(posX, originalPosY, 0);
                time += Time.deltaTime;
                yield return null;
            }
        
            if (gameObjectsToActivate == null)
                yield break;

            foreach (GameObject go in gameObjectsToActivate)
                go.SetActive(true);
        }
        
        private IEnumerator ResetPositionRoutine()
        {
            Vector3 localPosition = rectTransform.localPosition;
            float currentPosX = localPosition.x;
            float currentPosY = localPosition.y;
            float time = 0;
            while (time < slideTime) {
                float posX = Mathf.SmoothStep(currentPosX, originalPosX, time / slideTime);
                float posY = Mathf.SmoothStep(currentPosY, originalPosY, time / slideTime);
                rectTransform.localPosition = new Vector3(posX, posY, 0);
                
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}