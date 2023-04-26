using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum runstate { ONTRAIN, INTRAIN, JUMPING, SLIDING, SWITCHUP, SWITCHDOWN, STUMBLING }
public class characterControl : MonoBehaviour
{

    public runstate state;

    public float speed;
    public float jumpSpeed;
    public float slideSpeed;

    public float approachSpeed;
    public float approachBase;
    public float approachLimit;

    public bool falling;
    public bool gettingUp;

    public float jumpHeight;
    public float slideHeight;

    public Vector3 jumpBase;
    public Vector3 slideBase;
    public Vector3 stumbleBase;

    float jumpingTime;
    public float jumpingLimit;

    float slidingTime;
    public float slidingLimit;

    //public GameObject train;

    float stumbleTime;
    public float stumbleLimit;
    public float stumbleSpeed;

    public float safeTime;
    public float safeLimit;

    public SpriteRenderer m_SpriteRenderer;

    public GameObject manager;

    private Animator anim;


    void Start()
    {
        state = runstate.INTRAIN;
        slideBase = transform.position;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        safeTime = safeLimit;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        approachSpeed = approachBase * (1 + (manager.GetComponent<gameManager>().heartsStolen * 0.1f));

        if (safeTime <= safeLimit)
        {
            safeTime += Time.deltaTime;
        }

        if (safeTime < safeLimit)
        {
            m_SpriteRenderer.color = new Color(1, 0.9f, 0.9f);
        }

        if (safeTime >= safeLimit)
        {
            m_SpriteRenderer.color = new Color(1, 0.48f, 0.78f);
        }

        if (Input.GetKeyDown("up"))
        {
            if (state == runstate.INTRAIN)
            {
                state = runstate.SWITCHUP;
            }


            if (state == runstate.ONTRAIN)
            {
                state = runstate.JUMPING;
            }
        }


        if (Input.GetKeyDown("down"))
        {
            if (state == runstate.INTRAIN)
            {
                state = runstate.SLIDING;
            }


            if (state == runstate.ONTRAIN)
            {
                state = runstate.SWITCHDOWN;
            }
        }

        /*
        if (Input.GetKeyDown("space"))
        {
            if (state == runstate.ONTRAIN || state == runstate.JUMPING)
            {
                jumpBase = transform.position;
                stumbleBase = jumpBase;
            }
            if (state == runstate.INTRAIN || state == runstate.SLIDING || state == runstate.SWITCHUP ||state == runstate.SWITCHDOWN)
            {
                slideBase = transform.position;
                stumbleBase = slideBase;
            }

            state = runstate.STUMBLING;
        }
        */


        if (state == runstate.INTRAIN || state == runstate.ONTRAIN)
        {
            if (transform.position.x <= approachLimit)
            {
                transform.Translate(Vector3.right * approachSpeed * Time.deltaTime);
            }
        }


        if (state == runstate.JUMPING)
        {
            Jump();
        }

        if (state == runstate.SLIDING)
        {
            Slide();
        }

        if (state == runstate.SWITCHUP)
        {
            Debug.Log("moving up");
            SwitchUp();
        }

        if (state == runstate.SWITCHDOWN)
        {
            Debug.Log("moving down");
            SwitchDown();
        }

        if (state == runstate.STUMBLING)
        {
            Stumble();
        }

        if (transform.position.y >= jumpBase.y && state == runstate.SWITCHUP)
        {
            transform.position = new Vector3(transform.position.x, jumpBase.y, transform.position.z);
            Debug.Log("on Train");
            state = runstate.ONTRAIN;
            jumpBase = transform.position;
            anim.SetBool("Switch_Up", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("Switch_Down", false);
        }

        if (transform.position.y <= slideBase.y && state == runstate.SWITCHDOWN)
        {
            transform.position = new Vector3(transform.position.x, slideBase.y, transform.position.z);
            Debug.Log("in Train");
            state = runstate.INTRAIN;
            slideBase = transform.position;
            anim.SetBool("Switch_Down", false);
            anim.SetBool("Switch_Up", false);
            anim.SetBool("IsJumping", false);
        }
    }

    public void Jump()
    {
        anim.SetBool("IsJumping", true);

        Debug.Log("jumping");

        if (transform.position.y <= jumpBase.y + jumpHeight && falling == false)
        {
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
        }
        if (transform.position.y >= jumpBase.y + jumpHeight && falling == false)
        {
            falling = true; 
        }
        if (falling == true && transform.position.y >= jumpBase.y && jumpingTime >= jumpingLimit)
        {
            transform.Translate(Vector3.down * jumpSpeed * Time.deltaTime);
        }
        if (transform.position.y <= jumpBase.y && falling == true)
        {
            transform.position = new Vector3(transform.position.x, jumpBase.y, transform.position.z);
            falling = false;
            state = runstate.ONTRAIN;
            jumpingTime = 0;
            jumpBase = transform.position;
            anim.SetBool("IsJumping", false);
        }

        if (falling == true)
        {
            jumpingTime += Time.deltaTime;
        }

    }

    public void Slide()
    {
        anim.SetBool("Slide", true);

        Debug.Log("Slide");
        if (transform.position.y >= slideBase.y + slideHeight && gettingUp == false)
        {
            transform.Translate(Vector3.down * slideSpeed * Time.deltaTime);
        }
        if (transform.position.y <= slideBase.y + slideHeight && gettingUp == false)
        {
            gettingUp = true;
        }
        if (gettingUp == true && transform.position.y <= slideBase.y && slidingTime >= slidingLimit)
        {
            transform.Translate(Vector3.up * slideSpeed * Time.deltaTime);
        }
        if (transform.position.y >= slideBase.y && gettingUp == true)
        {
            Debug.Log("got up");
            transform.position = new Vector3(transform.position.x, slideBase.y, transform.position.z);
            gettingUp = false;
            slidingTime = 0;
            state = runstate.INTRAIN;
            slideBase = transform.position;
            anim.SetBool("Slide", false);
        }
        
        if (gettingUp == true)
        {
            slidingTime += Time.deltaTime;
        }
    }

    public void SwitchDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        anim.SetBool("Switch_Up", true);
    }
    public void SwitchUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        anim.SetBool("Switch_Down", true);
    }

    public void Stumble()
    {

        safeTime = 0;

        stumbleSpeed = train.staticSpeed;
        stumbleTime += Time.deltaTime;
        transform.Translate(Vector3.left * stumbleSpeed * Time.deltaTime);

        if (stumbleTime >= stumbleLimit)
        {
            transform.position = new Vector3(transform.position.x, stumbleBase.y, transform.position.z);

            if (stumbleBase.y == jumpBase.y)
            {
                state = runstate.ONTRAIN;
            }
            if (stumbleBase.y == slideBase.y)
            {
                state = runstate.INTRAIN;
            }

            stumbleTime = 0;

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            if (state != runstate.STUMBLING && safeTime >= safeLimit)
            {

                if (state == runstate.ONTRAIN || state == runstate.JUMPING)
                {
                    //jumpBase = transform.position;
                    stumbleBase = jumpBase;
                }
                if (state == runstate.INTRAIN || state == runstate.SLIDING || state == runstate.SWITCHUP || state == runstate.SWITCHDOWN)
                {
                    //slideBase = transform.position;
                    stumbleBase = slideBase;
                }

                state = runstate.STUMBLING;
            }

        }
    }
}
