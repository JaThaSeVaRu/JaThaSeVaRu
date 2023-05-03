using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kont_walk : MonoBehaviour
{
    public float playerSpeed;

    private Rigidbody2D rb;
    private Vector2 playerDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = new Vector2(-12,0);
        transform.Translate(playerDirection * Time.deltaTime);
    }

    
}
