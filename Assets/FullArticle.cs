using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FullArticle : MonoBehaviour
{
    public TMP_Text NewsSite;
    public TMP_Text Date;
    public TMP_Text Title;
    public TMP_Text Author;
    public TMP_Text Body;
    public GameObject MagicFix;
    public GameObject AnimationHelper;
    public Button ShareButton;
    public Button XButton;
    public NewsArticle news;
    //public GameObject MyFullArticlePage;

    private void Start()
    {
        Debug.Log("Button Assign");
        
    }
}
