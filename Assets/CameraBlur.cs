using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlur : MonoBehaviour
{
    
    public void BlurBegin()
    {
        this.gameObject.GetComponent<Blur>().enabled = true;
        
        LeanTween.value(this.gameObject, updateCallBackBlur1, 0f, 10f, 0.7f).setEase(LeanTweenType.easeOutElastic);

    }
    
    public void BlurEnd()
    {
        

        LeanTween.value(this.gameObject, updateCallBackBlur1, 10f, 0f, 0.7f).setEase(LeanTweenType.easeOutElastic);
       // this.gameObject.GetComponent<Blur>().enabled = false;

    }
    
    void updateCallBackBlur1(float val)
    {
        this.gameObject.GetComponent<Blur>().radius = val;
    }
}
