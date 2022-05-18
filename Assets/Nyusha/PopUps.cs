using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{

    public GameObject[] articles; //list of pop ups
    int popUps; //how many pop ups are on screen
    float timer; //timer countdown

    // Start is called before the first frame update
    void Start()
    {
        popUps = 0; //zero pop ups on screen initially
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Time: " + timer);

        if ((Input.GetMouseButtonDown(0)) && (popUps < 4)) //if clicking and less than 4 pop ups
        {
            ClickToPopUp();
        }

        if (popUps >= 4) //if more than four pop ups
        {
            if (timer > 0) //if timer is greater than zero
            {
                timer = timer - Time.deltaTime; //decrease the timer amount
            }

            if (timer < 0) //if timer reaches zero
            {
                AutoPop();
                timer = 1f; //reset it back to 2 seconds
            }
        }
    }

    void ClickToPopUp() //the first stage, manual control over pop ups
    {
        //Pop Up appears
        Debug.Log("Popups =" + popUps);
        articles[popUps].SetActive(true);
        popUps++;
       // Animation();
    }
  
    void AutoPop()
    {
        articles[popUps].SetActive(true);
        popUps++;
        //Animation();
    }

    void Animation()
    {

    }
}
