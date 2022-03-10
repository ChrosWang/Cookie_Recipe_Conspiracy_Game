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
    // Start is called before the first frame update
    void Start()
    {
        myNewsCollection = JsonUtility.FromJson<NewsCollection>("{\"News\":" + SpreadSheetJSON.text+"}");
        Debug.Log(myNewsCollection.News[0].Title);
        Debug.Log(myNewsCollection.News[0].Date);
        Debug.Log(myNewsCollection.News[0].Body);

        SearchButton.onClick.AddListener(() => SearchMyCollection(textField.text));
        CurrentScoreButton.onClick.AddListener(() => RefreshNewsFeed(int.Parse(scoreField.text)));  

    }

    void RefreshNewsFeed (int currentScore)
    {
        myNewsCollection.generateNewsFeed(currentScore);
        RefreshOne();
        RefreshTwo();
    }
    
    void SearchMyCollection(string keyword)
    {
        Debug.Log("Search with " + keyword); 
        myNewsCollection.SearchForKeyWord(keyword);
        SearchResultStats.text = "Found " + myNewsCollection.searchResultStat.ToString() + " matched results."; 
        RetrieveTopThree();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void RefreshOne ()
    {
        int randomIndex  = Random.Range(1, myNewsCollection.newsAlgorithm[0] - 1);
        Algorithm1Title.text =  myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Title + " " + myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Date;
        Algorithm1Body.text = myNewsCollection.RetrieveAlgoritmArticle(randomIndex).Body;
    }
    void RefreshTwo()
    {
        int randomIndex = Random.Range(1, myNewsCollection.newsAlgorithm[0] - 1);
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
