using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewPostCreator : MonoBehaviour
{
    public GameObject newPost;
    public Button NewPostButton;
    public Transform VerticalLayoutGroup; 


    // Start is called before the first frame update
    void Start()
    {
         //NewPostButton.onClick.AddListener(() => MakePost()); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakePost(NewsArticle newsarticle)
     {
        newPost.GetComponent<NewPost>().nameTag.text = "Chros";
        newPost.GetComponent<NewPost>().NewsArticleTitle.text = newsarticle.Title;
        newPost.GetComponent<NewPost>().BodyArticle.text = newsarticle.Body;
        Instantiate(newPost, VerticalLayoutGroup);
        
        Debug.Log("it's working!");
    }

}
