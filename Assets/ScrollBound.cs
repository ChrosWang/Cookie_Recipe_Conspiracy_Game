using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBound : MonoBehaviour
{

    public float upperbound;
    public float lowerbound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.y > upperbound)
        {
            LeanTween.moveLocalY(this.gameObject, upperbound, 0);
        }
        if (this.transform.localPosition.y < lowerbound)
        {
            LeanTween.moveLocalY(this.gameObject, lowerbound, 0);
        }
    }
}
