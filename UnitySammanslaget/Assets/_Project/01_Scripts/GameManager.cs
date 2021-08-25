using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace _Project._01_Scripts
{
    public class GameManager : MonoBehaviour
    {
        public AudioManager audioManager;
        
        public UnityEvent voiceActivationEvent = new UnityEvent();
        public bool DonatedClothes { get; set; }
        public bool DonatedRecycledMoney { get; set; }
        public bool LentApartment { get; set; }

        public bool voiceActivated;

        public void VoiceActivationToggle()
        {
            voiceActivated = !voiceActivated;
            
            if (voiceActivated)
                voiceActivationEvent.Invoke();
            else
                audioManager.StopVoice();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}