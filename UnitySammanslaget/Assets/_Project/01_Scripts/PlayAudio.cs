using System;
using UnityEngine;

namespace _Project._01_Scripts
{
    public class PlayAudio : MonoBehaviour
    {
        public AudioClip arrowClip;
        public float arrowVolume = 1f;
        
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShot(string name)
        {
            if (name == "arrow") {
                audioSource.PlayOneShot(arrowClip, arrowVolume);
            }
        }
    }
}