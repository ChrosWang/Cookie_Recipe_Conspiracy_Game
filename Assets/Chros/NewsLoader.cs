using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class NewsLoader : MonoBehaviour
{
    public TextAsset SpreadSheetJSON;
    //google spreadsheet
    public NewsCollection myNewsCollection = new NewsCollection();

    public ChatManager Chat;

    public Button SearchButton;
    public Button CurrentScoreButton;
    //public Button ShareButton1;
    //public Button ShareButton2;
   // public Button ShareButton3;

   // public GameObject ShareStats1;
    //public GameObject ShareStats2;
   // public GameObject ShareStats3;
    //public Image ShareStats2;
    // public Image ShareStats3;

    public Text textField;
    public Text scoreField; 

    //public TMP_Text SearchResult1Title;
   // public TMP_Text SearchResult2Title;
   // public TMP_Text SearchResult3Title;
   // public TMP_Text Algorithm1Title;
   // public TMP_Text Algorithm2Title;

   // public TMP_Text SearchResult1Body;
   // public TMP_Text SearchResult2Body;
   // public TMP_Text SearchResult3Body;
   // public TMP_Text Algorithm1Body;
   // public TMP_Text Algorithm2Body;

    public TMP_Text SearchResultStats;
    public NewPostCreator newPostCreater;

   // public Button TestButton;


    public GameObject Article1;
    public GameObject Article2;
    public GameObject Article3;
    public GameObject Article4;
    public GameObject Article5;
    public GameObject Article6;
    public GameObject Article7;
    public GameObject YouMightLike;
    public GameObject SearchResultGroup;


    public int currentCP;

    public int searchCount;

    public PopUpSystem popupsystem;

    public int numArticleShared;
    // Start is called before the first frame update
    void Start()
    {
        
       // CurrentScoreButton.onClick.AddListener(() => RefreshNewsFeed());

       // ShareButton1.onClick.AddListener(() => UpdateShare1());

      //  ShareButton2.onClick.AddListener(() => UpdateShare2());

      //  ShareButton3.onClick.AddListener(() => UpdateShare3());

        //TestButton.onClick.AddListener(() => {
           // Debug.Log("CLicked");
            //newPostCreater.MakePost(myNewsCollection.News[4]);
    //    newPostCreater.MakePost(myNewsCollection.News[4]);
      //  newPostCreater.MakePost(myNewsCollection.News[5]);
        //});

    }
    /*
    void RefreshNewsFeed ()
    {
        myNewsCollection.generateNewsFeed(currentCP);
        RefreshTwo(RefreshOne());
    }
    */
    public void Initialization()
    {
        myNewsCollection = JsonUtility.FromJson<NewsCollection>("{\"News\":" + SpreadSheetJSON.text + "}");
        Debug.Log(myNewsCollection.News[0].Title);
        Debug.Log(myNewsCollection.News[0].Date);
        Debug.Log(myNewsCollection.News[0].Body);

        currentCP = 0;
        //RefreshNewsFeed();

        SearchButton.onClick.AddListener(() => SearchMyCollection(textField.text));
    }
    public void MakePost(int index)
    {
        newPostCreater.MakePost(myNewsCollection.News[index]);
    }
    void  UpdateShare(int index)
    {
        if (!myNewsCollection.RetrieveNewsArticle(index).Is_shared) {
            Debug.Log("Adding CP: " + currentCP + "to score for "  + myNewsCollection.RetrieveNewsArticle(0).Score);
            currentCP = currentCP + myNewsCollection.RetrieveNewsArticle(index).Score;
            myNewsCollection.RetrieveNewsArticle(0).Is_shared = true;
            popupsystem.CreatePopUp(4, new PopUpMessage("",  "", 0,0));
            numArticleShared++;
           // ShareStats1.SetActive(true);
          //  ShareStats1.GetComponent<RandomGenerateStats>().RandomGenerate(myNewsCollection.RetrieveNewsArticle(0).Score, myNewsCollection.RetrieveNewsArticle(0).Priority);
            newPostCreater.MakePost(myNewsCollection.RetrieveNewsArticle(index));
        }
        Debug.Log("current cp is " + currentCP);
        
    }
   /* void UpdateShare2()
    {
        if (!myNewsCollection.RetrieveNewsArticle(1).Is_shared)
        {
            Debug.Log("Adding CP: " + currentCP + "to score for " + myNewsCollection.RetrieveNewsArticle(1).Score);
            currentCP = currentCP + myNewsCollection.RetrieveNewsArticle(1).Score;
            myNewsCollection.RetrieveNewsArticle(1).Is_shared = true;
        }
        Debug.Log("current cp is " + currentCP);
        ShareStats2.SetActive(true);
        ShareStats2.GetComponent<RandomGenerateStats>().RandomGenerate(myNewsCollection.RetrieveNewsArticle(1).Score, myNewsCollection.RetrieveNewsArticle(1).Priority);
    }
    void UpdateShare3()
    {
        if (!myNewsCollection.RetrieveNewsArticle(2).Is_shared)
        {
            Debug.Log("Adding CP: " + currentCP + "to score for " + myNewsCollection.RetrieveNewsArticle(2).Score);
            currentCP = currentCP + myNewsCollection.RetrieveNewsArticle(2).Score;
            myNewsCollection.RetrieveNewsArticle(2).Is_shared = true;
        }
        Debug.Log("current cp is " + currentCP);
        ShareStats3.SetActive(true);
        ShareStats3.GetComponent<RandomGenerateStats>().RandomGenerate(myNewsCollection.RetrieveNewsArticle(2).Score, myNewsCollection.RetrieveNewsArticle(2).Priority);
    }
   */
    void SearchMyCollection(string keyword)
    {
        foreach (Transform child in SearchResultGroup.GetComponent<Transform>())
        {
            GameObject.Destroy(child.gameObject);
        }
        // Debug.Log("Search with " + keyword);
        searchCount = searchCount + 1; 
        //ShareStats1.SetActive(false);
        //ShareStats2.SetActive(false);
        //ShareStats3.SetActive(false);
        myNewsCollection.SearchForKeyWord(keyword);
        SearchResultStats.text = "Found " + myNewsCollection.searchResultStat.ToString() + " matched results.";
        int delay = 0;
        delay = delay + RetrieveNumber(0, 0);
        delay = delay + RetrieveNumber(1, delay);
        delay = delay + RetrieveNumber(2, delay);
        GameObject myUml = Instantiate(YouMightLike, SearchResultGroup.GetComponent<RectTransform>());
        LeanTween.alpha(myUml.GetComponent<RectTransform>(), 1, 0.3f).setDelay(0.1f * delay).setEase(LeanTweenType.easeInExpo);
        delay = delay + RetrieveNumber(-1, delay);
        delay = delay + RetrieveNumber(-1, delay);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SearchMyCollection(textField.text);
        }

        //if (searchCount >=3)
      ///  {
      //      RefreshNewsFeed();
        //    searchCount = 0;
       // }

    }

    /*
    int RefreshOne ()
    {
        int randomIndex  = Random.Range(1, myNewsCollection.newsAlgorithm[0]);
        Debug.Log("1 generated " + randomIndex + "between 1 and " + (myNewsCollection.newsAlgorithm[0]));
        Algorithm1Title.text =  myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Title + " " + myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Date;
        Algorithm1Body.text = myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Body;
        return randomIndex;
    }
    void RefreshTwo(int indexOne)
    {
        int randomIndex = Random.Range(1, myNewsCollection.newsAlgorithm[0]);
        Debug.Log("2 generated " + randomIndex + "between 1 and " + (myNewsCollection.newsAlgorithm[0]));
        if (randomIndex == indexOne && myNewsCollection.newsAlgorithm[0]>1)
        {
            while (randomIndex == indexOne)
            {
                randomIndex = Random.Range(1, myNewsCollection.newsAlgorithm[0]);
            }
        }
        Algorithm2Title.text = myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Title + " " + myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Date;
        Algorithm2Body.text = myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Body;
    }
    */

    int RetrieveNumber (int index, int order)
    {
        GameObject myNews;
        string txt = "";

        if (index >= 0)
        {
            if (myNewsCollection.SearchList[index] == 0)
            {
                return 0;
            }
            
            switch (myNewsCollection.RetrieveNewsArticle(index).SourceNum)
            {
                case 1:
                    myNews = Instantiate(Article1, SearchResultGroup.GetComponent<RectTransform>());
                    break;

                case 2:
                    myNews = Instantiate(Article2, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 3:
                    myNews = Instantiate(Article3, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 4:
                    myNews = Instantiate(Article4, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 5:
                    myNews = Instantiate(Article5, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 6:
                    myNews = Instantiate(Article6, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 7:
                    myNews = Instantiate(Article7, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                default:
                    myNews = Instantiate(Article1, SearchResultGroup.GetComponent<RectTransform>());
                    break;
            }

            LeanTween.alpha(myNews.GetComponent<SearchResultArt>().AnimationHelper.GetComponent<RectTransform>(), 0, 0);
            LeanTween.scale(myNews.GetComponent<SearchResultArt>().AnimationHelper, new Vector3(1.3f, 1.3f, 1.3f), 0);
            //myNews.GetComponent<SearchResultArt>().NewsSite.text = myNewsCollection.RetrieveNewsArticle(index).Source;
            myNews.GetComponent<SearchResultArt>().NewsSite.text = "";
            //myNews.GetComponent<SearchResultArt>().Date.text = myNewsCollection.RetrieveNewsArticle(index).Date;
            myNews.GetComponent<SearchResultArt>().Date.text = "";
            //myNews.GetComponent<SearchResultArt>().Title.text = myNewsCollection.RetrieveNewsArticle(index).Title;
            myNews.GetComponent<SearchResultArt>().Title.text = "";
            //myNews.GetComponent<SearchResultArt>().Body.text = myNewsCollection.RetrieveNewsArticle(index).Body;
            myNews.GetComponent<SearchResultArt>().Body.text = "";
            myNews.GetComponent<SearchResultArt>().Author.text = "";

            myNews.GetComponent<SearchResultArt>().ShareButton.onClick.AddListener(() => UpdateShare(index));

            DOTween.To(
                () => txt,
                x => txt = x,
                myNewsCollection.RetrieveNewsArticle(index).Source,
                0.1f).SetDelay(0.2f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().NewsSite.text = txt);
            DOTween.To(
                () => txt,
                x => txt = x,
                myNewsCollection.RetrieveNewsArticle(index).Date,
                0.1f).SetDelay(0.3f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().Date.text = txt);
            DOTween.To(
                () => txt,
                x => txt = x,
                myNewsCollection.RetrieveNewsArticle(index).Title,
                0.2f).SetDelay(0.4f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().Title.text = txt);
            DOTween.To(
               () => txt,
               x => txt = x,
               "Written By Random Person",
               0.1f).SetDelay(0.6f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().Author.text = txt);
            DOTween.To(
                () => txt,
                x => txt = x,
                myNewsCollection.RetrieveNewsArticle(index).Body,
                0.5f).SetDelay(0.7f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().Body.text = txt);



            //Canvas.ForceUpdateCanvases();
            //myNews.GetComponent<SearchResultArt>().MagicFix.GetComponent<VerticalLayoutGroup>().enabled = false;
            //myNews.GetComponent<SearchResultArt>().MagicFix.GetComponent<VerticalLayoutGroup>().enabled = true;
            LeanTween.scale(myNews.GetComponent<SearchResultArt>().AnimationHelper, new Vector3(1f, 1f, 1f), 0.3f).setDelay(0.1f * order).setEase(LeanTweenType.easeInExpo);
            LeanTween.moveLocalX(myNews.GetComponent<SearchResultArt>().AnimationHelper, 0, 0.4f).setDelay(0.1f * order).setEase(LeanTweenType.easeInOutCubic);
            LeanTween.alpha(myNews.GetComponent<SearchResultArt>().AnimationHelper.GetComponent<RectTransform>(), 1, 0.3f).setDelay(0.1f * order).setEase(LeanTweenType.easeInExpo);
            /*
            SearchResult1Title.text = myNewsCollection.RetrieveNewsArticle(0).Title + " " + myNewsCollection.RetrieveNewsArticle(0).Date;
            SearchResult1Body.text = myNewsCollection.RetrieveNewsArticle(0).Body;
            SearchResult2Title.text = myNewsCollection.RetrieveNewsArticle(1).Title + " " + myNewsCollection.RetrieveNewsArticle(1).Date;
            SearchResult2Body.text = myNewsCollection.RetrieveNewsArticle(1).Body;
            SearchResult3Title.text = myNewsCollection.RetrieveNewsArticle(2).Title + " " + myNewsCollection.RetrieveNewsArticle(2).Date;
            SearchResult3Body.text = myNewsCollection.RetrieveNewsArticle(2).Body;
            */
        } else
        {
            myNewsCollection.generateNewsFeed(currentCP);
            int randomIndex = Random.Range(1, myNewsCollection.newsAlgorithm[0]);
            switch (myNewsCollection.RetrieveAlgoritmArticle(randomIndex).SourceNum)
            {
                case 1:
                    myNews = Instantiate(Article1, SearchResultGroup.GetComponent<RectTransform>());
                    break;

                case 2:
                    myNews = Instantiate(Article2, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 3:
                    myNews = Instantiate(Article3, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 4:
                    myNews = Instantiate(Article4, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 5:
                    myNews = Instantiate(Article5, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 6:
                    myNews = Instantiate(Article6, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                case 7:
                    myNews = Instantiate(Article7, SearchResultGroup.GetComponent<RectTransform>());
                    break;
                default:
                    myNews = Instantiate(Article1, SearchResultGroup.GetComponent<RectTransform>());
                    break;
            }

            LeanTween.alpha(myNews.GetComponent<SearchResultArt>().AnimationHelper.GetComponent<RectTransform>(), 0, 0);
            LeanTween.scale(myNews.GetComponent<SearchResultArt>().AnimationHelper, new Vector3(1.3f, 1.3f, 1.3f), 0);
            //myNews.GetComponent<SearchResultArt>().NewsSite.text = myNewsCollection.RetrieveNewsArticle(index).Source;
            myNews.GetComponent<SearchResultArt>().NewsSite.text = "";
            //myNews.GetComponent<SearchResultArt>().Date.text = myNewsCollection.RetrieveNewsArticle(index).Date;
            myNews.GetComponent<SearchResultArt>().Date.text = "";
            //myNews.GetComponent<SearchResultArt>().Title.text = myNewsCollection.RetrieveNewsArticle(index).Title;
            myNews.GetComponent<SearchResultArt>().Title.text = "";
            //myNews.GetComponent<SearchResultArt>().Body.text = myNewsCollection.RetrieveNewsArticle(index).Body;
            myNews.GetComponent<SearchResultArt>().Body.text = "";
            myNews.GetComponent<SearchResultArt>().Author.text = "";

            myNews.GetComponent<SearchResultArt>().ShareButton.onClick.AddListener(() => UpdateShare(index));

            DOTween.To(
                () => txt,
                x => txt = x,
                myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Source,
                0.1f).SetDelay(0.2f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().NewsSite.text = txt);
            DOTween.To(
                () => txt,
                x => txt = x,
                myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Date,
                0.1f).SetDelay(0.3f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().Date.text = txt);
            DOTween.To(
                () => txt,
                x => txt = x,
                myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Title,
                0.2f).SetDelay(0.4f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().Title.text = txt);
            DOTween.To(
               () => txt,
               x => txt = x,
               "Written By Random Person",
               0.1f).SetDelay(0.6f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().Author.text = txt);
            DOTween.To(
                () => txt,
                x => txt = x,
                myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Body,
                0.5f).SetDelay(0.7f + 0.2f * order).OnUpdate(() => myNews.GetComponent<SearchResultArt>().Body.text = txt);



            //Canvas.ForceUpdateCanvases();
            //myNews.GetComponent<SearchResultArt>().MagicFix.GetComponent<VerticalLayoutGroup>().enabled = false;
            //myNews.GetComponent<SearchResultArt>().MagicFix.GetComponent<VerticalLayoutGroup>().enabled = true;
            LeanTween.scale(myNews.GetComponent<SearchResultArt>().AnimationHelper, new Vector3(1f, 1f, 1f), 0.3f).setDelay(0.1f * order).setEase(LeanTweenType.easeInExpo);
            LeanTween.moveLocalX(myNews.GetComponent<SearchResultArt>().AnimationHelper, 0, 0.4f).setDelay(0.1f * order).setEase(LeanTweenType.easeInOutCubic);
            LeanTween.alpha(myNews.GetComponent<SearchResultArt>().AnimationHelper.GetComponent<RectTransform>(), 1, 0.3f).setDelay(0.1f * order).setEase(LeanTweenType.easeInExpo);
            


        }
            return 1;
        
    }
}
