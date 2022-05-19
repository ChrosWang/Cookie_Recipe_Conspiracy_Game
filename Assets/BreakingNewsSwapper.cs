using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BreakingNewsSwapper : MonoBehaviour
{
    public Sprite[] GS_List;
    public Sprite[] HD_List;

    public Button ReadButton;

    public int currentIndex;

    public NewsLoader articleLoader;

    public GameObject[] FullArticles;

    public Image Header;

    private void Start()
    {
        //ReadButton.onClick.AddListener(() => FullPageOpen());
    }
    public void Swap(int index)
    {
        LeanTween.alpha(this.gameObject, 0, 0.3f);
        this.gameObject.GetComponent<Image>().sprite = GS_List[index];
        Header.sprite = HD_List[index];
        //notification
        LeanTween.alpha(this.gameObject, 0, 0.3f).setDelay(0.3f);
        currentIndex = index;
    }

    public void FullPageOpen()
    {
        NewsArticle myArticle = articleLoader.myBreakingNewsCollection.News[currentIndex];
        string txt = "";
        GameObject canvas = GameObject.Find("ArticleLoader");
        canvas.GetComponent<NewsLoader>().FullArticlePage.SetActive(true);
        GameObject content = GameObject.Find("content_fullarticle");
        GameObject myFullArticle = Instantiate(FullArticles[currentIndex%4], content.transform);
        RefreshLayoutGroup(myFullArticle);
        myFullArticle.GetComponent<FullArticle>().NewsSite.text = myArticle.Source;
        myFullArticle.GetComponent<FullArticle>().Date.text = myArticle.Date;
        myFullArticle.GetComponent<FullArticle>().Title.text = myArticle.Title;
        myFullArticle.GetComponent<FullArticle>().Author.text = "Random Person";
        myFullArticle.GetComponent<FullArticle>().Body.text = "";
        myFullArticle.GetComponent<FullArticle>().news = myArticle;
        myFullArticle.GetComponent<FullArticle>().newsimage.sprite = Resources.Load<Sprite>("Pictures/GSIIArticlePics/" + myFullArticle.GetComponent<FullArticle>().news.ReferenceNr);
        if (myArticle.Paywall)
        {
            myFullArticle.GetComponent<FullArticle>().PayWall.SetActive(true);

        }
        else
        {
            myFullArticle.GetComponent<FullArticle>().PayWall.SetActive(false);
        }
        Debug.Log("current location local is:" + myFullArticle.transform.localPosition.x + "  " + myFullArticle.transform.localPosition.y);
        LeanTween.moveLocal(content, new Vector2(0f, 0f), 0f);
        LeanTween.moveLocal(myFullArticle, new Vector2(1000f, -1043f), 0f);
        LeanTween.scale(myFullArticle, new Vector3(1f, 1f, 1f), 0.3f).setEaseInOutCubic();
        DOTween.To(
                () => txt,
                x => txt = x,
                myArticle.Body,
                1.0f).SetDelay(0.3f).OnUpdate(() => myFullArticle.GetComponent<FullArticle>().Body.text = txt);

        RefreshLayoutGroup(myFullArticle);
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
