using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCanvasUpdate : MonoBehaviour
{
    void Start()
    {
        Canvas.ForceUpdateCanvases();
    }
}
