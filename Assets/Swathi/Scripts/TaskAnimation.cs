using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAnimation : MonoBehaviour
{
   public GameObject box;
   public GameObject taskbar;
   public Color Nocolor;
   public Color fullcolor; 
   


    public void taskanimation()
    {
        box.LeanScaleY(30,1f).setEaseInOutQuart();
        box.LeanScaleX(30,2f).setEaseInBack();
       // MixerText.alpha = 1;
       // MixerText.LeanAlpha(0,1.5f).setEaseInExpo();
       // Logos.alpha = 0;
       // Logos.LeanAlpha(1,1.5f).setEaseInExpo();
       LeanTween.value(box, fullcolor, Nocolor, 5f ).setEasePunch();
       LeanTween.value(taskbar, Nocolor, fullcolor, 5f ).setEasePunch();



    }
    

}
