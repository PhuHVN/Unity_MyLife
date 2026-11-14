using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler,IPointerClickHandler
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button.interactable && UIAudioManager.Instance != null)
        {
            UIAudioManager.Instance.PlayHover();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left &&
            button.interactable &&
            UIAudioManager.Instance != null)
        {
            UIAudioManager.Instance.PlayClick();
        }
    }
}
