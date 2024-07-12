using UnityEngine;
using UnityEngine.EventSystems;

namespace Script
{
    public class UIBag : MonoBehaviour ,IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log($"{eventData.position}");
            
        }
    }
}