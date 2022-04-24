using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAnimation : MonoBehaviour
{
   public GameObject box;
   public GameObject taskbar;
   public Color Nocolor;

   Color fullcolor;
   public GameObject chatbutton;
   public GameObject Newsbutton;
   public GameObject Socialbutton;
   

   


    public void taskanimation()
    {
        //LeanTween.move(box, new Vector3(-390f,-185f,0f), 0.2f) .setEaseInQuart();
       //LeanTween.move(taskbar, new Vector3(-299.99f,-184.9798f, 10f), 0.2f) .setEaseInQuart();
        box.LeanScaleY(30,0.3f).setEaseInOutQuart();
        box.LeanScaleX(30,0.3f).setEaseInBack();
       // MixerText.alpha = 1;
       // MixerText.LeanAlpha(0,1.5f).setEaseInExpo();
       // Logos.alpha = 0;
       // Logos.LeanAlpha(1,1.5f).setEaseInExpo();
       // box.GetComponent<SpriteRenderer>().color = fullcolor;
       // LeanTween.value(box, fullcolor, Nocolor, 5f ).setEaseInBack();
       //LeanTween.value(taskbar, Nocolor, fullcolor, 5f ).setEaseInBack();
        LeanTween.alpha(box, 0, 0.3f).setDelay(0.2f);
        LeanTween.alpha(taskbar, 1, 0.2f).setDelay(0.3f);
        //turning on the boxes
        Socialbutton.SetActive(true);
        Newsbutton.SetActive(true);
        chatbutton.SetActive(true);




    }
    public void taskdenimation()
    {
        box.LeanScaleY(13,0.3f).setDelay(0.3f).setEaseInOutQuart();
        box.LeanScaleX(5,0.3f).setEaseInBack();
        LeanTween.alpha(box, 1, 0.3f);
        LeanTween.alpha(taskbar, 0, 0.3f);
        Socialbutton.SetActive(false);
        Newsbutton.SetActive(false);
        chatbutton.SetActive(false);




    }
    

}
