using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CursorManager cursormanager;
    public int ChangeMode;

    public void OnPointerEnter(PointerEventData eventData)
    {
        cursormanager.ChangeTo(ChangeMode);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursormanager.ChangeDefault();
    }

}
