using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource[] AudioList;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < AudioList.Length; i++)
        {
            AudioList[i].volume = this.GetComponent<Slider>().value;
        }
    }
}
