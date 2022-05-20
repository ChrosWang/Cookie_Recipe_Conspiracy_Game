using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbleTheScroll : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{

    
    public GameObject Scroll;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Im in");
        Scroll.GetComponent<ScrollRect>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Scroll.GetComponent<ScrollRect>().enabled = false;
    }

}
