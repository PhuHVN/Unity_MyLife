using UnityEngine;
using UnityEngine.EventSystems;

public class CursorHover : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CustomCursor.Instance.SetHover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CustomCursor.Instance.SetNormal();
    }
}

  
