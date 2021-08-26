using UnityEngine;

namespace _Project._01_Scripts
{
    public class GameObjectActivationToggle : MonoBehaviour
    {
        public void Execute()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }
    }
}