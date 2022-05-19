using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ArticleBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TMP_Text stats;
    public NewsLoader articleloader;
    public GameObject Grow;
    public GameObject[] Badges;
    public bool[] GainBadges;

    public void UpdateShare()
    {
        stats.text = articleloader.numArticleShared.ToString();
        LeanTween.scaleX(Grow, (articleloader.numArticleShared / 60f), 0.3f).setEase(LeanTweenType.easeInOutCubic);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //LeanTween.scaleY(Grow, 2f, 0.3f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scaleY(this.gameObject, 2f, 0.3f).setEase(LeanTweenType.easeInOutCubic);
        /*float Delay = 0f;
        for (int i = 0; i < Badges.Length; i++)
        {
            if (GainBadges[i])
            {
                LeanTween.alpha(Badges[i].GetComponent<RectTransform>(), 1f, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                Delay = Delay + 0.05f;
            }
        }
        */
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // LeanTween.scaleY(Grow, 1f, 0.3f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scaleY(this.gameObject, 1f, 0.3f).setEase(LeanTweenType.easeInOutCubic);
        /*
        for (int i = 0; i < Badges.Length; i++)
        {
            if (GainBadges[i])
            {
                LeanTween.alpha(Badges[i].GetComponent<RectTransform>(), 0f, 0.3f).setEase(LeanTweenType.easeInOutCubic);
                
            }
        }
        */
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

}
