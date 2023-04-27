    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCharacter : MonoBehaviour
{
    Vector2 startPos;
    Vector2 endPos;
    float tapDistance = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    endPos = touch.position;
                    if (Vector2.Distance(startPos, endPos) < tapDistance)
                    {
                        //Tap
                        if(touch.position.x < Screen.width/2f)
                        {
                            Debug.Log("Test");
                        }
                    }
                    else
                    {
                        //Swipe

                    }
                    break;

                //Report that touch was held
                case TouchPhase.Stationary:

                    break;
            }
        }
    }
}
