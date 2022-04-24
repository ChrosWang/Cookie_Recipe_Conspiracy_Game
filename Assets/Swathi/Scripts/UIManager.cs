using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
public Animator transition;
    public GameObject chatCanvas;
    public GameObject Article;
     public CanvasGroup Title;
    public CanvasGroup Bodytext;

    public CanvasGroup Image;
    public GameObject Articles;
    public GameObject SearchMover; 



public void ArticlePageLoader()
    {
       Debug.Log("ArticleAnim");
       Article.LeanMove(new Vector2(8,-2),1).setEaseInOutQuart();
       Title.alpha = 0;
       Title.LeanAlpha(1,1.5f).setEaseInExpo();
       Bodytext.alpha = 0;
       Bodytext.LeanAlpha(1,2f).setEaseInBounce();
      Image.alpha = 0;
       Image.LeanAlpha(1,2f).setEaseInElastic();
       
}
public void SearchMove(){

Articles.SetActive(true);
 SearchMover.LeanMove(new Vector2(8,-2),1).setEaseInOutQuart();


}
    
    // void Update()
    // {
    //     if(chatCanvas)
    //     {
    //         if(Input.GetMouseButtonDown(0)){
    //     //transition.SetTrigger("Chat Exit_Trigger");
    //     Debug.Log("it leave baby");
    // }}}
    
}
