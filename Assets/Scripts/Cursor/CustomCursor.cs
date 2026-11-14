using System;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public static CustomCursor Instance;
    [SerializeField] private Texture2D normalCursor;
    [SerializeField] private Texture2D hoverCursor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SetNormal();
    }
    public void SetNormal()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }
    public void SetHover()
    {
        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }
}
