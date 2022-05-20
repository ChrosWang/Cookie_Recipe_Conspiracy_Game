using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GS6Text : MonoBehaviour
{


    public TMP_Text Tmp1;
    [TextArea(10, 100)] 
    public string String1;
    public TMP_Text Tmp2;
       [TextArea(10, 100)] 
    public string String2;
    public TMP_Text Tmp3;
     [TextArea(10, 100)] 
    public string String3;
    public GameObject slide1;
    // public TMP_Text Tmp4;
    // public string String4;

    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.alpha(arrow.GetComponent<RectTransform>(),0f,0f);
        //Slide 1
        string txt = "";
        DOTween.To(
                () => txt,
                x => txt = x, 
                String1, 
                4.0f).SetDelay(0f).OnUpdate(() => Tmp1.text = txt);
        string txt2 = "";
       DOTween.To(
                () => txt2, //input goes into txt
                x => txt2 = x, 
                String2, 
                9.0f).SetDelay(4f).OnUpdate(() => Tmp2.text = txt2);
        string txt3 = "";
        DOTween.To(
                () => txt3, //input goes into txt
                x => txt3 = x, 
                String3, 
                2.0f).SetDelay(13f).OnUpdate(() => Tmp3.text = txt3);

        LeanTween.alpha(arrow.GetComponent<RectTransform>(),1f,1f).setDelay(15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Slide2()
    {
        

     }
    }

    


