using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomGenerateStats : MonoBehaviour
{
    public TMP_Text Likes;
    public TMP_Text Reposts;
    public void RandomGenerate(int trendValue, int priority)
    {
        Likes.text = Random.Range(priority*10 + trendValue - trendValue/2, priority * 10 + trendValue + 5 ).ToString();
        Reposts.text = Random.Range(priority * 10 + trendValue - ((trendValue * 2)/ 3), 5 + priority * 10 + trendValue -  trendValue / 3).ToString();
    }
}
