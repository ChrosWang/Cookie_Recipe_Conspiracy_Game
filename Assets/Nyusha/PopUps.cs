using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{

    public GameObject[] articles; //list of pop ups
  
    //public GameObject myAudioSource;
   // public AudioClip[] sound;
    //public GameObject SoundSystem;
    int popUps; //how many pop ups are on screen
    float timer; //timer countdown
    float quickTimer;
    public GameObject stateSix;
    public GameObject[] complexSound;
    public GameObject soundSourcesParent;
    // public bool wendyDead;


    // Start is called before the first frame update
    void Start()
    {
       popUps = 0; //zero pop ups on screen initially
        timer = 1f;
        quickTimer = 0.3f;
        articles[popUps].transform.localScale = Vector2.zero;
        // //turn em off! ....nevermind i don't understand how to write the foreach loop :()
         foreach(GameObject g in articles) 
         {
         g.SetActive(false);
         }
        stateSix.SetActive(false);
        // wendyDead = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if ((Input.GetMouseButtonDown(0)) && (popUps < 31) ) //if clicking (less than code removed)
        {
            ClickToPopUp();
        }

        if ((Input.GetMouseButtonDown(0)) && (popUps == 31)) //if clicking (less than code removed)
        {
            Debug.Log("on wendy");
            Destroy(soundSourcesParent);
            ClickToPopUp();
           
        }

        // if ((Input.GetMouseButtonDown(0)) && (popUps == 32) )
        // {
        //     ClickToPopUp();
        //     LeanTween.alpha(fadeBlack.GetComponent<RectTransform>(),1f,1f).setEaseInOutQuint();
            
        // }

        // if (popUps == 35)
        // {
        //     wendyDead = true;
        // }

        // if ((Input.GetMouseButtonDown(0)) && (wendyDead == true))
        // {
        //     GameState6();
        // }

        // if (popUps == 9)
        // {
        //     if (timer > 0) //if timer is greater than zero
        //     {
        //         timer = timer - Time.deltaTime; //decrease the timer amount
        //     }

        //     if (timer < 0) //if timer reaches zero
        //     {
        //         AutoPop();
        //         timer = 1f; //reset it back to 2 seconds
        //     }
        // }

        //  if (popUps == 10)
        // {
        //     if (timer > 0) //if timer is greater than zero
        //     {
        //         timer = timer - Time.deltaTime; //decrease the timer amount
        //     }

        //     if (timer < 0) //if timer reaches zero
        //     {
        //         AutoPop();
        //         timer = 1f; //reset it back to 2 seconds
        //     }
        // }

        // if ((Input.GetMouseButtonDown(0)) && (popUps >=11)) //if clicking and less than
        // {
        //     ClickToPopUp();
        // }

        // if (popUps >= 10) 
        // {
        //     if (quickTimer > 0) //if timer is greater than zero
        //     {
        //         quickTimer = quickTimer - Time.deltaTime; //decrease the timer amount
        //     }

        //     if (quickTimer < 0) //if timer reaches zero
        //     {
        //         AutoPop();
        //         quickTimer = 0.3f; //reset
        //     }
        //}
    }

    void ClickToPopUp() //the first stage, manual control over pop ups
    {
        //Pop Up appears
        Debug.Log("Popup #: " + popUps);
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
        Effects();
        popUps++;
    }

    void Effects()
    {
        //Animation
        LeanTween.scale(articles[popUps], new Vector3(1f, 1f, 1f), 0.4f).setEase(LeanTweenType.easeInOutCubic);
        //Audio- generate:
        // myAudioSource = Instantiate(myAudioSource);
        // myAudioSource.transform.SetParent(SoundSystem.transform);
        // myAudioSource.GetComponent<AudioSource>().clip = sound[popUps];
        // myAudioSource.GetComponent<AudioSource>().Play();
        //////complex attempt
        //complexSound[popUps].GetComponent<AudioSource>().Play();
        complexSound[popUps].GetComponent<AudioSource>().Play();


        //Color Change
    //      foreach (GameObject g in articles)
    //     {
    //         if (g.activeSelf)
    //         {
    //            // Debug.Log(g + "is active");
    //         }
    //     }
    }

    void GameState6()
    {
       //go to scene stuff
    }
}
