    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCharacter : MonoBehaviour
{
    Vector2 startPos;
    Vector2 endPos;
    float tapDistance = 100;
    public List<Sprite> spriteList = new List<Sprite>();
    public GameObject Herz;
    int direction = 0;
    SpriteRenderer sprite;
    int lastSprite;

    public bool IsAvailable = true;
    public float CooldownDuration = 0.5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float launchForce = 50;
    [SerializeField] private float destroyAfterSeconds = 0f;
    public GameObject heart;
    //public GameObject myPrefab_l;

    public int gotHit;
    public float recoveryTime;
    public float recoveryRate;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        //rb.velocity = transform.forward * launchForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAvailable)
        {
            // rb.velocity = transform.forward * launchForce;
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
                            StartCoroutine(StartCooldown());
                            //Tap
                            if (touch.position.x < Screen.width / 2f)
                            {
                                //Attack Left
                                AttackLeft();
                            }
                            else
                            {
                                //Attack Right
                                AttackRight();
                            }
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

            if (Input.GetKeyDown("left"))
            {
                //Attack Left
                AttackLeft();
            }
            if (Input.GetKeyDown("right"))
            {
                //Attack Right
                AttackRight();
            }

            if (gotHit == 1)
            {
                recoveryTime += Time.deltaTime;
            }

            if (recoveryTime >= recoveryRate)
            {
                gotHit = 0;
                recoveryTime = 0;
            }
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


    //new
    public void AttackLeft()
    {
        if (gotHit == 0)
        {
            StartCoroutine(StartCooldown());
            Instantiate(heart, new Vector3(-0.1f, -1, 0), Quaternion.identity);
            direction = -1;
            sprite.sprite = newSprite();
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
    }
    public void AttackRight()
    {

        if (gotHit == 0)
        {
            StartCoroutine(StartCooldown());
            Instantiate(heart, new Vector3(0.1f, -1, 0), Quaternion.identity);
            direction = 1;
            sprite.sprite = newSprite();
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
    }

    //new
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Ouch!");
            gotHit = 1;
        }
    }

    public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        IsAvailable = true;
    }
}
