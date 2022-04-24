using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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


    void Start()
    {

        myChatCollection = JsonUtility.FromJson<ChatCollection>("{\"chatmessages\":" + SpreadSheetJSON.text + "}");
        Debug.Log(myChatCollection.chatmessages[0].Text);
        PlayChat(1);

    }

    public void PlayChat(int order)
    {
        int count = 0;
        bool toggleName = false;
        float Delay = 3f;
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
                    chatBubbleSarah.GetComponent<ChatBubble>().Character.text = chatmessage.Character;
                    chatBubbleSarah.GetComponent<ChatBubble>().Text.text = chatmessage.Text;
                    chatBubbleSarah.GetComponent<ChatBubble>().TimeSent.text = chatmessage.TimeSent;
                    GameObject myChat = Instantiate(chatBubbleSarah, layoutGroup);
                    LeanTween.moveLocalX(myChat.GetComponent<ChatBubble>().AnimationHelper, r1, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                    Debug.Log(myChat.GetComponent<RectTransform>().position.y);
                    if (count >= 3)
                    {
                        yTop = yTop + myChat.GetComponent<RectTransform>().localScale.y + yInc;
                        LeanTween.moveY(layoutGroup.gameObject, yTop, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);

                    }
                } else
                {
                    Debug.Log(chatmessage.Character + ": " + chatmessage.Text);
                    chatBubble.GetComponent<ChatBubble>().Character.text = chatmessage.Character;
                    chatBubble.GetComponent<ChatBubble>().Text.text = chatmessage.Text;
                    chatBubble.GetComponent<ChatBubble>().TimeSent.text = chatmessage.TimeSent;
                    GameObject myChat = Instantiate(chatBubble, layoutGroup);
                    LeanTween.moveLocalX(myChat.GetComponent<ChatBubble>().AnimationHelper, l1, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                    Debug.Log(myChat.GetComponent<RectTransform>().position.y);
                    if (count >= 3)
                    {
                        yTop = yTop + myChat.GetComponent<RectTransform>().localScale.y + yInc;
                        LeanTween.moveY(layoutGroup.gameObject, yTop, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                        
                    }
                }

                
                Delay = Delay + 2f;
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
