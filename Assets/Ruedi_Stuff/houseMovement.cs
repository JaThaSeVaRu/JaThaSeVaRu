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
        /*
        //check for own Y-Axis position to determine speed
        if (transform.position.y == background.staticBackHouseHeight)
        {
            //if Y-Position matches with back row: speed is one
            speed = 1;
        }
        if (transform.position.y == background.staticMidHouseHeight)
        {
            //if Y-Position matches with middle row: speed is three
            speed = 3;
        }
        if (transform.position.y == background.staticFrontHouseHeight)
        {
            //if Y-Position matches with front row: speed is five
            speed = 5;
        }
*///
        //move to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);


        //disappear when out of bounds
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
