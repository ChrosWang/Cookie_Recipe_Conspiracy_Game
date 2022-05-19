using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject stateMachine;
    public GameObject Selector;

    public int Mode;

    //public LTDescr SelectAnimation;
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
        stateMachine.GetComponent<StateMachine>().ChangeTabNum(Mode);
    }
}
