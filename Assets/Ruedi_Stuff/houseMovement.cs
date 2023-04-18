using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseMovement : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -13)
        {
            if (speed == 5)
            {
                background.firstSpawnState = 1;
                Destroy(gameObject);
            }
            if (speed == 3)
            {
                background.secondSpawnState = 1;
                Destroy(gameObject);
            }
            if (speed == 1)
            {
                background.thirdSpawnState = 1;
                Destroy(gameObject);
            }

        }
    }
}
