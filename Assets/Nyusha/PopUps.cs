using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{

    public GameObject[] articles; //list of pop ups
    Color currentColor;
    public GameObject myAudioSource;
    public AudioClip[] sound;
    public GameObject SoundSystem;
    int popUps; //how many pop ups are on screen
    float timer; //timer countdown
    float quickTimer;

    // Start is called before the first frame update
    void Start()
    {
       // currentColor = 
        popUps = 0; //zero pop ups on screen initially
        timer = 1f;
        quickTimer = 0.3f;
        articles[popUps].transform.localScale = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && (popUps < 3)) //if clicking and less than 4 pop ups
        {
            ClickToPopUp();
        }

        if (popUps >= 3 && popUps < 5) //if popups are between
        {
            if (timer > 0) //if timer is greater than zero
            {
                timer = timer - Time.deltaTime; //decrease the timer amount
            }

            if (timer < 0) //if timer reaches zero
            {
                AutoPop();
                timer = 1f; //reset it back to 2 seconds
            }
        }

        if (popUps >= 5) 
        {
            if (quickTimer > 0) //if timer is greater than zero
            {
                quickTimer = quickTimer - Time.deltaTime; //decrease the timer amount
            }

            if (quickTimer < 0) //if timer reaches zero
            {
                QuickAutoPop();
                quickTimer = 0.3f; //reset
            }
        }
    }

    void ClickToPopUp() //the first stage, manual control over pop ups
    {
        //Pop Up appears
        Debug.Log("Popups =" + popUps);
        articles[popUps].transform.localScale = Vector2.zero;
        articles[popUps].SetActive(true);
        // PlaySound();
        // Animation();
        Effects();
        popUps++;
    }
  
    void AutoPop()
    {
       articles[popUps].transform.localScale = Vector2.zero;
        articles[popUps].SetActive(true);
        // PlaySound();
        // Animation();
        Effects();
        popUps++;
    }

    void QuickAutoPop(){
        articles[popUps].transform.localScale = Vector2.zero;
        articles[popUps].SetActive(true);
      //  PlaySound();
      //  Animation();
        Effects();
        popUps++;
    }

    // void Animation()
    // {
    //     LeanTween.scale(articles[popUps], new Vector3(1f, 1f, 1f), 0.4f).setEase(LeanTweenType.easeInOutCubic);
    // }

    // void PlaySound()
    // {
    //     myAudioSource = Instantiate(myAudioSource);
    //     myAudioSource.transform.SetParent(SoundSystem.transform);
    //     myAudioSource.GetComponent<AudioSource>().clip = sound[popUps];
    //     myAudioSource.GetComponent<AudioSource>().Play();
    // }

    void Effects()
    {
        //Animation
        LeanTween.scale(articles[popUps], new Vector3(1f, 1f, 1f), 0.4f).setEase(LeanTweenType.easeInOutCubic);
        //Audio
        myAudioSource = Instantiate(myAudioSource);
        myAudioSource.transform.SetParent(SoundSystem.transform);
        myAudioSource.GetComponent<AudioSource>().clip = sound[popUps];
        myAudioSource.GetComponent<AudioSource>().Play();
        //Color Change
         foreach (GameObject g in articles)
        {
            if (g.activeSelf)
            {
               // Debug.Log(g + "is active");
            }
        }
    }
}
