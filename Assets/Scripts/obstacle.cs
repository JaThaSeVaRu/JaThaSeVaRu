using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float speed;


    public Sprite[] sprites;

    public int listlength;

    public int spriteChoice;

    void Start()
    {
        listlength = sprites.Length;

        spriteChoice = Random.Range(0, listlength);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];

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
