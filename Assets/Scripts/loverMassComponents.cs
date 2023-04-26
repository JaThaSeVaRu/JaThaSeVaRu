using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loverMassComponents : MonoBehaviour
{

    public float upDownSpeed;

    public float upDownTimer;
    public float upDownTime;


    void Start()
    {
        
    }


    void Update()
    {
        upDownTime += Time.deltaTime;

        transform.Translate(Vector3.up * upDownSpeed * Time.deltaTime);

        if (upDownTime >= upDownTimer)
        {
            upDownSpeed = -upDownSpeed;
            upDownTime = 0;
        }

    }
}
