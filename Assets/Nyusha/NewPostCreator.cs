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

        
       // Debug.Log(myCommentCollection.usercomments[0].Comment);

    }

    public void Initialization()
    {
        myCommentCollection = JsonUtility.FromJson<CommentCollection>("{\"usercomments\":" + SpreadSheetJSON.text + "}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RefreshEverything()
    {
        Canvas.ForceUpdateCanvases();
        VerticalLayoutGroup.GetComponent<VerticalLayoutGroup>().enabled = false;
        VerticalLayoutGroup.GetComponent<VerticalLayoutGroup>().enabled = true;
        VerticalLayoutGroup vg;
        HorizontalLayoutGroup hg;
        foreach (Transform child in VerticalLayoutGroup)
        {
            Canvas.ForceUpdateCanvases();
            child.GetComponent<NewPost>().LayoutGroup1.GetComponent<HorizontalLayoutGroup>().enabled = false;
            child.GetComponent<NewPost>().LayoutGroup1.GetComponent<HorizontalLayoutGroup>().enabled = true;
            Canvas.ForceUpdateCanvases();
            child.GetComponent<NewPost>().LayoutGroup2.GetComponent<VerticalLayoutGroup>().enabled = false;
            child.GetComponent<NewPost>().LayoutGroup2.GetComponent<VerticalLayoutGroup>().enabled = true;
            Canvas.ForceUpdateCanvases();
            child.GetComponent<NewPost>().LayoutGroup3.GetComponent<VerticalLayoutGroup>().enabled = false;
            child.GetComponent<NewPost>().LayoutGroup3.GetComponent<VerticalLayoutGroup>().enabled = true;
        }
    
    }
    public void PostRefresher(GameObject myPost)
    {
        Canvas.ForceUpdateCanvases();
        VerticalLayoutGroup.GetComponent<VerticalLayoutGroup>().enabled = false;
        VerticalLayoutGroup.GetComponent<VerticalLayoutGroup>().enabled = true;
        Canvas.ForceUpdateCanvases();
        myPost.GetComponent<VerticalLayoutGroup>().enabled = false;
        myPost.GetComponent<VerticalLayoutGroup>().enabled = true;
        Canvas.ForceUpdateCanvases();
        myPost.GetComponent<NewPost>().LayoutGroup1.GetComponent<HorizontalLayoutGroup>().enabled = false;
        myPost.GetComponent<NewPost>().LayoutGroup1.GetComponent<HorizontalLayoutGroup>().enabled = true;
        Canvas.ForceUpdateCanvases();
        myPost.GetComponent<NewPost>().LayoutGroup2.GetComponent<VerticalLayoutGroup>().enabled = false;
        myPost.GetComponent<NewPost>().LayoutGroup2.GetComponent<VerticalLayoutGroup>().enabled = true;
        Canvas.ForceUpdateCanvases();
        myPost.GetComponent<NewPost>().LayoutGroup3.GetComponent<VerticalLayoutGroup>().enabled = false;
        myPost.GetComponent<NewPost>().LayoutGroup3.GetComponent<VerticalLayoutGroup>().enabled = true;
    }

    public void MakePost(NewsArticle newsarticle)
     {
        int trendValue = newsarticle.Score;
        int priority = newsarticle.Priority;
        
        GameObject myPost = Instantiate(newPost, VerticalLayoutGroup);
        myPost.transform.SetAsFirstSibling();
        PostRefresher(myPost);
        //PostRefresher(myPost);
        myPost.GetComponent<NewPost>().nameTag.text = GenerateUserName();
        myPost.GetComponent<NewPost>().NewsArticleTitle.text = newsarticle.Title;
        myPost.GetComponent<NewPost>().BodyArticle.text = newsarticle.Body;
        myPost.GetComponent<NewPost>().profilePic.sprite = GenerateProfilePic();
        myPost.GetComponent<NewPost>().Likes.text = Random.Range(priority * 10 + trendValue - trendValue / 2, priority * 10 + trendValue + 5).ToString();
        myPost.GetComponent<NewPost>().shares.text = Random.Range(priority * 10 + trendValue - ((trendValue * 2) / 3), 5 + priority * 10 + trendValue - trendValue / 3).ToString();
        myPost.GetComponent<NewPost>().comment1.text = GenerateRandomComment();
        myPost.GetComponent<NewPost>().comment2.text = GenerateRandomComment();

        PostRefresher(myPost);
        //LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
        //LayoutRebuilder.ForceRebuildLayoutImmediate(myPost.GetComponent<NewPost>().Twik.GetComponent<RectTransform>());
        //LayoutRebuilder.ForceRebuildLayoutImmediate(LayoutPanel);
        // myPost.SetActive(false);
        //  myPost.SetActive(true);
        //LeanTween.scale(myPost.GetComponent<NewPost>().Twik, new Vector2(1.001f, 1.001f), 0.001f);

        Debug.Log("it's working!");
    }


    public string GenerateUserName()
    {
        return "Sarah";
    }

    public Sprite GenerateProfilePic()
    {
        return Resources.Load<Sprite>("Pictures/ProfilePictures/defaultProfilePicture.jpg");
    }

    public string GenerateRandomComment()
    {
        int index = Random.Range(0, myCommentCollection.usercomments.Length-1);
        return myCommentCollection.usercomments[index].User + ": " + myCommentCollection.usercomments[index].Comment;
    }
}
