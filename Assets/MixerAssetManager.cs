using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MixerAssetManager : MonoBehaviour
{
    public TMP_Text WelcomeText;
    public TMP_Text WelcomeText2;
    public TMP_Text ModeratorNames;
    public TMP_Text ModeratorTag;
    public TMP_Text MembersNum;
    public TMP_Text OnlineNum;
    public TMP_Text Members;
    public TMP_Text MostActive;
    public TMP_Text MostActiveTag;
    public TMP_Text RecentMember;
    public TMP_Text RecentMemberTag;

    public Image CoverPage;
    public Image CoverPage2;
    public Image Title;
    public Image Title2;
    public Image icon;
    public Image icon2;
    public Image BackgroundBB;

    public Sprite BBBg;
    int currentMembers;

    public PopUpSystem popupsystem;
    int onlineMembers;
    public void Start()
    {
        currentMembers = 20;
        OnlineNum.text = 2.ToString();
    }
    public void AddNewMembers(int increase)
    {
        currentMembers = currentMembers + increase;
        MembersNum.text = currentMembers.ToString();

    }

    public void Swap1()
    {
        Title.gameObject.SetActive(false);
        Title2.gameObject.SetActive(true);
        popupsystem.DelayPopUp(9, new PopUpMessage("System", "Title of your Mixer has been modified to: Blood Brothers", 0, 0), 2f);
    }

    public void Swap2()
    {
        BackgroundBB.gameObject.SetActive(true);
        icon.gameObject.SetActive(false);
        popupsystem.DelayPopUp(9, new PopUpMessage("System", "Background of your Mixer has been changed to Blood Theme", 0, 0), 2f);

    }
    public void Swap3()
    {
        WelcomeText.text = "We’ll all made the connection and cannot deny it any longer, <br>White sugar,";
        WelcomeText2.text = "Welcome to the revolution!";
        popupsystem.DelayPopUp(9, new PopUpMessage("System", "Your Welcome Post has been modified: We’ll all made the connection and cannot deny it any longer, <br>White sugar,", 0, 0), 2f);
    }
    public void Swap4()
    {
        ModeratorTag.text = "Leaders:";
        ModeratorNames.text = "SuperSarah_5<br>WendyDW<br>Mr.Supreme88";
        popupsystem.DelayPopUp(9, new PopUpMessage("System", "The name Moderator has been changed to Leader", 0, 0), 2f);

    }
    public void Swap5()
    {
        MostActiveTag.text = "Most Active Brothers:";
        MostActive.text = "WendyDW<br>Mr.Supreme88";
        RecentMemberTag.text = "Recent Blood Brothers:";
        popupsystem.DelayPopUp(9, new PopUpMessage("System", "Your followers are called: Blood Brothers", 0, 0), 2f);

    }
    public void Swap6()
    {
        CoverPage.gameObject.SetActive(false);
        CoverPage2.gameObject.SetActive(true);
        popupsystem.DelayPopUp(9, new PopUpMessage("System", "Your cover page has been replaced", 0, 0), 2f);
    }
}
