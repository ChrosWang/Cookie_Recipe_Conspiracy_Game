using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserComments
{
    public string Post;
    public string Comment;
    public string User;
    public string Order;
}

[System.Serializable]
public class CommentCollection
{
   
        public UserComments[] usercomments; 

}
