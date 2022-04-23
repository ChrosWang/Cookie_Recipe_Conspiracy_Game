using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIControlTitle : MonoBehaviour
{
    [SerializeField] GameObject VerticleScroll, HorizontalScroll, AudioSlider, VolumeSlider, optionGlass, BackButton, StartButton, ContinueButton, OptionButton, QuitButton, PurpleShape, PurpleCircle, MaskOptionMenu;
    public int CurrentMenu; 
    // Start is called before the first frame update
    void Start()
    {
        OptionButton.GetComponent<Button>().onClick.AddListener(() => OptionMenu());
        BackButton.GetComponent<Button>().onClick.AddListener(() => BacktoMain());
        //VolumeSlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { TOCInvoke(); });
    }

    private void Update()
    {
        VerticleScroll.GetComponent<Scrollbar>().value = VolumeSlider.GetComponent<Slider>().value;
        HorizontalScroll.GetComponent<Scrollbar>().value = 1 - AudioSlider.GetComponent<Slider>().value;
    }

    public void OptionMenu ()
    {
        if (CurrentMenu == 1)
            return;
        Debug.Log("Here optionmenu");
        CurrentMenu = 1;
        this.GetComponent<AudioSource>().Play();
        LeanTween.size(MaskOptionMenu.GetComponent<RectTransform>(), new Vector2(306, 460), 0.1f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void BacktoMain()
    {
        CurrentMenu = 0;
        this.GetComponent<AudioSource>().Play();
        LeanTween.size(MaskOptionMenu.GetComponent<RectTransform>(), new Vector2(0, 460), 0.1f).setEase(LeanTweenType.easeInOutCubic);
        Debug.Log("OnExitAnyway Main");
        optionGlass.GetComponent<GlassAnimationController>().FadeOut();
        Debug.Log("OnExitAnyway Main");
        OptionButton.GetComponent<PointerEventController>().OnExitAnyway();
        BackButton.GetComponent<PointerEventController>().OnExitAnyway();
    }
}
