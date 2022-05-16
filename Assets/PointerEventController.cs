using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PointerEventController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject logInAnimation;
    public GameObject Glass;
    int HEIGHT_OF_SELCTOR = 78;
    public int MenuLevel;
    public UIControlTitle uicontrol;
    //public Camera MainCamera;
    public GameObject Circle1;
    public GameObject Circle2;
    public int movepatternCircle;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene(1);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (uicontrol.CurrentMenu != MenuLevel)
        {
            Debug.Log(uicontrol.CurrentMenu + " "+ MenuLevel);
            return;
        }
        switch (movepatternCircle)
        {
            case 1:
                LeanTween.scale(Circle1, new Vector2(0.72f, 0.71f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.scale(Circle2, new Vector2(0.7f, 0.67f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.move(Circle1, new Vector2(-1.3f, -1.5f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.move(Circle2, new Vector2(5.54f, 1.2f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                break;

            case 2:
                LeanTween.scale(Circle1, new Vector2(0.8778f, 0.8778f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.scale(Circle2, new Vector2(0.8906f, 0.8906f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.move(Circle1, new Vector2(-5.99f, 1.37f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.move(Circle2, new Vector2(1.63f, -1.22f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                break;

            case 3:
                LeanTween.scale(Circle1, new Vector2(0.97f, 0.97f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.scale(Circle2, new Vector2(0.84f, 0.84f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.move(Circle1, new Vector2(-1.25f, -7.59f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.move(Circle2, new Vector2(2.8f, -0.63f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                break;

            case 4:
                LeanTween.scale(Circle1, new Vector2(0.72f, 0.71f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.scale(Circle2, new Vector2(0.7f, 0.67f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.move(Circle1, new Vector2(-1.3f, -0.09f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                LeanTween.move(Circle2, new Vector2(5.54f, 1.2f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
                break;
            default:
                break;


        }
            
        if (!this.GetComponent<AudioSource>().isPlaying)
            this.GetComponent<AudioSource>().Play();
        LeanTween.size(logInAnimation.GetComponent<RectTransform>(), new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, HEIGHT_OF_SELCTOR), 0.1f).setEase(LeanTweenType.easeInOutCubic);
        if (uicontrol.CurrentMenu == 0)
        {
           
            Glass.GetComponent<GlassAnimationController>().FadeIn();
        }
        //LeanTween.alpha(this.GetComponent<RectTransform>(), 0, 0.3f).setEase(LeanTweenType.easeInOutQuad);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (uicontrol.CurrentMenu != MenuLevel)
            return;
        Debug.Log("Left");
        if (uicontrol.CurrentMenu == 0)
        {
            LeanTween.scale(Circle1, new Vector2(0.5f, 0.5f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
            LeanTween.scale(Circle2, new Vector2(0.5f, 0.5f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
            LeanTween.move(Circle1, new Vector2(1.52f, -1.18f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
            LeanTween.move(Circle2, new Vector2(4.19f, 1.33f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
            
            Glass.GetComponent<GlassAnimationController>().FadeOut();
        }
        LeanTween.size(logInAnimation.GetComponent<RectTransform>(), new Vector2(0, HEIGHT_OF_SELCTOR), 0.1f).setDelay(0.3f).setEase(LeanTweenType.easeInOutCubic);
        //LeanTween.alpha(this.GetComponent<RectTransform>(), 100, 0.3f).setDelay(0.2f).setEase(LeanTweenType.easeInOutQuad);
    }

    public void OnExitAnyway()
    {
        Debug.Log("OnExitAnyway");
        LeanTween.scale(Circle1, new Vector2(0.5f, 0.5f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scale(Circle2, new Vector2(0.5f, 0.5f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.move(Circle1, new Vector2(1.52f, -1.18f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.move(Circle2, new Vector2(4.19f, 1.33f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.size(logInAnimation.GetComponent<RectTransform>(), new Vector2(0, HEIGHT_OF_SELCTOR), 0.1f).setDelay(0.3f).setEase(LeanTweenType.easeInOutCubic);
        //Glass.GetComponent<GlassAnimationController>().FadeOut();
        //LeanTween.alpha(this.GetComponent<RectTransform>(), 100, 0.3f).setDelay(0.2f).setEase(LeanTweenType.easeInOutQuad);
    }


}
