using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        speed = train.staticSpeed;


        transform.Translate(Vector3.left * speed * Time.deltaTime);


        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
