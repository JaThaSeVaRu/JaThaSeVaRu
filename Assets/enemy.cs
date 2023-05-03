using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;

    public bool fromLeft;
    public bool fromRight;
    public bool knockedOut;

    public Vector3 knockBackVector;

    void Start()
    {
        if (transform.position.x < 0)
        {
            fromLeft = true;
            speed = -speed;
            knockBackVector = new Vector3(Random.Range(1f, 5f), Random.Range(-1f, -5f), 0);
        }
        if (transform.position.x > 0)
        {
            fromRight = true; 
            knockBackVector = new Vector3(Random.Range(1f, 5f), Random.Range(1f, 5f), 0);
        }

    }

    void Update()
    {
        if (knockedOut == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        KnockBack();

        if (transform.position.x >= 10 || transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

    public void KnockBack()
    {
        if (Input.GetKey("up"))
        {
            knockedOut = true;
        }

        if (knockedOut == true)
        {
            transform.Translate(knockBackVector * speed * Time.deltaTime);
        }
    }
}
