using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GlassAnimationController : MonoBehaviour
{
    public GameObject Outline;
    public GameObject Arrow;
    public GameObject Loginbutton;
    public int ORIGINALX;
    public GameObject[] GroupFadeIn;
    public Text Username;
    public Text Password; 
    string txt = "";
    public string targetText;
    string whitetext = "";
    // Tweener usernameshowup; 
    string txtPW = "";
    public string PasswordText;
    string whitePW = "";
    public GameObject ToC;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        ResetString();
        //LeanTween.alpha(this.GetComponent<RectTransform>(), 100, 0.3f).setEase(LeanTweenType.easeInCubic);
       // LeanTween.alpha(Outline.GetComponent<RectTransform>(), 100, 0.3f).setEase(LeanTweenType.easeInCubic);
        LeanTween.move(this.gameObject.GetComponent<RectTransform>(), new Vector2(0, 1f), 0.3f).setEase(LeanTweenType.easeInOutCubic);
        
        
        DOTween.To(
            () => txt,
            x => txt = x,
            targetText,
            0.3f).SetDelay(0.2f).OnUpdate(() => Username.text = txt);
        DOTween.To(
            () => txtPW,
            x => txtPW = x,
            PasswordText,
            0.3f).SetDelay(0.3f).OnUpdate(() => Password.text = txtPW);

        LeanTween.alpha(Arrow.GetComponent<RectTransform>(), 1, 0.2f).setDelay(0.5f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.alpha(Loginbutton.GetComponent<RectTransform>(), 1, 0.2f).setDelay(0.65f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.move(Arrow.GetComponent<RectTransform>(), new Vector2(250, -460), 0.2f).setDelay(0.5f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void FadeOut()
    {
        //LeanTween.alpha(this.GetComponent<RectTransform>(), 0, 0.3f).setEase(LeanTweenType.easeInCubic);
        //LeanTween.alpha(Outline.GetComponent<RectTransform>(), 0, 0.3f).setEase(LeanTweenType.easeInCubic);
        LeanTween.move(this.gameObject.GetComponent<RectTransform>(), new Vector2(ORIGINALX, 1f), 0.3f).setDelay(0.2f).setEase(LeanTweenType.easeInOutCubic);

        whitetext = targetText;
        whitePW = PasswordText;
        //DOTween.SmoothRewindAll();
        DOTween.To(
            () => whitetext,
            x => whitetext = x,
            "          ",
            0.3f).OnUpdate(() => Username.text = whitetext);
        DOTween.To(
            () => whitePW,
            x => whitePW = x,
            "          ",
            0.3f).OnUpdate(() => Password.text = whitePW);
        LeanTween.alpha(Arrow.GetComponent<RectTransform>(), 0, 0.2f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.alpha(Loginbutton.GetComponent<RectTransform>(), 0, 0.2f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.move(Arrow.GetComponent<RectTransform>(), new Vector2(411, -600), 0.2f).setEase(LeanTweenType.easeInOutCubic);



    }

    public void ResetString()
    {
        txt = "";
        whitetext = "";
        txtPW = "";
        whitePW = "";
    }

    public void ToCScroll(float Value)
    {
        
        Debug.Log(55000 * (Value / 100.0f));

        LeanTween.moveY(ToC, 55000 * (Value / 100.0f), 0.2f).setEase(LeanTweenType.easeInOutBounce);
    }
}
