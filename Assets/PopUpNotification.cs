using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopUpNotification : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text Subject;
    public TMP_Text Content;
    public Image Icon;
    public GameObject AnimationHelper;
    public ProfileGenerator ppic;
    public GameObject othershare;
    public GameObject share;
    public GameObject message;
    public GameObject Trash;
    public GameObject Replace;
    public Image Badge;
    public GameObject Wendy;
    public GameObject Chris;

    public GameObject statemachine;
    public int tab;

    public void Start()
    {
        statemachine = GameObject.Find("Game Manager _ State Machine");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        statemachine.GetComponent<StateMachine>().ChangeTabNum(tab);

    }

}
