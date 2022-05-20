using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(this.gameObject, new Vector2(0.8f, 0.8f), 1f).setLoopPingPong().setEaseInOutCubic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
