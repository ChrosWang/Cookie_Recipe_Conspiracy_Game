using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ChatMessage
{
    int GameState;
    int Order;
    string Character;
    string Text;
    string TimeSent;
}
public class ChatCollection
{
    string ContactName;
    string[][] ChatList;
}
