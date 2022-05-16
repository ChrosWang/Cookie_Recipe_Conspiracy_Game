using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DateSwapper : MonoBehaviour
{
    public TMP_Text Date;
    public string[] Dates;

    public void DateSwap(int index)
    {
        Date.text = Dates[index];
    }
}
