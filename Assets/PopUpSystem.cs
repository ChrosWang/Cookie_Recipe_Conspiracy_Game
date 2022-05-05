using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    

    /*
     * 1 - comments: xxx just commented on post yyy: "hahaha this is funny"
       2 - DMs: You receive a DM from xxx
       3 - Follower count: Followers 100 -> Followers 120
       4 - Shared Successfully
       5 - Likes: Your post yyy got 20 likes
       6 - Moderator: XXX just became a moderator
       7 - Deletion:  XXX just deleted the post: yyy
       8 - Someone else's post: xxx just posted: "check this out!"
    */

    public void DelayPopUp(int index, PopUpMessage popUpMessage, float Delay)
    {
        StartCoroutine(DelaymyPopUp(index, popUpMessage, Delay));
    }

    IEnumerator DelaymyPopUp(int index, PopUpMessage popUpMessage, float Delay)
    {
        yield return new WaitForSecondsRealtime(Delay);
        CreatePopUp(index, popUpMessage);
    }

    public void CreatePopUp(int index, PopUpMessage popUpMessage)
    {
        GameObject myPopUp = Instantiate(PopUpNotification, PopUpStack.GetComponent<RectTransform>()); ;
        this.GetComponent<AudioSource>().Play();

        switch (index)
        {
            case 1:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "New Comments";
                myPopUp.GetComponent<PopUpNotification>().Content.text = popUpMessage.username + " just commented on your post: " + popUpMessage.content;
                break;

            case 2:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "New Message";
                myPopUp.GetComponent<PopUpNotification>().Content.text = "You receive a message from " + popUpMessage.username;
                break;
            case 4:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "Mixer";
                myPopUp.GetComponent<PopUpNotification>().Content.text = "Your post is successfully shared!";
                break;
            default:
                break;
        }

        LeanTween.scale(myPopUp.GetComponent<PopUpNotification>().AnimationHelper, new Vector3(0.7f, 0.7f, 0.7f), 0.3f).setEase(LeanTweenType.easeInOutElastic);
        LTDescr d = LeanTween.moveLocalX(myPopUp.GetComponent<PopUpNotification>().AnimationHelper, 790, 0.3f).setDelay(8f).setEase(LeanTweenType.easeInOutCubic);
        d.destroyOnComplete = true;
        LTDescr e = LeanTween.moveLocalX(myPopUp, 790, 0.3f).setDelay(8f).setEase(LeanTweenType.easeInOutCubic);
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
