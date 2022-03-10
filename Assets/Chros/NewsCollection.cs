using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

[System.Serializable]
public class NewsArticle
{
    public string Title;
    public string Date;
    public string Body;
    public bool Paywall;
    public int Multipiler;
    public int Score;
    public int Priority;
}

[System.Serializable]
public class NewsCollection
{
    public NewsArticle[] News;
    public int[] SearchList = new int[25];
    public int searchResultStat;
    public int[] newsAlgorithm = new int [99]; //First element i.e. newsAlgorithm[0] is the length of the list

    public void SearchForKeyWord(string keyword)
    {
        Debug.Log("Start Searching");
        for(int i = 0; i < SearchList.Length; i++)
        {
            SearchList[i] = 0;  
        }
        searchResultStat = 0; 

        Debug.Log("Compelete Clearing the whole list"); 
        //Clear out the search list
        int currentIndex = 0; 
        for (int i = 0; i < News.Length; i++)
        {
            if ((News[i].Title.ToLower().IndexOf(keyword.ToLower()) >= 0) || (News[i].Body.ToLower().IndexOf(keyword.ToLower()) >= 0))
            {
                Debug.Log("Found a matching one with index " + i); 
                SearchList[currentIndex] = i;
                currentIndex++;
                searchResultStat++;
            }
            Debug.Log("index " + i + " not matched"); 
        }

        Debug.Log("Complete Searching, now start to sort the list");
        Debug.Log("Found " + SearchList.Length); 
        //search key word
        SortSearchListPriority(); 
    }

    void SortSearchListPriority()
    {
        int n = SearchList.Length;
        Debug.Log("Sorting the list");
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (RetrieveNewsArticle(j).Priority > RetrieveNewsArticle(j).Priority)
                {
                    // swap temp and SearchList[i]
                    int temp = SearchList[j];
                    SearchList[j] = SearchList[j + 1];
                    SearchList[j + 1] = temp;
                }
            }
        }
        Debug.Log("Finish Sorting"); 
    }

    public NewsArticle RetrieveNewsArticle (int index)
    {
        return News[SearchList[index]];
    }
    
    public void generateNewsFeed(int currentScore)
    {
        int currentIndex = 0;
        for (int i = 1; i < News.Length; i++)
        {
            if ((News[i].Score > currentScore / 10) && (News[i].Score <= currentScore))
            {
                Debug.Log("Found one in range with index " + i + " with score " + News[i].Score + " in " + currentScore / 10 + " and " + currentScore);
                newsAlgorithm[currentIndex] = i;
                currentIndex++;
            }
            Debug.Log("index " + i + " with score " + News[i].Score + " not matched in " + currentScore / 10 + " and "+ currentScore);
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

