using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train : MonoBehaviour
{
    public float speed = 8f;
    public static float staticSpeed;
    public Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        staticSpeed = speed;

        if (transform.position.x <= -27.84)
        {
            transform.position = startPosition;
        }
    }
}
