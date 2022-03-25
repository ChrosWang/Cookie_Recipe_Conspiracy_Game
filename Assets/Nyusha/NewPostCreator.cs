using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPostCreator : MonoBehaviour
{
    public GameObject newsArticle;
    public Transform FacebookCanvas; 

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
       // int i = 0;
        GameObject newPost = Instantiate(newsArticle); //make an article
        newPost.transform.SetParent(FacebookCanvas); 
       // Vector3 newPos = new Vector3( //make a new position
         //   gameObject.transform.position.x + (i * 3),
           // gameObject.transform.position.y,
            //0);
        //newPost.transform.position = newPos; //set the card's position
                                            
        Debug.Log("it's working!");
    }

    //

}
