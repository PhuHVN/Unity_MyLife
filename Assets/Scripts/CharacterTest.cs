
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterTest : MonoBehaviour
{
    [SerializeField] private CharacterManager characterManager;

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            characterManager.ShowCharacter("Linh", "left");
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            characterManager.ShowCharacter("Minh", "right");
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            characterManager.HideCharacter("right");
        }
    }
}
