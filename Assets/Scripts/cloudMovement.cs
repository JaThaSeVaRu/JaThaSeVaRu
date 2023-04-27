using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMovement : MonoBehaviour
{
    public float speed = 0;

    void Start()
    {
        //Set random speed (from veeeeeery slow to slow)
        speed = Random.Range(0.001f, 0.1f);
    }

    void Update()
    {
        //move left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //disappear when out of bounds
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
