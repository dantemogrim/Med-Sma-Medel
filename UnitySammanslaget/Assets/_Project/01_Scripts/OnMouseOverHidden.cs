using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project._01_Scripts
{
    public class OnMouseOverHidden : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject hiddenText;

        public void OnPointerEnter(PointerEventData eventData)
        {
            hiddenText.SetActive(true);
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            hiddenText.SetActive(false);
        }
    }
}
