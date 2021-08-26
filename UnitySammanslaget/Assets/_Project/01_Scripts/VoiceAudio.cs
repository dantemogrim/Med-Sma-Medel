using System;
using System.Collections;
using UnityEngine;

namespace _Project._01_Scripts
{
    public class VoiceAudio : MonoBehaviour
    {
        public float delayTime = 0;
        public GameManager gameManager;
        public AudioManager audioManager;
        public string textName;
        
        private void Start() 
        {
            gameManager.voiceActivationEvent.AddListener(EventListener);

            if (gameManager.voiceActivated)
                StartCoroutine(PlayVoiceOnStartUp());
        }

        private IEnumerator PlayVoiceOnStartUp()
        {
            yield return new WaitForSeconds(delayTime);
            audioManager.PlayVoice(textName);
        }

        void EventListener() {
            audioManager.PlayVoice(textName);
        }
    }
}