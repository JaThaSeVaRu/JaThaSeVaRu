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


        if (transform.position.y == background.staticBackHouseHeight)
        {
            speed = 1;
        }
        if (transform.position.y == background.staticMidHouseHeight)
        {
            speed = 3;
        }
        if (transform.position.y == background.staticFrontHouseHeight)
        {
            speed = 5;
        }

        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
