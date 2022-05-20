using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebriefButton : MonoBehaviour
{
    public GameObject[] slides;
    int slideCount;

    // Start is called before the first frame update
    void Start()
    {
        slideCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextSlide()
    {
        slides[slideCount].SetActive(false);
        slideCount++;

    }
}
