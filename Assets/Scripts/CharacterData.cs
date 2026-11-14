using System;
using UnityEngine;

[Serializable]
public class CharacterData
{
    [Header("Character Identity")]
    public string id;

    [Header("Expressions")]
    public Sprite normal;
    public Sprite happy;
    public Sprite angry;
    public Sprite sad;

    public Sprite GetExpression(string expression)
    {
        switch (expression.ToLower())
        {
            case "happy": return happy;
            case "angry": return angry;
            case "sad": return sad;
            default: return normal;
        }
    }
}
