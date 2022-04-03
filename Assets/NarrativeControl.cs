using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeControl : MonoBehaviour
{
    public int currentDay;

    public int currentChat; 

    public ChatManager chatManager;
    public NewsLoader articleLoader;
    public StateMachine stateMachine;
    public NewPostCreator newPostCreator;

    public void Start()
    {
        currentDay = 0;
        chatManager.NewNotification();
    }
    public void NewChatComing (int ID)
    {
        chatManager.NewNotification(); 
    }
}
