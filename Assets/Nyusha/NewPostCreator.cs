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

    public CommentCollection myCommentCollection = new CommentCollection();
    public TextAsset SpreadSheetJSON;



    // Start is called before the first frame update
    void Start()
    {

        myCommentCollection = JsonUtility.FromJson<CommentCollection>("{\"usercomments\":" + SpreadSheetJSON.text + "}");
        Debug.Log(myCommentCollection.usercomments[0].Comment);

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
        GameObject myPost = Instantiate(newPost, VerticalLayoutGroup);
        myPost.transform.SetAsFirstSibling();
        
        Debug.Log("it's working!");
    }

}
