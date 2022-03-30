using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleHover : MonoBehaviour
 
 {
     private bool mouse_over = false;
     void Update()
     {
         if (mouse_over)
         {
             Debug.Log("Mouse Over");
         }
     }
 
     public void OnPointerEnter()
     {
         mouse_over = true;
         Debug.Log("Mouse enter");
     }
 
     public void OnPointerExit()
     {
         mouse_over = false;
         Debug.Log("Mouse exit");
     }
 }
