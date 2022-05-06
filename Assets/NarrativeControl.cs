using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NarrativeControl : MonoBehaviour
{
    public int currentGameState;

    public int currentChat;
    int toggle = 1;

    public ChatManager chatManager;
    public NewsLoader articleLoader;
    public StateMachine stateMachine;
    public NewPostCreator newPostCreator;
    public PopUpSystem popUpSystem;
    public BreakingNewsSwapper breakingNewsSwapper;
    public CameraBlur BlurControl;


    public void Start()
    {
        currentGameState = 0;
        articleLoader.Initialization();
        newPostCreator.Initialization();
        chatManager.Initialization();

        articleLoader.MakePost(1);
        articleLoader.MakePost(2);
        //articleLoader.MakePost(3);

        NewChatComing(1);
       
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
        
        /*
        if (articleLoader.numArticleShared >= 1 && articleLoader.numArticleShared < 3)
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
        else if (articleLoader.numArticleShared >= 3 && articleLoader.numArticleShared < 13)
        {
            currentGameState = 2;
            if (toggle == 2)
            {
                breakingNewsSwapper.Swap(2);
                StartCoroutine(PlayChatDelay(2f, 5));
                toggle = toggle + 1;

            }

            if (toggle == 3 && articleLoader.numArticleShared >= 8)
            {
                StartCoroutine(PlayChatDelay(2f, 6));
                StartCoroutine(NewComingDelay(12f, 7));
                toggle = toggle + 1;
            }


            if (toggle == 4 && articleLoader.numArticleShared >= 12)
            {
                StartCoroutine(PlayChatDelay(2f, 8));
                toggle = toggle + 1;
            }

        }
        else if (articleLoader.numArticleShared >= 13 && articleLoader.numArticleShared < 23)
        {
            currentGameState = 3;
            if (toggle == 5)
            {
                breakingNewsSwapper.Swap(3);
                StartCoroutine(PlayChatDelay(5f, 9));
                toggle = toggle + 1;
            }
            if (toggle == 6 && articleLoader.numArticleShared >= 17)
            {
                StartCoroutine(PlayChatDelay(2f, 10));
                toggle = toggle + 1;
            }
            if (toggle == 7 && articleLoader.numArticleShared >= 20)
            {
                StartCoroutine(PlayChatDelay(2f, 11));
                toggle = toggle + 1;
            }
            if (toggle == 8 && articleLoader.numArticleShared >= 22)
            {
                StartCoroutine(PlayChatDelay(2f, 12));
                StartCoroutine(NewComingDelay(18f, 13));
                toggle = toggle + 1;
            }
        }
        */
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
