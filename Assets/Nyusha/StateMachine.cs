using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{

    //singleton setup for nerds and dweebs
    private static StateMachine instance;

    public static StateMachine FindInstance()
    {
        return instance;
    }


    //Declare all pages here

    public GameObject socialCanvas;
    public GameObject newsfeedCanvas;
    public GameObject chatCanvas;

    //Buttons

    public Button social;
    public Button newsfeed;
    public Button chat;

    public enum Tab
    {
        Social,
        Newsfeed,
        Chat
    }

    public Tab currentTab; //tracks the current tab

    void Awake()
    {
        //singleton for dumb idiot computers
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ///ChangeTab(Tab.Social); //start with Social

        social.onClick.AddListener(() => ChangeTab(Tab.Social));
        //if button social is clicked, call function ChangeTab(Tab.Social)

        newsfeed.onClick.AddListener(() => ChangeTab(Tab.Newsfeed));
        chat.onClick.AddListener(() =>
        {
            Debug.Log("Clicking the chat");
            ChangeTab(Tab.Chat);
            chatCanvas.GetComponent<ChatManager>().NewNot.SetActive(false);
        }
        );
    }

    public void ChangeTab(Tab newTab)
    {
        currentTab = newTab;
        switch (newTab) //check the newTab
        { //if the newTab is...
            case Tab.Social:
                socialCanvas.SetActive(true);
                newsfeedCanvas.SetActive(false);
                chatCanvas.SetActive(false);
                Debug.Log("Change to tab social");
                break;
            case Tab.Newsfeed:
                //socialCanvas.SetActive(false);
                newsfeedCanvas.SetActive(true);
                chatCanvas.SetActive(false);
                Debug.Log("Change to tab newsfeed");
                break;
            case Tab.Chat:
          //  if (socialCanvas){
              //  socialCanvas.SetActive(true);
              //  newsfeedCanvas.SetActive(false);}
                 //else if (newsfeedCanvas){
                //socialCanvas.SetActive(false);
                //newsfeedCanvas.SetActive(true);}
                if (chatCanvas)
                {
                    chatCanvas.SetActive(true);
                } else
                {
                    chatCanvas.SetActive(false);
                }
                    

                Debug.Log("Change to tab chat");
                break;
            default:
                Debug.Log("this state doesn't exist");
                break;
        }
    }
}
