using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;

    public bool fromLeft;
    public bool fromRight;
    public bool yeeted;

    public Vector3 yeetVector;
    public Vector3 rotation;

    void Start()
    {
        speed = Random.Range(1f, 7f);

        if (transform.position.x < 0)
        {
            fromLeft = true;
            speed = -speed;
            yeetVector = new Vector3(Random.Range(5f, 30f), Random.Range(-5f, -30f), 0);
        }
        if (transform.position.x > 0)
        {
            fromRight = true; 
            yeetVector = new Vector3(Random.Range(5f, 30f), Random.Range(5f, 30f), 0);
        }
        rotation = new Vector3(0, 0, Random.Range(200f, 1000f));

    }

    void Update()
    {
        if (yeeted == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        Yeet();

        if (transform.position.x >= 15 || transform.position.x <= -15 || transform.position.y >= 15)
        {
            Destroy(gameObject);
        }
    }

    public void Yeet()
    {
        if (Input.GetKey("up"))
        {
            yeeted = true;
        }

        if (yeeted == true)
        {
            transform.Translate(yeetVector * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pose"))
        {
            if (yeeted == false)
            {
                yeeted = true;
                Yeet();
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("got heart back");
            speed = -speed;
        }
    }
}
