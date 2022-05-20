using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NarrativeControl : MonoBehaviour
{
    public int currentGameState;

    public int currentChat;
    public int toggle = 1;

    public ChatManager chatManager;
    public NewsLoader articleLoader;
    public StateMachine stateMachine;
    public NewPostCreator newPostCreator;
    public PopUpSystem popUpSystem;
    public BreakingNewsSwapper breakingNewsSwapper;
    public CameraBlur BlurControl;
    public AudioManager audiomanager;
    public MixerAssetManager mixswapper;
    public TMP_Text Date;
    public TurnOffEffect turnoff;
    public Button TurnOffButton;

    public Sprite turnoffsprite;

    public void Start()
    {
        currentGameState = 0;
        articleLoader.Initialization();
        newPostCreator.Initialization();
        chatManager.Initialization();

        articleLoader.MakePost(1);
        articleLoader.MakePost(2);
        //articleLoader.MakePost(3);

       // NewChatComing(1);
        //StartCoroutine(DelayBlurEffect(0f));
       // turnoff.PlayEffect();
        Date.text = "4 / 15 / 2021";
       
    }
    public void NewChatComing (int ID)
    {
        Debug.Log("NewCHat+"+ID);
        popUpSystem.CreatePopUp(2, new PopUpMessage(chatManager.GetComponent<ChatManager>().NameList[ID], "", 0, 0));
        StartCoroutine(PlayChatDelay(4f, ID));
        //chatManager.PlayChat(ID);
        
        //chatManager.NewNotification(); 
    }

    public void ChangeGameState()
    {
        currentGameState++;
        switch (currentGameState)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                break;
        }
    }

    public void Update()
    {
        /*
        if (articleLoader.currentCP >= 1 && articleLoader.currentCP < 10)
        {
            currentGameState = 1;
            if (toggle == 1)
            {
                breakingNewsSwapper.Swap(1);
                StartCoroutine(PlayChatDelay(2f, 2));
                StartCoroutine(NewComingDelay(25f, 3));
                toggle = toggle + 1;
                

            }
        }
        else if (articleLoader.currentCP >= 10 && articleLoader.currentCP < 50)
        {
            currentGameState = 2;
            if (toggle == 2)
            {
                breakingNewsSwapper.Swap(2);
                StartCoroutine(PlayChatDelay(2f, 5));
                toggle = toggle + 1;

            }

            if (toggle == 3 && articleLoader.currentCP >= 25)
            {
                StartCoroutine(PlayChatDelay(2f, 6));
                StartCoroutine(NewComingDelay(12f, 7));
                toggle = toggle + 1;
            }


            if (toggle == 4 && articleLoader.currentCP >= 40)
            {
                StartCoroutine(PlayChatDelay(2f, 8));
                toggle = toggle + 1;
            }

        }    
            else if (articleLoader.currentCP >= 50 && articleLoader.currentCP < 130)
            {
            currentGameState = 3;
            if (toggle == 5)
                {
                    breakingNewsSwapper.Swap(3);
                    StartCoroutine(PlayChatDelay(5f, 9));
                    toggle = toggle + 1;
                }
                if (toggle == 6 && articleLoader.currentCP >= 80)
                {
                    StartCoroutine(PlayChatDelay(2f, 10));
                    toggle = toggle + 1;
                }
                if (toggle == 7 && articleLoader.currentCP >= 95)
                {
                    StartCoroutine(PlayChatDelay(2f, 11));
                    toggle = toggle + 1;
                }
                if (toggle == 8 && articleLoader.currentCP >= 115)
                {
                    StartCoroutine(PlayChatDelay(2f, 12));
                    StartCoroutine(NewComingDelay(18f, 13));
                    toggle = toggle + 1;
                }
            } 
        */

        if (articleLoader.currentCP >= 1 && articleLoader.numArticleShared <= 5)
        {
            currentGameState = 1;
            Date.text = "4 / 16 / 2021";
            
            if (toggle == 1)
            {
                popUpSystem.DelayPopUp(3, new PopUpMessage("", Date.text, 0, 0), 1f);
                breakingNewsSwapper.Swap(1);
                StartCoroutine(NewComingDelay(3f, 2));
                

                toggle = toggle + 1;


            }
            /*If DM 2 is finished*/
            if (chatManager.CompleteCheckBox[2] == 1)
            {
                chatManager.CompleteCheckBox[2] = 2;
                DelayMakePost(5f, 0);
                StartCoroutine(NewComingDelay(10f, 3));
                
            }

            //If DM 3 is finished
            if (chatManager.CompleteCheckBox[3] == 1)
            {
                //The game do this 
                chatManager.CompleteCheckBox[3] = 2;
                newPostCreator.MakeNSPost(1);
                
            }
        }
        else if (articleLoader.numArticleShared >= 6 && articleLoader.numArticleShared <= 15)
        {
            currentGameState = 2;
            Date.text = "5 / 10 / 2021";
            
            if (toggle == 2)
            {
                popUpSystem.DelayPopUp(3, new PopUpMessage("", Date.text, 0, 0), 0.1f);
                newPostCreator.MakeNSPost(2);
                breakingNewsSwapper.Swap(2);
                StartCoroutine(NewComingDelay(4f, 5));
                toggle = toggle + 1;

            }

            if (chatManager.CompleteCheckBox[5] == 1)
            {
                chatManager.CompleteCheckBox[5] = 2;
                newPostCreator.MakeNSPost(3);

            }

            if (toggle == 3 && articleLoader.numArticleShared >= 10)
            {
                StartCoroutine(NewComingDelay(2f, 6));
                
                toggle = toggle + 1;
            }

            if (chatManager.CompleteCheckBox[6] == 1)
            {
                chatManager.CompleteCheckBox[6] = 2;
                StartCoroutine(NewComingDelay(5f, 7));
               
                
            }

            if (chatManager.CompleteCheckBox[7] == 1)
            {
                chatManager.CompleteCheckBox[7] = 2;
                newPostCreator.MakeNSPost(4);
                popUpSystem.DelayPopUp(7, new PopUpMessage ("<color=#FF5555>Wendy</color>", "",0,0), 5f);
                
            }



            if (toggle == 4 && articleLoader.numArticleShared >= 12)
            {
                StartCoroutine(NewComingDelay(7f, 8));
                toggle = toggle + 1;
            }

            if (toggle == 5 && articleLoader.numArticleShared >= 14)
            {
                StartCoroutine(NewComingDelay(3f, 9));
                toggle = toggle + 1;
            }

        }
        else if (articleLoader.numArticleShared >= 16 && articleLoader.numArticleShared <= 27)
        {
            currentGameState = 3;
            Date.text = "5 / 10 / 2021";
            if (toggle == 6)
            {
                popUpSystem.DelayPopUp(3, new PopUpMessage("", Date.text, 0, 0), 0.1f);
                breakingNewsSwapper.Swap(3);
                StartCoroutine(NewComingDelay(2f, 10));
                toggle = toggle + 1;
            }
            if (toggle == 7 && articleLoader.numArticleShared >= 17 && chatManager.CompleteCheckBox[10] == 1)
            {
                StartCoroutine(DelayBlurEffect(0.1f));
                StartCoroutine(NewComingDelay(2f, 11));
                toggle = toggle + 1;
                chatManager.CompleteCheckBox[10] = 2;
            }
            if (toggle == 8 && articleLoader.numArticleShared >= 19&& chatManager.CompleteCheckBox[11] == 1)
            {
                StartCoroutine(NewComingDelay(7f, 12));
                
                toggle = toggle + 1;
                chatManager.CompleteCheckBox[11] = 2;
            }

            if (chatManager.CompleteCheckBox[12] == 1)
            {
                StartCoroutine(DelayBlurEffect(10f));
                chatManager.CompleteCheckBox[12] = 2;

            }
            if (toggle == 9 && articleLoader.numArticleShared >= 24)
            {
                StartCoroutine(NewComingDelay(2f, 13));
                //StartCoroutine(NewComingDelay(18f, 13));
                toggle = toggle + 1;
            }
            if (toggle == 10 && articleLoader.numArticleShared >= 26 && chatManager.CompleteCheckBox[13] == 1)
            {
                StartCoroutine(NewComingDelay(4f, 14));
                toggle = toggle + 1;
                chatManager.CompleteCheckBox[13] = 2;
            }
        }
        else if (articleLoader.numArticleShared >= 28 && articleLoader.numArticleShared <= 40)
        {
            currentGameState = 4;
            Date.text = "5 / 12 / 2021";
            if (toggle == 11)
            {
                popUpSystem.DelayPopUp(3, new PopUpMessage("", Date.text, 0, 0), 0.1f);
                StartCoroutine(DelayBlurEffect(0.1f));
                breakingNewsSwapper.Swap(4);
                //StartCoroutine(PlayChatDelay(5f, 15));
                StartCoroutine(DelayMakePost(10f, 5));
               // newPostCreator.MakeNSPost(5);
                toggle = toggle + 1;
            }
            if (toggle == 12 && articleLoader.numArticleShared >= 31)
            {
                StartCoroutine(NewComingDelay(5f, 15));
                
                
                toggle = toggle + 1;
            }

            if (chatManager.CompleteCheckBox[15] == 1)
            {
                audiomanager.gameObject.GetComponent<AudioSource>().Stop();
                audiomanager.Secret.Play();
                StartCoroutine(DelaySwap(3f, 1));
                chatManager.CompleteCheckBox[15] = 2;
                StartCoroutine(DelayMakePost(1f, 6));
                StartCoroutine(DelaySwap(7f, 2));
                StartCoroutine(DelayMakePost(6f, 7));
                StartCoroutine(DelaySwap(12f, 3));
                StartCoroutine(DelayMakePost(15f, 8));
                StartCoroutine(NewComingDelay(20f, 16));
                StartCoroutine(DelaySwap(34f, 4));
                StartCoroutine(DelayBlurEffect(32f));
                

            }

            if (chatManager.CompleteCheckBox[16] == 1)
            {
                chatManager.CompleteCheckBox[16] = 2;
                StartCoroutine(DelayMakePost(3f, 9));
                StartCoroutine(DelayMakePost(9f, 10));
                StartCoroutine(DelayMakePost(17f, 11));
                StartCoroutine(DelaySwap(25f, 5));
                StartCoroutine(DelayMakePost(40f, 12));
                StartCoroutine(DelaySwap(45f, 6));
            }
                if (toggle == 13 && articleLoader.numArticleShared >= 37)
            {
                Date.text = "5 / 13 / 2021";
                StartCoroutine(NewComingDelay(13f, 17));
                StartCoroutine(DelayBlurEffect(30f));
                toggle = toggle + 1;
            }
                
            if (chatManager.CompleteCheckBox[17] == 1)
            {
                chatManager.CompleteCheckBox[17] = 2;
                TurnOffButton.gameObject.SetActive(true);
                TurnOffButton.onClick.AddListener(() => { 
                    turnoff.PlayEffect();
                    //SceneManager.LoadScene(2);
                   // DelaySceneLoad(4f);
                   });
            }
                

        }

    }
    IEnumerator DelaySceneLoad(float Delay)
    {
        yield return new WaitForSecondsRealtime(Delay);
        Debug.Log("Loading");
        SceneManager.LoadScene(2);

    }
    
    IEnumerator DelaySwap(float Delay, int index)
    {
        yield return new WaitForSecondsRealtime(Delay);
        switch (index)
        {
            case 1:
                mixswapper.Swap1();
                break;
            case 2:
                mixswapper.Swap2();
                break;
            case 3:
                mixswapper.Swap3();
                break;
            case 4:
                mixswapper.Swap4();
                break;
            case 5:
                mixswapper.Swap5();
                break;
            case 6:
                mixswapper.Swap6();
                break;
            default:
                break;
        }
    }
    IEnumerator DelayMakePost(float Delay, int index)
    {
        yield return new WaitForSecondsRealtime(Delay);
        newPostCreator.MakeNSPost(index);
    }
    IEnumerator DelayBlurEffect(float Delay)
    {
        yield return new WaitForSecondsRealtime(Delay);
        BlurControl.BlurBegin();
        yield return new WaitForSecondsRealtime(3f);
        BlurControl.BlurEnd();
        yield return new WaitForSecondsRealtime(1.2f);
        BlurControl.gameObject.GetComponent<Blur>().enabled = false;
        //yield return new WaitForSecondsRealtime(Delay);
    }

    IEnumerator DelayNotification(float Delay, int index)
    {
        yield return new WaitForSecondsRealtime(Delay);
        chatManager.NewNotification(index);
    }

    IEnumerator PlayChatDelay(float Delay, int index)
    {
        yield return new WaitForSecondsRealtime(Delay);
        //BlurControl.BlurBegin();
        //yield return new WaitForSecondsRealtime(0.2f);
        chatManager.gameObject.SetActive(true);
        //yield return new WaitForSecondsRealtime(3f);
        //BlurControl.BlurEnd();
        //yield return new WaitForSecondsRealtime(1.2f);
        //BlurControl.gameObject.GetComponent<Blur>().enabled = false;
        // BlurControl.BlurEnd();
        float OnComplete = chatManager.GetComponent<ChatManager>().PlayChat(index);
        //yield return new WaitForSecondsRealtime(OnComplete);
        //chatManager.GetComponent<ChatManager>().BackButton.gameObject.SetActive(true);

    }
    IEnumerator NewComingDelay(float Delay, int index)
    {
        yield return new WaitForSecondsRealtime(Delay);
        NewChatComing(index);

    }
}
