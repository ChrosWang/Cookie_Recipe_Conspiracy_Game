using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserComments
{
    public int Post;
    public string Comment;
    public string User;
    public int Order;
    public string Value;
}

[System.Serializable]
public class CommentCollection
{
   
    public UserComments[] usercomments;
    public int[] SearchList = new int[10];
    int searchResultStat = 0;

    public void SearchForKeyWord(int index)
    {
        //Debug.Log("Start Searching");
        for (int i = 0; i < SearchList.Length; i++)
        {
            SearchList[i] = 0;
        }
        searchResultStat = 0;

        //Debug.Log("Compelete Clearing the whole list"); 
        //Clear out the search list
        int currentIndex = 0;
        for (int i = 0; i < usercomments.Length; i++)
        {
            if (usercomments[i].Post == index)
            {
                //Debug.Log("Found a matching one with index " + i); 
                SearchList[currentIndex] = i;
                currentIndex++;
                searchResultStat++;
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
                if (usercomments[SearchList[j]].Order > usercomments[SearchList[j+1]].Order)
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
            Debug.Log("Hi my order is " + usercomments[SearchList[i]].Order);
        }
    }

}
