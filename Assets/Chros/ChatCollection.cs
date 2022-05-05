using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ChatMessage
{
    public int GameState;
    public int Order;
    public  string Character;
    public string Text;
    public string TimeSent;
    public string Keywords;
    public float TypeTime;
    public string Notes;
    public bool is_EndMessage;
}

//[System.Serializable]
public class Conversation
{
    public ChatMessage[] chatmessages = new ChatMessage[99];
    public string character;
    public int GameState;
    public int Order;
    public void setMessage(ChatMessage TargetChat)
    {
        Debug.Log("Step 3");
        chatmessages[chatmessages.Length - 1] = TargetChat; 
    }

}

[System.Serializable]
public class ChatCollection
{
    public ChatMessage[] chatmessages; 

    

    
}

[System.Serializable]
public class ConvCollection
{
    public Conversation[] conversations = new Conversation[99];
    public void initializeConv ()
    {

    }
    public void TakeMessages (int order, ChatMessage TargetChat)
    {
        Debug.Log("Step 2 putting order " + order +" in " + conversations.Length);
        conversations[order].setMessage(TargetChat); 
    }
}
