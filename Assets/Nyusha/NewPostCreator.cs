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
        int trendValue = newsarticle.Score;
        int priority = newsarticle.Priority;
        
        GameObject myPost = Instantiate(newPost, VerticalLayoutGroup);
        myPost.transform.SetAsFirstSibling();
        myPost.GetComponent<NewPost>().nameTag.text = GenerateUserName();
        myPost.GetComponent<NewPost>().NewsArticleTitle.text = newsarticle.Title;
        myPost.GetComponent<NewPost>().BodyArticle.text = newsarticle.Body;
        myPost.GetComponent<NewPost>().profilePic.sprite = GenerateProfilePic();
        myPost.GetComponent<NewPost>().Likes.text = Random.Range(priority * 10 + trendValue - trendValue / 2, priority * 10 + trendValue + 5).ToString();
        myPost.GetComponent<NewPost>().shares.text = Random.Range(priority * 10 + trendValue - ((trendValue * 2) / 3), 5 + priority * 10 + trendValue - trendValue / 3).ToString();
        myPost.GetComponent<NewPost>().comment1.text = GenerateRandomComment();
        myPost.GetComponent<NewPost>().comment1.text = GenerateRandomComment();
        
        
        Debug.Log("it's working!");
    }


    public string GenerateUserName()
    {
        return "ARandomPerson";
    }

    public Sprite GenerateProfilePic()
    {
        return Resources.Load<Sprite>("Pictures/ProfilePictures/defaultProfilePicture.jpg");
    }

    public string GenerateRandomComment()
    {
        int index = Random.Range(0, myCommentCollection.usercomments.Length);
        return myCommentCollection.usercomments[index].User + ": " + myCommentCollection.usercomments[index].Comment;
    }
}
