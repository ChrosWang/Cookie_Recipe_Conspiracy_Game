using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AdSwapper : MonoBehaviour
{
    public GameObject Adb;
    public GameObject Adf;
    public Sprite[] Ads;

    public int currentAd;
    public float timer;

    private void Start()
    {
        SwapMyAd();
    }
    public void SwapMyAd()
    {
        int randomAd = currentAd;
        
        while (currentAd == randomAd)
        {
            randomAd = UnityEngine.Random.Range(0, Ads.Length);
        }
        

        Adb.GetComponent<Image>().sprite = Ads[randomAd];
        Action SwapAd = () =>
        {
            Adf.GetComponent<Image>().sprite = Ads[randomAd];
            LeanTween.alpha(Adf, 1f, 0.01f).setEaseInOutCubic();
        };
        LeanTween.alpha(Adf, 0f, 2f).setEaseInOutCubic().setOnComplete(SwapAd);
        
        
        
    }

    private void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= 40f)
        {
            SwapMyAd();
            timer = 0;
        }
        
    }
}
