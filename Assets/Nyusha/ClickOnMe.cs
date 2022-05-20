using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnMe : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] slides;
    int slideCount;
    public GameObject arrow;

void Start()
    {
        slideCount = 0;
        LeanTween.alpha(arrow.GetComponent<RectTransform>(),0f,0f); 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

     public void NextSlide()
    {
        Debug.Log("button clicked");
        slides[slideCount].SetActive(false);
        slideCount++;

        if (slideCount == 1)
        {
            // public TMP_Text Tmp1;
            // [TextArea(10, 100)] 
            // public string String1;
            // public TMP_Text Tmp2;
            // [TextArea(10, 100)] 
            // public string String2;
            // public TMP_Text Tmp3;
            // [TextArea(10, 100)] 
            // public string String3;
        }

        if (slideCount == 2)
        {
            // public TMP_Text Tmp1;
            // [TextArea(10, 100)] 
            // public string String1;
            // public TMP_Text Tmp2;
            // [TextArea(10, 100)] 
            // public string String2;
            // public TMP_Text Tmp3;
            // [TextArea(10, 100)] 
            // public string String3;
        }
    }
}