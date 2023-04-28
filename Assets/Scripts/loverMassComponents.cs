using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loverMassComponents : MonoBehaviour
{
    //variables to set speed and the rate of direction change
    public float upDownSpeed;

    public float upDownTimer;
    public float upDownTime;


    void Start()
    {
        
    }


    void Update()
    {
        //start timer
        upDownTime += Time.deltaTime;

        //move in a certain direction
        transform.Translate(Vector3.up * upDownSpeed * Time.deltaTime);

        //when timer hits maximum switch the speed to negative to move in opposite direction
        if (upDownTime >= upDownTimer)
        {
            upDownSpeed = -upDownSpeed;
            upDownTime = 0;
        }

    }
}
