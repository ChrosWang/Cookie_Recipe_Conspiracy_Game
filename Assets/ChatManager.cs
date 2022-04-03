using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public GameObject ChatCanvas;
    public GameObject ChatButton;
    public GameObject NewNot;


    public void NewNotification ()
    {
        NewNot.SetActive(true); 
    }


}
