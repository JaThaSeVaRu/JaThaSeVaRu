using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public float speed = 1f;
    public float forwardSpeed;

    public float movementTimer;
    public float turnTime = 1f;

    void Start()
    {

        speed = 3;
        turnTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movementTimer += Time.deltaTime;


        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Translate(Vector3.left * forwardSpeed * Time.deltaTime);

        if (movementTimer >= turnTime)
        {
            speed = -speed;
            movementTimer = 0;
        }

    }
}
