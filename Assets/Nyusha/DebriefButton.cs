using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DebriefButton : MonoBehaviour
{
    public GameObject[] slides;
    int slideCount;
    public GameObject arrow;

    //Slide 1
            public TMP_Text Tmp1;
            [TextArea(10, 100)] 
            public string String1;

    //Slide 2

            public TMP_Text Tmp2;
            [TextArea(10, 100)] 
            public string String2;

    //Slide 3

            public TMP_Text Tmp3;
            [TextArea(10, 100)] 
            public string String3;

            public TMP_Text Tmp4;
            [TextArea(10, 100)] 
            public string String4;

    public GameObject Credits;
            
    

    // Start is called before the first frame update
    void Start()
    {
        slideCount = 0;
        LeanTween.alpha(arrow.GetComponent<RectTransform>(),0f,0f); 
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void NextSlide()
    {
        Debug.Log("button clicked");
        slides[slideCount].SetActive(false);
        slideCount++;
        Debug.Log("showing slide: " + slideCount);

        if (slideCount == 1)
        {
        LeanTween.alpha(arrow.GetComponent<RectTransform>(),0f,0f);
        string txt = "";
        DOTween.To(
                () => txt,
                x => txt = x, 
                String1, 
                10.0f).SetDelay(0f).OnUpdate(() => Tmp1.text = txt);
                LeanTween.alpha(arrow.GetComponent<RectTransform>(),1f,1f).setDelay(10f);
        }

        if (slideCount == 2)
        {
            LeanTween.alpha(arrow.GetComponent<RectTransform>(),0f,0f);
                string txt2 = "";
                DOTween.To(
                        () => txt2,
                        x => txt2 = x, 
                        String2, 
                        12.0f).SetDelay(0f).OnUpdate(() => Tmp2.text = txt2);
                        LeanTween.alpha(arrow.GetComponent<RectTransform>(),1f,1f).setDelay(11f);
        }

        if (slideCount == 3)
        {
            LeanTween.alpha(arrow.GetComponent<RectTransform>(),0f,0f);
                string txt3 = "";
                DOTween.To(
                        () => txt3,
                        x => txt3 = x, 
                        String3, 
                        2.0f).SetDelay(0f).OnUpdate(() => Tmp3.text = txt3);
                
                 string txt4 = "";
                DOTween.To(
                        () => txt4,
                        x => txt4 = x, 
                        String4, 
                        8.0f).SetDelay(2.1f).OnUpdate(() => Tmp4.text = txt4);
                        LeanTween.alpha(arrow.GetComponent<RectTransform>(),1f,1f).setDelay(10f);
        }

        if (slideCount == 4)
        {   
            LeanTween.alpha(arrow.GetComponent<RectTransform>(),0f,0f);
            LeanTween.alpha(Credits.GetComponent<RectTransform>(),0f,0f);
            Credits.SetActive(true);
            LeanTween.alpha(Credits.GetComponent<RectTransform>(),1f,1f).setDelay(0f);
              
        }
    }
}
