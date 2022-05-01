using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class SearchResultArt : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TMP_Text NewsSite;
    public TMP_Text Date;
    public TMP_Text Title;
    public TMP_Text Author;
    public TMP_Text Body;
    public GameObject MagicFix;
    public GameObject AnimationHelper;
    public Button ShareButton;
    public GameObject MyFullArticlePage;
    public LTDescr liftupanimation;
    public NewsArticle news;

    public bool is_Paywalled;
    // public GameObject content;
    public float x;
    public float y;
    public float z;

    public void Start()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
       
    {
        x = AnimationHelper.transform.localPosition.x;
        y = AnimationHelper.transform.localPosition.y;
        z = AnimationHelper.transform.localPosition.z;
        if (liftupanimation == null)
        {
            
            Vector3 p1 = new Vector3(x + 2, y + 2, z);
            Vector3 p2 = new Vector3(x + 2, y - 2, z);
            Vector3 p4 = new Vector3(x - 2, y - 2, z);
            Vector3 p3 = new Vector3(x - 2, y + 2, z);
            
            Vector3[] pointList = { p1, p2, p3, p4 };
            liftupanimation = LeanTween.moveSplineLocal(AnimationHelper, pointList, 1.0f).setLoopPingPong();
            LeanTween.scale(AnimationHelper, new Vector3(1.1f,1.1f,1.1f), 0.3f).setEaseInOutCubic();
        } else
        {
            liftupanimation.resume();
            LeanTween.scale(AnimationHelper, new Vector3(1.1f, 1.1f, 1.1f), 0.3f).setEaseInOutCubic();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mounse Exit");
        liftupanimation.pause();
        LeanTween.moveLocal(AnimationHelper, new Vector3(x, y, z), 1.0f);
        LeanTween.scale(AnimationHelper, new Vector3(1f, 1f, 1f), 0.3f).setEaseInOutCubic();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        //LeanTween.scale(AnimationHelper, new Vector3(2f, 2f, 2f), 0.3f).setEaseInOutCubic();
        //LeanTween.alpha(AnimationHelper, 0, 0.3f).setEaseInOutCubic();
        string txt = "";
        GameObject canvas = GameObject.Find("ArticleLoader");
        canvas.GetComponent<NewsLoader>().FullArticlePage.SetActive(true);
        GameObject content = GameObject.Find("content_fullarticle");
        GameObject myFullArticle = Instantiate(MyFullArticlePage, content.transform);
        RefreshLayoutGroup(myFullArticle);
        myFullArticle.GetComponent<FullArticle>().NewsSite.text = NewsSite.text;
        myFullArticle.GetComponent<FullArticle>().Date.text = Date.text;
        myFullArticle.GetComponent<FullArticle>().Title.text = Title.text;
        myFullArticle.GetComponent<FullArticle>().Author.text = Author.text;
        myFullArticle.GetComponent<FullArticle>().Body.text = "";
        myFullArticle.GetComponent<FullArticle>().news = news;
        if (news.Paywall)
        {
            myFullArticle.GetComponent<FullArticle>().PayWall.SetActive(true);
            
        } else
        {
            myFullArticle.GetComponent<FullArticle>().PayWall.SetActive(false);
        }
        Debug.Log("current location local is:" + myFullArticle.transform.localPosition.x + "  " + myFullArticle.transform.localPosition.y);
        LeanTween.moveLocal(content, new Vector2(0f, 0f), 0f);
        LeanTween.moveLocal(myFullArticle, new Vector2(1000f, -1043f), 0f);
        LeanTween.scale(myFullArticle, new Vector3(1f, 1f,1f), 0.3f).setEaseInOutCubic();
        DOTween.To(
                () => txt,
                x => txt = x,
                Body.text,
                1.0f).SetDelay(0.3f).OnUpdate(() => myFullArticle.GetComponent<FullArticle>().Body.text = txt);

        RefreshLayoutGroup(myFullArticle);
        //myFullArticle.GetComponent<FullArticle>().Title.text = Title.text;
        Debug.Log("Mounse Click");
    }

    void RefreshLayoutGroup(GameObject myArticle)
    {
        Canvas.ForceUpdateCanvases();
        myArticle.GetComponent<FullArticle>().MagicFix.GetComponent<VerticalLayoutGroup>().enabled = false;
        myArticle.GetComponent<FullArticle>().MagicFix.GetComponent<VerticalLayoutGroup>().enabled = true;
        Canvas.ForceUpdateCanvases();
        myArticle.GetComponent<FullArticle>().MagicFix.GetComponent<VerticalLayoutGroup>().enabled = false;
        myArticle.GetComponent<FullArticle>().MagicFix.GetComponent<VerticalLayoutGroup>().enabled = true;
        
        //Canvas.ForceUpdateCanvases();
    }


}
