using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public GameObject ChatCanvas;
    //public GameObject ChatButton;
    //public GameObject NewNot;

    public ChatCollection myChatCollection = new ChatCollection();
    public ConvCollection myConvCollection = new ConvCollection();
    public TextAsset SpreadSheetJSON;

    public Transform mylayoutGroup;
    public GameObject content;

    public GameObject chatBubble;
    public GameObject chatBubbleSarah;

    public PopUpSystem popUpSystem;

    public float r1;
    public float l1;
   // public float yTop;
    public float yInc;

    public Button BackButton;
    public Button SpeedUpButton;
    public Canvas canvas1;
    bool speedUp = false;
    public GameObject Scroller;

    public string[] NameList = {"","Daniel",
        "Daniel",
        "Wendy",
        "Daniel",
        "Wendy",
        "MIXER",
        "Chris",
        "Hearthfoot Wellness and Medical Center",
        "Hearthfoot Wellness and Medical Center",
        "Wendy",
        "Daniel",
        "Wendy",
        "Chris", 
        "MIXER", 
        "Wendy", 
        "Wendy" };
    public void Start()
    {

        

    }
    void UpdateScroller()
    {
        Scroller.GetComponent<ScrollRect>().horizontalNormalizedPosition = 1f;
        Scroller.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
    }

    public void Initialization()
    {
        myChatCollection = JsonUtility.FromJson<ChatCollection>("{\"chatmessages\":" + SpreadSheetJSON.text + "}");
     //   Debug.Log(myChatCollection.chatmessages[0].Text);

        //PlayChat(1);
        BackButton.onClick.AddListener(() => 
        {
            speedUp = false;
            this.gameObject.SetActive(false);
            
        });
        SpeedUpButton.onClick.AddListener(() => SpeedUpChat());
    }

    public void SpeedUpChat()
    {

        if (!speedUp)
        {
            //SpeedUpButton

            speedUp = true;
        }
        else
        {
            speedUp = false;
        }
    }

    void RefreshLayoutGroups(ChatBubble myChat)
    {
        Canvas.ForceUpdateCanvases();
        VerticalLayoutGroup vg;
        HorizontalLayoutGroup hg;
        for (int i = 0; i < myChat.GetComponent<ChatBubble>().LayoutGroups.Length; i++)
        {
            Canvas.ForceUpdateCanvases();
            hg = myChat.GetComponent<ChatBubble>().LayoutGroups[i].GetComponent<HorizontalLayoutGroup>();
            if (hg != null)
            {
                hg.enabled = false;
                hg.enabled = true;
            }
            Canvas.ForceUpdateCanvases();
            vg = myChat.GetComponent<ChatBubble>().LayoutGroups[i].GetComponent<VerticalLayoutGroup>();
            if (vg != null)
            {
                vg.enabled = false;
                vg.enabled = true;
            }
        }
    }
    public float PlayChat(int order)
    {
        float yTop = -46.79f;
        UpdateScroller();

        

       foreach (Transform child in content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameObject layoutGroup = Instantiate(mylayoutGroup.gameObject, content.transform);

        int count = 0;
        bool toggleName = false;
        float Delay = 0.5f;

        float sizeSum = 0;

        BackButton.gameObject.SetActive(false);
        //float DelayTotal=0;
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
                   // Debug.Log(chatmessage.Character + ": " + chatmessage.Text);
                    
                  //  Debug.Log("Length is " + chatmessage.Text.Length);
                   
                    GameObject myChat = Instantiate(chatBubbleSarah, layoutGroup.transform);
                    myChat.GetComponent<ChatBubble>().Character.text = chatmessage.Character;
                    myChat.GetComponent<ChatBubble>().Text.text = chatmessage.Text;
                    myChat.GetComponent<ChatBubble>().TimeSent.text = chatmessage.TimeSent;



                    RefreshLayoutGroups(myChat.GetComponent<ChatBubble>());
                    myChat.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 44 + myChat.GetComponent<ChatBubble>().LayoutGroups[1].GetComponent<RectTransform>().sizeDelta.y);
                    //myChat.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 112 + 40 * (chatmessage.Text.Length / 35));
                    Delay = Delay + chatmessage.TypeTime;
                    LeanTween.moveLocalX(myChat.GetComponent<ChatBubble>().AnimationHelper, r1, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                    /*
                    if (count >= 5)
                    {
                        yTop = yTop + myChat.GetComponent<RectTransform>().sizeDelta.y + yInc;
                        LeanTween.moveLocalY(layoutGroup.gameObject, yTop, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                     //   Debug.Log(yTop);

                    }*/
                    sizeSum = sizeSum + myChat.GetComponent<RectTransform>().sizeDelta.y;
                    if (sizeSum > 1080)
                    {
                        yTop = yTop + myChat.GetComponent<RectTransform>().sizeDelta.y;
                        LeanTween.moveLocalY(layoutGroup.gameObject, yTop, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                    }
                } else
                {
                   // Debug.Log(chatmessage.Character + ": " + chatmessage.Text);
                    
                    
                    //chatBubble.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, chatBubble.GetComponent<ChatBubble>().AnimationHelper.GetComponent<RectTransform>().sizeDelta.y);

                    GameObject myChat = Instantiate(chatBubble, layoutGroup.transform);
                    myChat.GetComponent<ChatBubble>().Character.text = chatmessage.Character;
                    myChat.GetComponent<ChatBubble>().Text.text = chatmessage.Text;
                    myChat.GetComponent<ChatBubble>().TimeSent.text = chatmessage.TimeSent;
                    RefreshLayoutGroups(myChat.GetComponent<ChatBubble>());
                    myChat.GetComponent<RectTransform>().sizeDelta = new Vector2(1920,44+ myChat.GetComponent<ChatBubble>().LayoutGroups[1].GetComponent<RectTransform>().sizeDelta.y);
                    //myChat.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 112 + 40 * (chatmessage.Text.Length / 35));
                    //myChat.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, myChat.GetComponent<ChatBubble>().AnimationHelper.GetComponent<RectTransform>().rect.height);
                    //Debug.Log("height of child is" + myChat.GetComponent<ChatBubble>().AnimationHelper.GetComponent<RectTransform>().sizeDelta.y);
                    Delay = Delay + chatmessage.TypeTime;
                    LTDescr myTween;
                    myTween = LeanTween.moveLocalX(myChat.GetComponent<ChatBubble>().AnimationHelper, l1, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);

                    sizeSum = sizeSum + myChat.GetComponent<RectTransform>().sizeDelta.y;


                    if (sizeSum > 980)
                    {
                        yTop = yTop + myChat.GetComponent<RectTransform>().sizeDelta.y;
                        LeanTween.moveLocalY(layoutGroup.gameObject, yTop, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                    }

                    if (chatmessage.is_EndMessage)
                    {
                        Action BackButtonAppear = () =>
                        {
                            BackButton.gameObject.SetActive(true);
                            
                        };
                        myTween.setOnComplete(BackButtonAppear);
                    }
                    /*if (count >= 5)
                    {
                        
                        yTop = yTop + myChat.GetComponent<RectTransform>().sizeDelta.y + yInc;
                        LeanTween.moveLocalY(layoutGroup.gameObject, yTop, 0.3f).setDelay(Delay).setEase(LeanTweenType.easeInOutCubic);
                    //    Debug.Log(yTop);

                    }*/
                }

                
                
                count++;
                //Debug.Log(Delay);  (float)(chatmessage.Text.Length / 8.0);
                //myChat.transform.SetAsFirstSibling();
                //yield WaitForSeconds(3);
            }
        }
        return Delay;

    }


    public void NewNotification (int index)
    {
        //NewNot.SetActive(true);
        
        
        //this.gameObject.SetActive(true);
       // PlayChat(index);

    }



    public void GenerateNewChat(int ConvoID)
    {
        //Use the ID to find the corresponding chat in the Chat Collection to generate a chat. 

    }

    public void Update()
    {
        if (speedUp)
        {
            Time.timeScale = 4f;
        } else
        {
            Time.timeScale = 1f;
        }
        
    }


}
