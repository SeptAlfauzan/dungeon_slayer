
using System;
using System.Collections;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursorSprite;
    private void OnMouseEnter() {
        
    }


    void Start()
    {
        // Cursor.visible = false;
        Cursor.SetCursor(cursorSprite,Vector2.zero,CursorMode.Auto);
    }

    // private static void SetCursor(object cursorSprite, Vector2 zero, CursorMode forceSoftware)
    // {
    //     throw new NotImplementedException();
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
