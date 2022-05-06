using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

[System.Serializable]
public class NewsArticle
{
    public int ReferenceNr;
    public string Title;
    public string Date;
    public string Body;
    public bool Paywall;
    public int Multipiler;
    public int AppearDate;
    public int Score;
    public int Priority;
    public int GameState;
    public bool KeyArticle;
    public string Source;
    public int SourceNum;
    public string Note;
    public string HeaderText;
    public bool Is_shared;
}

[System.Serializable]
public class NewsCollection
{
    public NewsArticle[] News;
    public int[] SearchList = new int[25];
    public int searchResultStat;
    public int[] newsAlgorithm = new int [99]; //First element i.e. newsAlgorithm[0] is the length of the list

    public void SearchForKeyWord(string keyword, int index)
    {
        //Debug.Log("Start Searching");
        for(int i = 0; i < SearchList.Length; i++)
        {
            SearchList[i] = 0;  
        }
        searchResultStat = 0; 

        //Debug.Log("Compelete Clearing the whole list"); 
        //Clear out the search list
        int currentIndex = 0; 
        for (int i = 0; i < News.Length; i++)
        {
            if ((News[i].Title.ToLower().IndexOf(keyword.ToLower()) >= 0) || (News[i].Body.ToLower().IndexOf(keyword.ToLower()) >= 0))
            {
                if (index >= News[i].AppearDate)
                {
                    //Debug.Log("Found a matching one with index " + i); 
                    SearchList[currentIndex] = i;
                    currentIndex++;
                    searchResultStat++;
                }
            }
            //Debug.Log("index " + i + " not matched"); 
        }

        //Debug.Log("Complete Searching, now start to sort the list");
        //Debug.Log("Found " + SearchList.Length); 
        //search key word
        SortSearchListPriority(); 
    }

    void SortSearchListPriority()
    {
        int n = SearchList.Length;
        //Debug.Log("Sorting the list");
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (RetrieveNewsArticle(j).Priority > RetrieveNewsArticle(j+1).Priority)
                {
                    // swap temp and SearchList[i]
                    int temp = SearchList[j];
                    SearchList[j] = SearchList[j + 1];
                    SearchList[j + 1] = temp;
                }
            }
        }
        //Debug.Log("Finish Sorting"); 
        PrintList();
    }

    void PrintList()
    {
        for (int i = 0; i < SearchList.Length; i++)
        {
            Debug.Log("Hi my order is " + RetrieveNewsArticle(i).Priority);
        }
    }

    public NewsArticle RetrieveNewsArticle (int index)
    {
        return News[SearchList[index]];
    }
    
    public void generateNewsFeed(int currentScore, int currentGS)
    {
        int currentIndex = 1;
        for (int i = 0; i < News.Length; i++)
        {
            if ((News[i].Score >= currentScore / 10) && (News[i].Score <= currentScore))
            {
                if (currentGS >= News[i].AppearDate)
                {
                    //Debug.Log("Found one in range with index " + i + " with score " + News[i].Score + " in " + currentScore / 10 + " and " + currentScore);
                    newsAlgorithm[currentIndex] = i;
                    currentIndex++;
                }
            }
           //
           //Debug.Log("index " + i + " with score " + News[i].Score + " not matched in " + currentScore / 10 + " and "+ currentScore);
        }

        newsAlgorithm[0] = currentIndex; 
        /*
        while (count_valid < newsAlgorithm.Length)
        {
            int randomIndex = Mathf.RoundToInt(Random.Range(0, News.Length-1));
            NewsArticle newsarticle = News[randomIndex];
            if (newsarticle.Score > currentScore / 10 && newsarticle.Score < currentScore)
            {
                Debug.Log("Randomly choosed index" + randomIndex + "with a score" + newsarticle.Score + "and current score is " + currentScore); 
                newsAlgorithm[count_valid] = randomIndex;
                count_valid++; 
            }
        }
        */

    }

    public NewsArticle RetrieveAlgoritmArticle(int index)
    {
        return News[newsAlgorithm[index]];
    }

}

