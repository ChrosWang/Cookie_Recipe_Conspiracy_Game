using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LikesSwapper : MonoBehaviour, IPointerClickHandler
{
    public Sprite Heart;
    public TMP_Text Likes;
    public bool liked;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!liked)
        {
            this.GetComponent<Image>().sprite = Heart;
            Likes.text = (int.Parse(Likes.text) + 1).ToString();
            liked = true;
        }
    }
}