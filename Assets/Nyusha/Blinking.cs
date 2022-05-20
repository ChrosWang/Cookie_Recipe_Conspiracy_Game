using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(),0f,0f);
       //gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0f); 
       LeanTween.alpha(gameObject.GetComponent<RectTransform>(),1f,1f).setLoopPingPong().setEaseInOutQuint();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //  void FadeStart()
    //  {
    //      LeanTween.alpha (image.rectTransForm, 0f, 1f).setEase (LeanTweenType.linear).setOnComplete( FadeFinished );
    //  }
    //  void FadeFinished()
    //  {
    //      LeanTween.alpha (image.rectTransForm, 1f, 1f).setEase (LeanTweenType.linear).setOnComplete( FadeStart );
    //  }
}
