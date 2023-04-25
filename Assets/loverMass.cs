using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loverMass : MonoBehaviour
{
    public float speed;
    public float upDownSpeed;

    public float upDownTimer;
    public float upDownTime;


    public GameObject character;


    void Start()
    {
        
    }

    void Update()
    {
        upDownTime += Time.deltaTime;

        if (transform.position.x >= -3.5f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        transform.Translate(Vector3.up * upDownSpeed * Time.deltaTime);

        if (upDownTime >= upDownTimer)
        {
            upDownSpeed = -upDownSpeed;
            upDownTime = 0;
        }
    }
}
