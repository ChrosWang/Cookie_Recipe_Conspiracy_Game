using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NarrativeControl : MonoBehaviour
{
    public int currentDay;

    public int currentChat; 

    public ChatManager chatManager;
    public NewsLoader articleLoader;
    public StateMachine stateMachine;
    public NewPostCreator newPostCreator;

    public Button Test; 

    public void Start()
    {
        currentDay = 0;
        

        Test.onClick.AddListener(() =>
        {
            chatManager.NewNotification();
        }
        );
    }
    public void NewChatComing (int ID)
    {
        chatManager.NewNotification(); 
    }

    public void Update()
    {
        
    }
}
