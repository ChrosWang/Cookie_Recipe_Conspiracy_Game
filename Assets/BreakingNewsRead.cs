using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BreakingNewsRead : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public BreakingNewsSwapper brs;
    public GameObject Selector;
    public GameObject Reddot;
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scaleX(Selector, 1, 0.1f).setEase(LeanTweenType.easeInOutSine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scaleX(Selector, 0, 0.1f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        brs.FullPageOpen();
        Reddot.SetActive(false);
    }

}
