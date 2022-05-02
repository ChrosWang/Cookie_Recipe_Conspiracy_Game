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
    public CommentCollection myKeyCommentCollection = new CommentCollection();
    public TextAsset SpreadSheetJSON1;
    public TextAsset SpreadSheetJSON2;



    // Start is called before the first frame update
    void Start()
    {

        
       // Debug.Log(myCommentCollection.usercomments[0].Comment);

    }

    public void Initialization()
    {
        myCommentCollection = JsonUtility.FromJson<CommentCollection>("{\"usercomments\":" + SpreadSheetJSON1.text + "}");
        myKeyCommentCollection = JsonUtility.FromJson<CommentCollection>("{\"usercomments\":" + SpreadSheetJSON2.text + "}");

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

    public void RefreshList(GameObject myPost)
    {
        Canvas.ForceUpdateCanvases();
        VerticalLayoutGroup vg;
        HorizontalLayoutGroup hg;
        for (int i = 0; i< myPost.GetComponent<NewPost>().LayoutGroups.Length; i++)
        {
            Canvas.ForceUpdateCanvases();
            hg = myPost.GetComponent<NewPost>().LayoutGroups[i].GetComponent<HorizontalLayoutGroup>();
            if (hg != null)
            {
                hg.enabled = false;
                hg.enabled = true;
            }
            Canvas.ForceUpdateCanvases();
            vg = myPost.GetComponent<NewPost>().LayoutGroups[i].GetComponent<VerticalLayoutGroup>();
            if (vg != null)
            {
                vg.enabled = false;
                vg.enabled = true;
            }
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
        myKeyCommentCollection.SearchForKeyWord(newsarticle.ReferenceNr);
        myPost.GetComponent<NewPost>().comment1.text = "<color=#FF5555>" + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[0]].User+ ":</color>   " + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[0]].Comment;
        myPost.GetComponent<NewPost>().comment2.text = "<color=#FF5555>" + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[1]].User + ":</color>   " + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[1]].Comment;

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

    public string GenerateRandomComment(int rn)
    {
        int index = Random.Range(0, myCommentCollection.usercomments.Length-1);
        return "<color=#FF5555>" + myCommentCollection.usercomments[index].User + ":</color>   " + myCommentCollection.usercomments[index].Comment;
    }
}
