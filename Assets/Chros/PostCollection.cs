using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MixPost
{
    public string Title;
    public string Body;
    public string Username;
    public string Comment1;
    public string Username1;
    public string Comment2;
    public string Username2;
    public string PictureName;
    public int likes;
    public int shares;
    public int comments;

}
[System.Serializable]
public class PostCollection
{
    public MixPost[] mixpost;
}



