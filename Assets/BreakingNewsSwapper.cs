using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakingNewsSwapper : MonoBehaviour
{
    public Sprite[] GS_List;
    public void Swap(int index)
    {
        LeanTween.alpha(this.gameObject, 0, 0.3f);
        this.gameObject.GetComponent<Image>().sprite = GS_List[index];
        LeanTween.alpha(this.gameObject, 0, 0.3f).setDelay(0.3f);
    }
}
