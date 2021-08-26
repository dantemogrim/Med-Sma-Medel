using System;
using UnityEngine;

namespace _Project._01_Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource audioSourceFX;
        public AudioSource audioSourceBG;
        public AudioSource audioSourceVoice;

        public float fxVolume = 1f;
        public float bgVolume = 1f;
        public float voiceVolume = 1f;
        
        public AudioClip arrowClip;

        public AudioClip streetBgClip;
        public AudioClip recyclingBgClip;

        public AudioClip introVoiceClip;
        public AudioClip clothesVoiceClip;
        public AudioClip preRecyclingVoiceClip;
        public AudioClip recyclingVoiceClip;
        public AudioClip preCellPhoneVoiceClip;
        public AudioClip cellPhoneVoiceClip;
        public AudioClip endVoiceClip;
        public AudioClip resultIntroClip;
        public AudioClip resultClothesA;
        public AudioClip resultClothesB;
        public AudioClip resultRecyclingA;
        public AudioClip resultRecyclingB;
        public AudioClip resultCellPhoneA;
        public AudioClip resultCellPhoneB;

        public bool audioOff;
        public float currentFxVolume;

        private void Start()
        {
            SetVolume();
        }

        private void SetVolume()
        {
            currentFxVolume = fxVolume;
            audioSourceBG.volume = bgVolume;
            audioSourceVoice.volume = voiceVolume;
        }

        public void PlayFX(string audioName)
        {
            if (audioName == "arrow") {
                audioSourceFX.PlayOneShot(arrowClip, currentFxVolume);
            }
        }
        
        public void PlayBG(string audioName)
        {
            audioSourceBG.clip = audioName switch {
                "streetbg" => streetBgClip,
                "recyclingbg" => recyclingBgClip,
                _ => null
            };
            
            audioSourceBG.Play();
        }
        
        public void PlayVoice(string audioName)
        {
            audioSourceVoice.clip = audioName switch {
                "intro" => introVoiceClip,
                "clothes" => clothesVoiceClip,
                "prerecycling" => preRecyclingVoiceClip,
                "recycling" => recyclingVoiceClip,
                "precellphone" => preCellPhoneVoiceClip,
                "cellphone" => cellPhoneVoiceClip,
                "end" => endVoiceClip,
                "result" => resultIntroClip,
                "resultclothesa" => resultClothesA,
                "resultclothesb" => resultClothesB,
                "resultrecyclinga" => resultRecyclingA,
                "resultrecyclingb" => resultRecyclingB,
                "resultcellphonea" => resultCellPhoneA,
                "resultcellphoneb" => resultCellPhoneB,
                _ => null
            };
            
            audioSourceVoice.Play();
        }
        
        public void StopBG()
        {
            audioSourceBG.Stop();
        }
        
        public void StopVoice()
        {
            audioSourceVoice.Stop();
        }

        public void AudioOffToggle()
        {
            audioOff = !audioOff;

            if (audioOff) {
                currentFxVolume = 0;
                audioSourceBG.volume = 0;
                audioSourceVoice.volume = 0;
            }
            else {
                SetVolume();
            }
        }
    }
}