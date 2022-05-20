using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System;

public class TurnOffEffect : MonoBehaviour
{
    public VideoPlayer Video;
    public GameObject myImage;
    public AudioManager audiomanager;
    public int toScene;
    public void PlayEffect()
    {
        LeanTween.alpha(myImage.GetComponent<RectTransform>(), 0f, 0f);
        myImage.SetActive(true);
        Video.Play();
        LeanTween.alpha(myImage.GetComponent<RectTransform>(), 1f, 2f);
        LTDescr myTween = LeanTween.alpha(myImage.GetComponent<RectTransform>(), 1f, 3f);

        Video.loopPointReached += SwitchScene;

        
    }

    public void SwitchScene(UnityEngine.Video.VideoPlayer vp)
    {
        if (audiomanager != null)
        {
            audiomanager.Secret.Stop();
        }
        SceneManager.LoadScene(toScene) ;
    }
}
