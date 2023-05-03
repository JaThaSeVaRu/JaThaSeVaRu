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
        if (GameManager.Instance.world.CurrentTime == WorldData.TimeOfDay.day ||
            GameManager.Instance.world.CurrentTime == WorldData.TimeOfDay.sunrise)
        {
            day = true;
        }

        if (GameManager.Instance.world.CurrentTime == WorldData.TimeOfDay.night ||
            GameManager.Instance.world.CurrentTime == WorldData.TimeOfDay.sunset)
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
            if (daySprites[spriteChoice])
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = daySprites[spriteChoice];
            }
        }
        if (night == true)
        {
            day = false;
            listlength = nightSprites.Length;
            spriteChoice = Random.Range(0, listlength);
            if (nightSprites[spriteChoice])
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = nightSprites[spriteChoice];
            }
        }



    }

    void Update()
    {
        //set movement speed equal to train speed
        

        //move left along with train
        transform.Translate(Vector3.left * GameManager.Instance.player.Velocity * Time.deltaTime);

        //disappear when out of bounds
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
