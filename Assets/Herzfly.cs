using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herzfly : MonoBehaviour
{
    float destroyAfterSeconds =0.5f;
    public float Speed = 6f;
    public Rigidbody2D rb;
    void Start()
    {
        StartCoroutine(HerzDestroy());
        if (transform.position.x > 0)
        {
            rb.velocity = Vector3.right * Speed;
        }
        if (transform.position.x < 0)
        {
            rb.velocity = Vector3.left * Speed;
        }
    }

    private void Update()
    {
        rb.velocity -= rb.velocity * 2f * Time.deltaTime;
    }

    IEnumerator HerzDestroy()
    {

        yield return new WaitForSeconds(destroyAfterSeconds);

        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}