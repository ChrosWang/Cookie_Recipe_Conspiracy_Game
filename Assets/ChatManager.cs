using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public GameObject ChatCanvas;
    public GameObject ChatButton;
    public GameObject NewNot;

    public ChatCollection chatCollection; 


    public void NewNotification ()
    {
        NewNot.SetActive(true); 
    }

    public void GenerateNewChat(int ConvoID)
    {
        //Use the ID to find the corresponding chat in the Chat Collection to generate a chat. 

    }


}
