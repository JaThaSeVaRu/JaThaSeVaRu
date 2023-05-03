using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herzfly : MonoBehaviour
{
    float destroyAfterSeconds =2f;
    float Speed = 8f;
    public Rigidbody2D rb;
    void Update()
    {
        StartCoroutine(HerzDestroy());
    }

    IEnumerator HerzDestroy()
    {
        if (transform.position.x > 0)
        {
            rb.AddForce(Vector3.right * Speed * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (transform.position.x < 0)
        {
            rb.AddForce(Vector3.left * Speed * Time.deltaTime, ForceMode2D.Impulse);
        }

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