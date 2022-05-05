using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraBlur : MonoBehaviour
{
    public GameObject audiomanager;
    public void BlurBegin()
    {
        this.gameObject.GetComponent<Blur>().enabled = true;
        
        LeanTween.value(this.gameObject, updateCallBackBlur1, 0f, 10f, 0.6f).setEase(LeanTweenType.easeInCubic).setLoopPingPong();
        LeanTween.value(this.gameObject, updateCallBackBlur2, 1f, 6f, 0.8f).setDelay(0.1f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.value(this.gameObject, updateCallBackBlur3, 0f, 3f, 0.8f).setDelay(0.2f).setEase(LeanTweenType.easeOutCubic);
        audiomanager.GetComponent<AudioDistortionFilter>().enabled = true;
        Action BringEcho = () =>
        {
            audiomanager.GetComponent<AudioEchoFilter>().enabled = true;
        };
        LeanTween.value(this.gameObject, updateCallBackBDistortion, 0f, 0.5f, 0.3f).setEase(LeanTweenType.easeOutCubic).setOnComplete(BringEcho);
        audiomanager.GetComponent<AudioHighPassFilter>().enabled = true;
        LeanTween.value(this.gameObject, updateCallBackBPass, 0f, 2200f, 0.5f).setDelay(0.4f).setEase(LeanTweenType.easeOutCubic).setLoopPingPong();

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
    void updateCallBackBlur2(float val)
    {
        this.gameObject.GetComponent<Blur>().qualityIterations= Mathf.RoundToInt(val);
    }
    void updateCallBackBlur3(float val)
    {
        this.gameObject.GetComponent<Blur>().filter = Mathf.RoundToInt(val);
    }
    void updateCallBackBDistortion(float val)
    {
        audiomanager.GetComponent<AudioDistortionFilter>().distortionLevel = val;
    }
    void updateCallBackBPass(float val)
    {
        audiomanager.GetComponent<AudioHighPassFilter>().cutoffFrequency = val;
    }
}
