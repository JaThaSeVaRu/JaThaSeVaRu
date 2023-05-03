    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCharacter : MonoBehaviour
{
    Vector2 startPos;
    Vector2 endPos;
    float tapDistance = 100;
    public List<Sprite> spriteList = new List<Sprite>();
    int direction = 0;
    SpriteRenderer sprite;
    int lastSprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    endPos = touch.position;
                    if (Vector2.Distance(startPos, endPos) < tapDistance)
                    {
                        //Tap
                        if(touch.position.x < Screen.width/2f)
                        {
                            //Attack Left
                            direction = -1;
                            sprite.sprite = newSprite();
                        }
                        else
                        {
                            //Attack Right
                            direction = 1;
                            sprite.sprite = newSprite();
                        }
                        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
                    }
                    else
                    {
                        //Swipe

                    }

                    break;

                //Report that touch was held
                case TouchPhase.Stationary:

                    break;
            }
        }

        if (Input.GetKey("left"))
        {
            //Attack Left
            direction = -1;
            sprite.sprite = newSprite();
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetKey("right"))
        {
            //Attack Right
            direction = 1;
            sprite.sprite = newSprite();
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
    }

    Sprite newSprite()
    {
        int newSpriteNumber = Random.Range(0, spriteList.Count);
        while(newSpriteNumber == lastSprite)
        {
            newSpriteNumber = Random.Range(0, spriteList.Count);
        }
        lastSprite = newSpriteNumber;
        return spriteList[newSpriteNumber];
    }
}
