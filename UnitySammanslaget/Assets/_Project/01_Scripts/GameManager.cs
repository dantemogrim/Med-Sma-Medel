using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace _Project._01_Scripts
{
    public class GameManager : MonoBehaviour
    {
        public AudioManager audioManager;
        
        public UnityEvent voiceActivationEvent = new UnityEvent();
        
        private bool DonatedClothes { get; set; }
        private bool DonatedRecycledMoney { get; set; }
        private bool LentApartment { get; set; }

        public bool voiceActivated = true;

        public VoiceAudio clothesVoiceAudio;
        public VoiceAudio recyclingVoiceAudio;
        public VoiceAudio cellPhoneVoiceAudio;
        
        public TextMeshProUGUI clothesTMP;
        public TextMeshProUGUI recyclingTMP;
        public TextMeshProUGUI cellPhoneTMP;

        public void VoiceActivationToggle()
        {
            voiceActivated = !voiceActivated;
            
            if (voiceActivated)
                voiceActivationEvent.Invoke();
            else
                audioManager.StopVoice();
        }

        public void CheckResults()
        {
            if (!DonatedClothes) {
                clothesVoiceAudio.textName = "resultclothesb";
                clothesTMP.text = "Du valde att sälja dina kläder. Om du istället hade valt att ge bort " +
                                  "dina kläder så hade en hemlös fått dem och kunnat hålla sig varm.";
            }
            
            if (!DonatedRecycledMoney) {
                recyclingVoiceAudio.textName = "resultrecyclingb";
                recyclingTMP.text = "Du valde att ta panten själv. Om du istället hade gett bort panten " +
                                    "hade en familj kunnat få mat för kvällen.";
            }
            
            if (!LentApartment) {
                cellPhoneVoiceAudio.textName = "resultcellphoneb";
                cellPhoneTMP.text = "Du valde att hyra ut din lägenhet. Om du istället hade lånat ut " +
                                    "den hade en person i nöd kunnat få tak över huvudet.";
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}