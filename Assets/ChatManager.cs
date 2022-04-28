using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public GameObject ChatCanvas;
    public GameObject ChatButton;
    public GameObject NewNot;

    public ChatCollection myChatCollection = new ChatCollection();
    public ConvCollection myConvCollection = new ConvCollection();
    public TextAsset SpreadSheetJSON;

    public Transform layoutGroup;
    public GameObject chatBubble;
    public GameObject chatBubbleSarah;

    public float r1;
    public float l1;
    public float yTop;
    public float yInc;

    public Button BackButton;
    public Canvas canvas1;

    public void Start()
    {

        myChatCollection = JsonUtility.FromJson<ChatCollection>("{\"chatmessages\":" + SpreadSheetJSON.text + "}");
        Debug.Log(myChatCollection.chatmessages[0].Text);
        
        //PlayChat(1);
        BackButton.onClick.AddListener(() => this.gameObject.SetActive(false));

    }

    public void PlayChat(int order)
    {
        int count = 0;
        bool toggleName = false;
        float Delay = 0.5f;
        foreach (ChatMessage chatmessage in myChatCollection.chatmessages)
        {
            if (chatmessage.Order == order)
            {
                if (chatmessage.Character.Equals("")) { 
                
            
                }else if (chatmessage.Character.Equals("Sarah")) {
                    toggleName = true;
                    
                } else 
                {
                    toggleName = false;
                    
                }

                if (toggleName)
                {
                    Debug.Log(chatmessage.Character + ": " + chatmessage.Text);
                    
                    Debug.Log("Length is " + chatmessage.Text.Length);
                   
                    GameObject myChat = Instantiate(chatBubbleSarah, layoutGroup);
                    myChat.GetComponent<ChatBubble>().Character.text = chatmessage.Character;
                    myChat.GetComponent<ChatBubble>().Text.text = chatmessage.Text;
                    myChat.GetComponent<ChatBubble>().TimeSent.text = chatmessage.TimeSent;
                    myChat.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 112 + 40 * (chatmessage.Text.Length / 35));
                    Delay = Delay + chatmessage.TypeTime;
                    LeanTween.moveLocalX(myChat.GetComponent<ChatBubble>().AnimationHelper, r1, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                    
                    if (count >= 5)
                    {
                        yTop = yTop + myChat.GetComponent<RectTransform>().sizeDelta.y + yInc;
                        LeanTween.moveLocalY(layoutGroup.gameObject, yTop, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                        Debug.Log(yTop);

                    }
                } else
                {
                    Debug.Log(chatmessage.Character + ": " + chatmessage.Text);
                    
                    
                    //chatBubble.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, chatBubble.GetComponent<ChatBubble>().AnimationHelper.GetComponent<RectTransform>().sizeDelta.y);

                    GameObject myChat = Instantiate(chatBubble, layoutGroup);
                    myChat.GetComponent<ChatBubble>().Character.text = chatmessage.Character;
                    myChat.GetComponent<ChatBubble>().Text.text = chatmessage.Text;
                    myChat.GetComponent<ChatBubble>().TimeSent.text = chatmessage.TimeSent;
                    myChat.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 112 + 40 * (chatmessage.Text.Length / 35));
                    //myChat.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, myChat.GetComponent<ChatBubble>().AnimationHelper.GetComponent<RectTransform>().rect.height);
                    //Debug.Log("height of child is" + myChat.GetComponent<ChatBubble>().AnimationHelper.GetComponent<RectTransform>().sizeDelta.y);
                    Delay = Delay + chatmessage.TypeTime;
                    LeanTween.moveLocalX(myChat.GetComponent<ChatBubble>().AnimationHelper, l1, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                   
                    if (count >= 5)
                    {
                        
                        yTop = yTop + myChat.GetComponent<RectTransform>().sizeDelta.y + yInc;
                        LeanTween.moveLocalY(layoutGroup.gameObject, yTop, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                        Debug.Log(yTop);

                    }
                }

                
                
                count++;
                //Debug.Log(Delay);  (float)(chatmessage.Text.Length / 8.0);
                //myChat.transform.SetAsFirstSibling();
                //yield WaitForSeconds(3);
            }
        }


    }


    public void NewNotification ()
    {
        NewNot.SetActive(true); 
    }

    public void GenerateNewChat(int ConvoID)
    {
        //Use the ID to find the corresponding chat in the Chat Collection to generate a chat. 

    }


}
