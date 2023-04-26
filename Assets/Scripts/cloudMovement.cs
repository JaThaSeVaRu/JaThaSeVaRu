using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMovement : MonoBehaviour
{
    public float speed = 0;

    void Start()
    {
        speed = Random.Range(0.001f, 0.1f);
    }

    void Update()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
