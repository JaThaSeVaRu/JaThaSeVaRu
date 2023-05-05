using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kont_walk : MonoBehaviour
{
    public float playerSpeed;

    private Rigidbody2D rb;
    private Vector2 playerDirection;

    int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = new Vector2(-Random.Range(1,playerSpeed),0);
        transform.Translate(playerDirection * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            playerSpeed = -playerSpeed;
            direction = -direction;
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
    }
}
