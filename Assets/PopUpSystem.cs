using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void CreatePopUp(int index)
    {
        GameObject myPopUp = Instantiate(PopUpNotification, PopUpStack.GetComponent<RectTransform>()); ;

        switch (index)
        {
            case 1:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "New Comments";
                myPopUp.GetComponent<PopUpNotification>().Content.text = "";
                break;

            case 4:
                myPopUp.GetComponent<PopUpNotification>().Subject.text = "Mixer";
                myPopUp.GetComponent<PopUpNotification>().Content.text = "Your post is successfully shared!";
                break;
            default:
                break;
        }

        LeanTween.scale(myPopUp.GetComponent<PopUpNotification>().AnimationHelper, new Vector3(1f, 1f, 1f), 0.3f).setEase(LeanTweenType.easeInOutElastic);
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
