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
    public TextAsset SpreadSheetJSON;
    public PostCollection myPostCollection = new PostCollection();
    public CommentCollection myCommentCollection = new CommentCollection();
    public CommentCollection myKeyCommentCollection = new CommentCollection();
    public TextAsset SpreadSheetJSON1;
    public TextAsset SpreadSheetJSON2;

    public PopUpSystem popupsystem;


    public GameObject Scroller;
    // Start is called before the first frame update
    void Start()
    {


        // Debug.Log(myCommentCollection.usercomments[0].Comment);

    }

    public void Initialization()
    {
        myPostCollection = JsonUtility.FromJson<PostCollection>("{\"mixpost\":" + SpreadSheetJSON.text + "}");
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
    void UpdateScroller()
    {
        Scroller.GetComponent<ScrollRect>().horizontalNormalizedPosition = 1f;
        Scroller.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
    }

    public void RefreshList(GameObject myPost)
    {
        UpdateScroller();
        Canvas.ForceUpdateCanvases();
        VerticalLayoutGroup vg;
        HorizontalLayoutGroup hg;
        for (int i = 0; i < myPost.GetComponent<NewPost>().LayoutGroups.Length; i++)
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
    //Make Non Sarah Post
    public void MakeNSPost(int index)
    {
        //int trendValue = newsarticle.Score;
        // int priority = newsarticle.Priority;
        Debug.Log("Making post" + index);
        GameObject myPost = Instantiate(newPost, VerticalLayoutGroup);
        myPost.transform.SetAsFirstSibling();
        PostRefresher(myPost);
        //PostRefresher(myPost);
        myPost.GetComponent<NewPost>().nameTag.text = myPostCollection.mixpost[index].Username;
        if (myPostCollection.mixpost[index].Username.Equals("WendyDW"))
        {
            myPost.GetComponent<NewPost>().Wendy.SetActive(true);
        }
        if (myPostCollection.mixpost[index].Username.Equals("MrSupreme88"))
        {
            myPost.GetComponent<NewPost>().Chris.SetActive(true);
        }
        myPost.GetComponent<NewPost>().NewsArticleTitle.text = myPostCollection.mixpost[index].Title;
        myPost.GetComponent<NewPost>().BodyArticle.text = myPostCollection.mixpost[index].Body;
        myPost.GetComponent<NewPost>().profilePic.GetComponent<ProfileGenerator>().RandomRoll();
        myPost.GetComponent<NewPost>().ArticlePic.sprite = Resources.Load<Sprite>("Pictures/GSIIArticlePics/" + myPostCollection.mixpost[index].PictureName);
        if (Resources.Load<Sprite>("Pictures/GSIIArticlePics/" + myPostCollection.mixpost[index].PictureName) != null)
        {
            myPost.GetComponent<NewPost>().ArticlePic.rectTransform.sizeDelta = Resources.Load<Sprite>("Pictures/GSIIArticlePics/" + myPostCollection.mixpost[index].PictureName).rect.size * 0.7f;
        }
        myPost.GetComponent<NewPost>().Likes.text = myPostCollection.mixpost[index].likes.ToString();
        myPost.GetComponent<NewPost>().shares.text = myPostCollection.mixpost[index].shares.ToString();
        myPost.GetComponent<NewPost>().comments.text = myPostCollection.mixpost[index].comments.ToString();
        //myKeyCommentCollection.SearchForKeyWord(newsarticle.ReferenceNr);
        string comment1 = myPostCollection.mixpost[index].Comment1;
        string comment2 = myPostCollection.mixpost[index].Comment2;
        if (comment1.Equals(""))
        {
            myPost.GetComponent<NewPost>().cms1.SetActive(false);

        }
        if (comment2.Equals(""))
        {
            myPost.GetComponent<NewPost>().cms2.SetActive(false);

        }
        myPost.GetComponent<NewPost>().comment1.text = "<color=#FF5555>" + myPostCollection.mixpost[index].Username1 + ":</color>   " + comment1;
        myPost.GetComponent<NewPost>().comment2.text = "<color=#FF5555>" + myPostCollection.mixpost[index].Username2 + ":</color>   " + comment2;
        PostRefresher(myPost);
        //LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
        //LayoutRebuilder.ForceRebuildLayoutImmediate(myPost.GetComponent<NewPost>().Twik.GetComponent<RectTransform>());
        //LayoutRebuilder.ForceRebuildLayoutImmediate(LayoutPanel);
        // myPost.SetActive(false);
        //  myPost.SetActive(true);
        //LeanTween.scale(myPost.GetComponent<NewPost>().Twik, new Vector2(1.001f, 1.001f), 0.001f);
        /*
        Debug.Log("it's working!");
        if (!comment1.Equals(""))
        {
            popupsystem.DelayPopUp(1, new PopUpMessage("<color=#FF5555>" + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[0]].User + ":</color>", myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[0]].Comment, 0, 0), 3f);

        }
        if (!comment2.Equals(""))
        {
            popupsystem.DelayPopUp(1, new PopUpMessage("<color=#FF5555>" + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[1]].User + ":</color>", myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[1]].Comment, 0, 0), 5f);

        }
        */
        popupsystem.DelayPopUp(8, new PopUpMessage("<color=#FF5555>" + myPostCollection.mixpost[index].Username + ":</color>", myPostCollection.mixpost[index].Body, 0, 0), 3f);
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
        myPost.GetComponent<NewPost>().ArticlePic.sprite = Resources.Load<Sprite>("Pictures/GSIIArticlePics/" + newsarticle.ReferenceNr);
        if (Resources.Load<Sprite>("Pictures/GSIIArticlePics/" + newsarticle.ReferenceNr) != null)
        {
            myPost.GetComponent<NewPost>().ArticlePic.rectTransform.sizeDelta = Resources.Load<Sprite>("Pictures/GSIIArticlePics/" + newsarticle.ReferenceNr).rect.size * 0.7f;
        }
        myPost.GetComponent<NewPost>().Likes.text = Random.Range(priority * 10 + trendValue - trendValue / 2, priority * 10 + trendValue + 5).ToString();
        myPost.GetComponent<NewPost>().shares.text = Random.Range(priority * 10 + trendValue - ((trendValue * 2) / 3), 5 + priority * 10 + trendValue - trendValue / 3).ToString();
        myKeyCommentCollection.SearchForKeyWord(newsarticle.ReferenceNr);
        string comment1 = myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[0]].Comment;
        string comment2 = myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[1]].Comment;
        if (comment1.Equals(""))
        {
            myPost.GetComponent<NewPost>().cms1.SetActive(false);

        }
        if (comment2.Equals(""))
        {
            myPost.GetComponent<NewPost>().cms2.SetActive(false);

        }
        myPost.GetComponent<NewPost>().comment1.text = "<color=#FF5555>" + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[0]].User + ":</color>   " + comment1;
        myPost.GetComponent<NewPost>().comment2.text = "<color=#FF5555>" + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[1]].User + ":</color>   " + comment2;
        PostRefresher(myPost);
        //LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
        //LayoutRebuilder.ForceRebuildLayoutImmediate(myPost.GetComponent<NewPost>().Twik.GetComponent<RectTransform>());
        //LayoutRebuilder.ForceRebuildLayoutImmediate(LayoutPanel);
        // myPost.SetActive(false);
        //  myPost.SetActive(true);
        //LeanTween.scale(myPost.GetComponent<NewPost>().Twik, new Vector2(1.001f, 1.001f), 0.001f);

        if (newsarticle.ReferenceNr == 1 || newsarticle.ReferenceNr == 2)
        {
            return;
        }
        Debug.Log("it's working!");
        if (!comment1.Equals(""))
        {
            
            popupsystem.DelayPopUp(1, new PopUpMessage("<color=#FF5555>" + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[0]].User + ":</color>", myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[0]].Comment, 0, 0), 10f);

        }
        if (!comment2.Equals(""))
        {
            popupsystem.DelayPopUp(1, new PopUpMessage("<color=#FF5555>" + myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[1]].User + ":</color>", myKeyCommentCollection.usercomments[myKeyCommentCollection.SearchList[1]].Comment, 0, 0), 20f);

        }
        
        
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
