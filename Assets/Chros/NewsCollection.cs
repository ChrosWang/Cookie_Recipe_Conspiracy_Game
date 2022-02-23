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
    public int ID;
}

[System.Serializable]
public class NewsCollection
{
    public NewsArticle[] News; 
}
