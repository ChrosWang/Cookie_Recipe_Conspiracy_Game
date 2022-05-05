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
    public TMP_Text MembersNum;
    public TMP_Text OnlineNum;
    public TMP_Text Members;
    public TMP_Text MostActive;
    public TMP_Text RecentMember;

    public Image CoverPage;
    public Image Title;

    int currentMembers;
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
}
