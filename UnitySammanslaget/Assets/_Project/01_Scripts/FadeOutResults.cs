using System;
using System.Collections;
using UnityEngine;

namespace _Project._01_Scripts
{
    public class FadeOutResults : MonoBehaviour
    {
        public FadeObject intro;
        public FadeObject clothes;
        public FadeObject recycling;
        public FadeObject cell;
        
        public GameObject restartButton;

        private void Start()
        {
            StartCoroutine(FadeOutResultsRoutine());
        }

        private IEnumerator FadeOutResultsRoutine()
        {
            intro.FadeOut();
            clothes.FadeOut();
            recycling.FadeOut();
            cell.FadeOut();

            yield return new WaitForSeconds(4f);
            
            restartButton.SetActive(true);
        }
    }
}