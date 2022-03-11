using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewsLoader : MonoBehaviour
{
    public TextAsset SpreadSheetJSON;
    //google spreadsheet
    public NewsCollection myNewsCollection = new NewsCollection();

    public Button SearchButton;
    public Button CurrentScoreButton;
    public Button ShareButton1;
    public Button ShareButton2;
    public Button ShareButton3;

    public GameObject ShareStats1;
    public GameObject ShareStats2;
    public GameObject ShareStats3;
    //public Image ShareStats2;
    // public Image ShareStats3;

    public Text textField;
    public Text scoreField; 

    public TMP_Text SearchResult1Title;
    public TMP_Text SearchResult2Title;
    public TMP_Text SearchResult3Title;
    public TMP_Text Algorithm1Title;
    public TMP_Text Algorithm2Title;

    public TMP_Text SearchResult1Body;
    public TMP_Text SearchResult2Body;
    public TMP_Text SearchResult3Body;
    public TMP_Text Algorithm1Body;
    public TMP_Text Algorithm2Body;

    public TMP_Text SearchResultStats;



    public int currentCP;

    public int searchCount;
    // Start is called before the first frame update
    void Start()
    {
        myNewsCollection = JsonUtility.FromJson<NewsCollection>("{\"News\":" + SpreadSheetJSON.text+"}");
        Debug.Log(myNewsCollection.News[0].Title);
        Debug.Log(myNewsCollection.News[0].Date);
        Debug.Log(myNewsCollection.News[0].Body);

        currentCP = 0;
        RefreshNewsFeed();

        SearchButton.onClick.AddListener(() => SearchMyCollection(textField.text));
        CurrentScoreButton.onClick.AddListener(() => RefreshNewsFeed());

        ShareButton1.onClick.AddListener(() => UpdateShare1());

        ShareButton2.onClick.AddListener(() => UpdateShare2());

        ShareButton3.onClick.AddListener(() => UpdateShare3());

    }

    void RefreshNewsFeed ()
    {
        myNewsCollection.generateNewsFeed(currentCP);
        RefreshTwo(RefreshOne());
    }
    
    void  UpdateShare1()
    {
        if (!myNewsCollection.RetrieveNewsArticle(0).Is_shared) {
            Debug.Log("Adding CP: " + currentCP + "to score for "  + myNewsCollection.RetrieveNewsArticle(0).Score);
            currentCP = currentCP + myNewsCollection.RetrieveNewsArticle(0).Score;
            myNewsCollection.RetrieveNewsArticle(0).Is_shared = true;
        }
        Debug.Log("current cp is " + currentCP);
        ShareStats1.SetActive(true);
        ShareStats1.GetComponent<RandomGenerateStats>().RandomGenerate(myNewsCollection.RetrieveNewsArticle(0).Score, myNewsCollection.RetrieveNewsArticle(0).Priority);
    }
    void UpdateShare2()
    {
        if (!myNewsCollection.RetrieveNewsArticle(1).Is_shared)
        {
            Debug.Log("Adding CP: " + currentCP + "to score for " + myNewsCollection.RetrieveNewsArticle(1).Score);
            currentCP = currentCP + myNewsCollection.RetrieveNewsArticle(1).Score;
            myNewsCollection.RetrieveNewsArticle(1).Is_shared = true;
        }
        Debug.Log("current cp is " + currentCP);
        ShareStats2.SetActive(true);
        ShareStats2.GetComponent<RandomGenerateStats>().RandomGenerate(myNewsCollection.RetrieveNewsArticle(0).Score, myNewsCollection.RetrieveNewsArticle(0).Priority);
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
        ShareStats3.GetComponent<RandomGenerateStats>().RandomGenerate(myNewsCollection.RetrieveNewsArticle(0).Score, myNewsCollection.RetrieveNewsArticle(0).Priority);
    }
    void SearchMyCollection(string keyword)
    {
        // Debug.Log("Search with " + keyword);
        searchCount = searchCount + 1; 
        ShareStats1.SetActive(false);
        ShareStats2.SetActive(false);
        ShareStats3.SetActive(false);
        myNewsCollection.SearchForKeyWord(keyword);
        SearchResultStats.text = "Found " + myNewsCollection.searchResultStat.ToString() + " matched results."; 
        RetrieveTopThree();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SearchMyCollection(textField.text);
        }

        if (searchCount >= 4)
        {
            RefreshNewsFeed();
            searchCount = 0;
        }
    }
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

    void RetrieveTopThree ()
    {
        SearchResult1Title.text = myNewsCollection.RetrieveNewsArticle(0).Title + " " + myNewsCollection.RetrieveNewsArticle(0).Date;
        SearchResult1Body.text = myNewsCollection.RetrieveNewsArticle(0).Body;
        SearchResult2Title.text = myNewsCollection.RetrieveNewsArticle(1).Title + " " + myNewsCollection.RetrieveNewsArticle(1).Date;
        SearchResult2Body.text = myNewsCollection.RetrieveNewsArticle(1).Body;
        SearchResult3Title.text = myNewsCollection.RetrieveNewsArticle(2).Title + " " + myNewsCollection.RetrieveNewsArticle(2).Date;
        SearchResult3Body.text = myNewsCollection.RetrieveNewsArticle(2).Body;
    }
}
