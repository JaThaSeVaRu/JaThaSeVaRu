using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObstacle : MonoBehaviour
{
    public float speed = 1f;

    public float movementTimer;
    public float turnTime = 1f;

    void Start()
    {
        speed = 3;
        turnTime = 1;
    }

    void Update()
    {
        movementTimer += Time.deltaTime;


        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (movementTimer >= turnTime)
        {
            speed = -speed;
            movementTimer = 0;
        }
    }
}
