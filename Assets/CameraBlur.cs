using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using VortexStudios.PostProcessing;

public class CameraBlur : MonoBehaviour
{
    public GameObject audiomanager;
    public OLDTVPreset BadEffect;
    public OLDTVPreset GoodEffect;

    LTDescr myLoopingTween1;
    LTDescr myLoopingTween2;

    float dradius;
    int dQI;
    int dF;
    float dDistorL;
    float dcutoff;

    float dV1;
    float dV2;
    float dV3;
    float dV4;

    public void Start()
    {
        dradius = this.gameObject.GetComponent<Blur>().radius;
        dQI = this.gameObject.GetComponent<Blur>().qualityIterations;
        dF =  this.gameObject.GetComponent<Blur>().filter;
        dDistorL = audiomanager.GetComponent<AudioDistortionFilter>().distortionLevel;
        dcutoff = audiomanager.GetComponent<AudioHighPassFilter>().cutoffFrequency;
    }
    public void BlurBegin()
    {
        this.gameObject.GetComponent<Blur>().enabled = true;
        
        myLoopingTween1 = LeanTween.value(this.gameObject, updateCallBackBlur1, 0f, 10f, 1.5f).setDelay(0.5f).setEase(LeanTweenType.easeInCubic).setLoopPingPong();
        LeanTween.value(this.gameObject, updateCallBackBlur2, 1f, 6f, 0.6f).setDelay(0.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.value(this.gameObject, updateCallBackBlur3, 0f, 3f, 0.6f).setDelay(0.5f).setEase(LeanTweenType.easeOutCubic);
        audiomanager.GetComponent<AudioDistortionFilter>().enabled = true;
        Action BringEcho = () =>
        {
            audiomanager.GetComponent<AudioEchoFilter>().enabled = true;
            this.GetComponent<OLDTVFilter3>().preset = BadEffect;
        };
        LeanTween.value(this.gameObject, updateCallBackBDistortion, 0f, 0.5f, 0.3f).setDelay(0.7f).setEase(LeanTweenType.easeOutCubic).setOnComplete(BringEcho);
        audiomanager.GetComponent<AudioHighPassFilter>().enabled = true;
        myLoopingTween2 = LeanTween.value(this.gameObject, updateCallBackBPass, 0f, 2200f, 0.5f).setDelay(0.7f).setEase(LeanTweenType.easeOutCubic).setLoopPingPong();
        

        dV1 = audiomanager.GetComponent<AudioManager>().EarRinning.volume;
        dV2 = audiomanager.GetComponent<AudioManager>().EarRinning2.volume;
        dV3 = audiomanager.GetComponent<AudioManager>().Duuu.volume;

        LeanTween.value(this.gameObject, updateCalldV1, 0f, dV1, 0.8f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.value(this.gameObject, updateCalldV2, 0f, dV2, 0.8f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.value(this.gameObject, updateCalldV3, 0f, dV3, 0.8f).setEase(LeanTweenType.easeOutCubic);

        audiomanager.GetComponent<AudioManager>().heartbeat.Play();
        audiomanager.GetComponent<AudioManager>().EarRinning2.Play();
        audiomanager.GetComponent<AudioManager>().EarRinning.Play();
        audiomanager.GetComponent<AudioManager>().Duuu.Play();
    }
    
    public void BlurEnd()
    {
        myLoopingTween1.pause();
        myLoopingTween2.pause();
        audiomanager.GetComponent<AudioEchoFilter>().enabled = false;
        audiomanager.GetComponent<AudioHighPassFilter>().enabled = false;
        audiomanager.GetComponent<AudioDistortionFilter>().enabled = false;
        dDistorL = audiomanager.GetComponent<AudioDistortionFilter>().distortionLevel;
        dcutoff = audiomanager.GetComponent<AudioHighPassFilter>().cutoffFrequency;
        LeanTween.value(this.gameObject, updateCallBackBlur1, 10f, 0f, 1.2f).setEase(LeanTweenType.easeInCubic);
        LeanTween.value(this.gameObject, updateCallBackBlur2, 6f, 1f, 1.2f).setDelay(0.1f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.value(this.gameObject, updateCallBackBlur3, 3f, 0f, 1.2f).setDelay(0.2f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.value(this.gameObject, updateCalldV1,  dV1, 0f, 1.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.value(this.gameObject, updateCalldV2,  dV2, 0f, 1.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.value(this.gameObject, updateCalldV3,  dV3, 0f, 1.5f).setEase(LeanTweenType.easeOutCubic);

        this.GetComponent<OLDTVFilter3>().preset = GoodEffect;

        //LeanTween.value(this.gameObject, updateCallBackBlur1, 10f, 0f, 0.7f).setEase(LeanTweenType.easeOutElastic);
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
    void updateCalldV1(float val)
    {
        audiomanager.GetComponent<AudioManager>().EarRinning.volume = val;
    }
    void updateCalldV2(float val)
    {
        audiomanager.GetComponent<AudioManager>().EarRinning2.volume = val;
    }
    
    void updateCalldV3(float val)
    {
        audiomanager.GetComponent<AudioManager>().Duuu.volume = val;
    }
}
