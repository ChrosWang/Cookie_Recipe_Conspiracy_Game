using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebriefButton : MonoBehaviour
{
    public GameObject[] slides;
    int slideCount;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        slideCount = 0;
        LeanTween.alpha(arrow.GetComponent<RectTransform>(),0f,0f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (slideCount == 1)
        {
            // public TMP_Text Tmp1;
            // [TextArea(10, 100)] 
            // public string String1;
            // public TMP_Text Tmp2;
            // [TextArea(10, 100)] 
            // public string String2;
            // public TMP_Text Tmp3;
            // [TextArea(10, 100)] 
            // public string String3;
        }
    }

    public void NextSlide()
    {
        Debug.Log("button clicked");
        slides[slideCount].SetActive(false);
        slideCount++;
    }
}
