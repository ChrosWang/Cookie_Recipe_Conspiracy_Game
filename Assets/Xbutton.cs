using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Xbutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public GameObject Article;
    public GameObject Selector;
    //public LTDescr SelectAnimation;
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scaleX(Selector, 1, 0.2f).setEase(LeanTweenType.easeInOutSine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scaleX(Selector, 0, 0.2f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject canvas = GameObject.Find("ArticleLoader");
        canvas.GetComponent<NewsLoader>().FullArticlePage.SetActive(false);
        GameObject.Destroy(Article);

    }
}
