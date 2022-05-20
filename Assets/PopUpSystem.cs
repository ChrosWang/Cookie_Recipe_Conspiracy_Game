using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage
{
    public string username;
    public string content;
    public int followers;
    public int likes;

    public PopUpMessage(string u, string c, int f, int l)
    {
        username = u;
        content = c;
        followers = f;
        likes = l;
    }
}

public class PopUpSystem : MonoBehaviour
{
    public GameObject PopUpStack;
    public GameObject PopUpNotification;
    public AudioManager audiomanager;
    public Sprite[] badgeSprites;
    

    /*
     * 1 - comments: xxx just commented on post yyy: "hahaha this is funny"
       2 - DMs: You receive a DM from xxx
       3 - Breaking News swap
       4 - Shared Successfully
       5 - Likes: Your post yyy got 20 likes
       6 - Moderator: XXX just became a moderator
       7 - Deletion:  XXX just deleted the post: yyy
       8 - Someone else's post: xxx just posted: "check this out!"
    */

    public void DelayPopUp(int index, PopUpMessage popUpMessage, float Delay)
    {
        StartCoroutine(DelaymyPopUp(index, popUpMessage, Delay + Random.Range(0.3f,0.9f)));
    }

    IEnumerator DelaymyPopUp(int index, PopUpMessage popUpMessage, float Delay)
    {
        yield return new WaitForSecondsRealtime(Delay);
        CreatePopUp(index, popUpMessage);
    }

    public void CreatePopUp(int index, PopUpMessage popUpMessage)
    {
        GameObject myPopUp = Instantiate(PopUpNotification, PopUpStack.GetComponent<RectTransform>()); ;
        myPopUp.GetComponent<PopUpNotification>().Icon.gameObject.SetActive(false);
        myPopUp.GetComponent<PopUpNotification>().share.gameObject.SetActive(false);
        myPopUp.GetComponent<PopUpNotification>().othershare.gameObject.SetActive(false);
        myPopUp.GetComponent<PopUpNotification>().message.gameObject.SetActive(false);
        myPopUp.GetComponent<PopUpNotification>().ppic.gameObject.SetActive(false);
        myPopUp.GetComponent<PopUpNotification>().Trash.gameObject.SetActive(false);
        myPopUp.GetComponent<PopUpNotification>().Replace.gameObject.SetActive(false);

        switch (index)
        {
            case 1:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "New Comments";
                myPopUp.GetComponent<PopUpNotification>().Content.text = popUpMessage.username + " just commented on your post: " + popUpMessage.content;
                myPopUp.GetComponent<PopUpNotification>().ppic.gameObject.SetActive(true);
                myPopUp.GetComponent<PopUpNotification>().Icon.gameObject.SetActive(false);
                if (popUpMessage.username.Contains("WendyDW"))
                {
                    myPopUp.GetComponent<PopUpNotification>().Wendy.SetActive(true);
                }
                else if (popUpMessage.username.Contains("MrSupreme88"))
                {
                    myPopUp.GetComponent<PopUpNotification>().Chris.SetActive(true);
                }
                else
                {
                    myPopUp.GetComponent<PopUpNotification>().ppic.RandomRoll();
                }
                this.GetComponent<AudioSource>().Play();
                myPopUp.GetComponent<PopUpNotification>().tab = 1;
                break;

            case 2:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "New Message";
                myPopUp.GetComponent<PopUpNotification>().Content.text = "You receive a message from " + popUpMessage.username;
                myPopUp.GetComponent<PopUpNotification>().message.gameObject.SetActive(true);

                this.GetComponent<AudioSource>().Play();
                myPopUp.GetComponent<PopUpNotification>().tab = 3;
                break;

            case 3:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "Breaking News";
                myPopUp.GetComponent<PopUpNotification>().Content.text = popUpMessage.content + " View Today's Breaking News!";
                myPopUp.GetComponent<PopUpNotification>().Icon.gameObject.SetActive(true);
                myPopUp.GetComponent<PopUpNotification>().AnimationHelper.GetComponent<Image>().color = new Color(1, 0.8f, 0.8f);
                myPopUp.GetComponent<PopUpNotification>().tab = 2;

                this.GetComponent<AudioSource>().Play();
                break;
            case 4:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "Mixer";
                myPopUp.GetComponent<PopUpNotification>().Content.text = "Your post is successfully shared!";
                myPopUp.GetComponent<PopUpNotification>().share.gameObject.SetActive(true);
                this.GetComponent<AudioSource>().Play();
                myPopUp.GetComponent<PopUpNotification>().tab = 1;
                break;
            case 7:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "Deletion!";
                myPopUp.GetComponent<PopUpNotification>().Content.text = popUpMessage.username + " just deleted a post!";
                myPopUp.GetComponent<PopUpNotification>().Trash.gameObject.SetActive(true);
                audiomanager.OtherS.Play();
                myPopUp.GetComponent<PopUpNotification>().tab = 1;
                break;
            case 8:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "Mixer";
                myPopUp.GetComponent<PopUpNotification>().Content.text = popUpMessage.username + " just posted on your page: " + popUpMessage.content;
                myPopUp.GetComponent<PopUpNotification>().othershare.gameObject.SetActive(true);
                myPopUp.GetComponent<PopUpNotification>().tab = 1;
                audiomanager.OtherS.Play();
                break;
            case 9:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "Mixer";
                myPopUp.GetComponent<PopUpNotification>().Content.text = popUpMessage.content;
                myPopUp.GetComponent<PopUpNotification>().Replace.gameObject.SetActive(true);
                myPopUp.GetComponent<PopUpNotification>().tab = 1;

                audiomanager.OtherS.Play();
                break;
            case 10:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "Mixer";
                myPopUp.GetComponent<PopUpNotification>().Content.text = popUpMessage.content;
                myPopUp.GetComponent<PopUpNotification>().Badge.gameObject.SetActive(true);
                myPopUp.GetComponent<PopUpNotification>().Badge.sprite = badgeSprites[popUpMessage.followers];
                myPopUp.GetComponent<PopUpNotification>().tab = 2;
                audiomanager.OtherS.Play();
                break;
            default:
                break;
        }

        LeanTween.scale(myPopUp.GetComponent<PopUpNotification>().AnimationHelper, new Vector3(0.7f, 0.7f, 0.7f), 0.3f).setEase(LeanTweenType.easeInOutElastic);
        LTDescr d = LeanTween.moveLocalX(myPopUp.GetComponent<PopUpNotification>().AnimationHelper, 790, 0.3f).setDelay(8f).setEase(LeanTweenType.easeInOutCubic);
        d.destroyOnComplete = true;
        LTDescr e = LeanTween.moveLocalX(myPopUp, 790, 0.3f).setDelay(11f).setEase(LeanTweenType.easeInOutCubic);
        e.destroyOnComplete = true;
        //LeanTween.addListener(myPopUp, id , DestroyMe);
    }
    //void DestroyMe(LTEvent e)
   // {

   // }
    private void Update()
    {
        
    }
}
