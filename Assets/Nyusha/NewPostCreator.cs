using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPostCreator : MonoBehaviour
{
    public GameObject newsArticle;

    // Start is called before the first frame update
    void Start()
    {
        // MakeNewPost.onClick.AddListener(() => MakeNewPost()); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakePost()
    {   
        Instantiate(newArticle);
        newsArticle.Title = ""; 
        Debug.Log("it's working!");
    }

    //

}
