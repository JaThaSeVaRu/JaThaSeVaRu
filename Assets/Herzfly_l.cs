using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herzfly_l : MonoBehaviour
{
    float destroyAfterSeconds = 2f;
    float Speed = 8f;
    public Rigidbody2D rb;
    void Update()
    {
        StartCoroutine(HerzDestroy());
    }

    IEnumerator HerzDestroy()
    {
        rb.AddForce(Vector3.left * Speed * Time.deltaTime, ForceMode2D.Impulse);
        yield return new WaitForSeconds(destroyAfterSeconds);

        if (this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
    }
}
