using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArticleBar : MonoBehaviour
{
    public TMP_Text stats;
    public NewsLoader articleloader;
    public GameObject Grow;

    public void UpdateShare()
    {
        stats.text = articleloader.numArticleShared.ToString();
        LeanTween.scaleX(Grow, (articleloader.numArticleShared / 60f), 0.3f).setEase(LeanTweenType.easeInOutCubic);

    }
}
