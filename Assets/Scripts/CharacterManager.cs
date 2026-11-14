
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [Header("Character Positions")]
    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image centerCharacter;
    [SerializeField] private Image rightCharacter;

    [Header("Character Database")]
    [SerializeField] private List<CharacterData> characters;

    // CharacterData
    private Dictionary<string, CharacterData> characterDatabase;

    // Character ID
    private Dictionary<string, string> activeCharacters =
        new Dictionary<string, string>();

    private void Awake()
    {
        characterDatabase = new Dictionary<string, CharacterData>();

        foreach (CharacterData character in characters)
        {
            if (character == null ||
                string.IsNullOrWhiteSpace(character.id))
                continue;

            characterDatabase[character.id.Trim()] = character;
        }
    }

    private void Start()
    {
        HideAll();
    }

    public void ShowCharacter(
        string characterId,
        string position,
        string expression = "normal")
    {
        characterId = characterId.Trim();
        position = position.Trim().ToLower();

        Image target = GetPosition(position);

        if (target == null)
            return;

        if (!characterDatabase.TryGetValue(
            characterId, out CharacterData character))
        {
            Debug.LogWarning("Character not found: " + characterId);
            return;
        }

        Sprite sprite = character.GetExpression(expression);

        if (sprite == null)
        {
            Debug.LogWarning(
                "Expression sprite missing: " + expression
            );
            return;
        }
        //Hide 
        HideCharByName(characterId);

        // new sprite
        target.sprite = sprite;
        target.color = Color.white;
        target.preserveAspect = true;
        target.enabled = true;

        activeCharacters[position] = characterId;
    }

    public void HideCharByName(string characterId)
    {
        characterId = characterId.Trim();

        List<string> positionsToHide = new List<string>();

        foreach (var entry in activeCharacters)
        {
            if (entry.Value == characterId)
            {
                positionsToHide.Add(entry.Key);
            }
        }

        foreach (string position in positionsToHide)
        {
            HideCharacter(position);
        }
    }

    public void HideCharacter(string position)
    {
        position = position.Trim().ToLower();

        Image target = GetPosition(position);

        if (target == null)
            return;

        target.enabled = false;
        target.sprite = null;

        activeCharacters.Remove(position);
    }

    public void HideAll()
    {
        HideCharacter("left");
        HideCharacter("center");
        HideCharacter("right");
    }

    private Image GetPosition(string position)
    {
        switch (position.Trim().ToLower())
        {
            case "left":
                return leftCharacter;

            case "center":
                return centerCharacter;

            case "right":
                return rightCharacter;

            default:
                Debug.LogWarning(
                    "Invalid position: " + position
                );
                return null;
        }
    }
}
