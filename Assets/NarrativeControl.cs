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


    public void Start()
    {
        currentGameState = 0;
        articleLoader.Initialization();
        newPostCreator.Initialization();
        chatManager.Initialization();

        articleLoader.MakePost(1);
        articleLoader.MakePost(2);
        articleLoader.MakePost(3);

        NewChatComing(1);
       
    }
    public void NewChatComing (int ID)
    {
        popUpSystem.CreatePopUp(2, new PopUpMessage(chatManager.GetComponent<ChatManager>().NameList[ID], "", 0, 0));
        StartCoroutine(PlayChatDelay(8f, ID));
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
       
        switch (articleLoader.numArticleShared)
        {
            case 1:
                if (toggle == 1)
                {
                    StartCoroutine(PlayChatDelay(2f, 2));
                    toggle = toggle + 1;

                }
                break;
            default:
                break;
        }
    }

    IEnumerator DelayNotification(float Delay, int index)
    {
        yield return new WaitForSecondsRealtime(Delay);
        chatManager.NewNotification(index);
    }

    IEnumerator PlayChatDelay(float Delay, int index)
    {
        yield return new WaitForSecondsRealtime(Delay);
        chatManager.gameObject.SetActive(true);
        chatManager.GetComponent<ChatManager>().PlayChat(index);

    }
}
