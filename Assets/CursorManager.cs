using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public Texture2D cursorDefault;
    public Texture2D[] cursorSpecial;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorDefault, new Vector2(cursorDefault.width / 2, cursorDefault.height / 2), CursorMode.ForceSoftware);
    }

    public void ChangeTo(int index)
    {
        Cursor.SetCursor(cursorSpecial[index], new Vector2(cursorDefault.width / 2, cursorDefault.height / 2), CursorMode.ForceSoftware);
    }

    public void ChangeDefault()
    {
        Cursor.SetCursor(cursorDefault, new Vector2(cursorDefault.width / 2, cursorDefault.height / 2), CursorMode.ForceSoftware);
    }
}
