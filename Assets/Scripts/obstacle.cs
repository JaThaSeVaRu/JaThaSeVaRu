using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{

    public float speed;

    //list of available sprites
    public Sprite[] daySprites;
    public Sprite[] nightSprites;

    //lamount of available sprites
    public int listlength;

    //randomized value to choose from the available sprites
    public int spriteChoice;

    //placeholder variables to choose between day and night state
    public int daytime;
    public bool day;
    public bool night;

    void Start()
    {
        //randomly set daytime (placeholder script)
        daytime = Random.Range(1, 3);

        if (daytime == 1)
        {
            day = true;
        }
        if (daytime == 2)
        {
            night = true;
        }

        //get listlength
        if (day == true)
        {
            night = false;
            listlength = daySprites.Length;
            //choose a sprite once obstacle got spawned 
            spriteChoice = Random.Range(0, listlength);
            //use the chosen Sprite
            this.gameObject.GetComponent<SpriteRenderer>().sprite = daySprites[spriteChoice];
        }
        if (night == true)
        {
            day = false;
            listlength = nightSprites.Length;
            spriteChoice = Random.Range(0, listlength);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nightSprites[spriteChoice];
        }



    }

    void Update()
    {
        //set movement speed equal to train speed
        speed = train.speed;

        //move left along with train
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //disappear when out of bounds
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
