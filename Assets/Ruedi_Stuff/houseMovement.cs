using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseMovement : MonoBehaviour
{
    public float speed = 0;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);


        if (transform.position.y == -5)
        {
            speed = 1;
        }
        if (transform.position.y == -6)
        {
            speed = 3;
        }
        if (transform.position.y == -7.5f)
        {
            speed = 5;
        }

        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
