using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public enum runstate { ONTRAIN, INTRAIN, JUMPING, POSING, SWITCHUP, SWITCHDOWN, STUMBLING, CAUGHT }
public class characterControl : MonoBehaviour
{
    //for the Statemachine
    public runstate state;
    public GameObject winlose;

    //various speed values used for switching lanes up and down, jumping and posing
    //posingSpeed might not be needed in the future
    public float switchSpeed;
    public float jumpSpeed;
    public float poseSpeed;

    //Values to make the player slowly move to the right to recover from knockbacks
    //approachSpeed is calculated from approachBase and number of stolen hearts
    //approachLimit prevents the player to move too far to the right
    public float approachSpeed;
    public float approachBase = 0.1f;
    public float approachLimit;

    //falling bool for the later half of the jump
    public bool falling;
    //getting up bool for the later half of the pose (might not be needed in the future)
    public bool gettingUp;

    //value to set how high the player is able to jump
    public float jumpHeight;
    //value to set how low the player slides (might not be needed in the future)
    public float poseHeight;

    //Position values to tell if a player is currently in the position to jump or pose and to return to after jumping or posing
    public Vector3 jumpBase;
    public Vector3 poseBase;

    //Position values to return to after stumbling
    public Vector3 stumbleBase;

    //Timer values for the duration of a jump
    float jumpingTime;
    public float jumpingLimit;

    //Timer values for the duration of a pose
    float posingTime;
    public float posingLimit;

    //Timer values for the duration of stumbling
    float stumbleTime;
    public float stumbleLimit;
    //stumbling speed equals the current train speed to simulate the player being dragged along with the train
    public float stumbleSpeed;

    public float caughtTime;
    public float caughtLimit;
    public float pushTime;
    public float pushSpeed;

    //Timer values to make the Player invulnerable for stumbling 
    public float safeTime;
    public float safeLimit;

    //getting the spriteRenderer to set color when the player is invincible
    public SpriteRenderer m_SpriteRenderer;

    //Get the Player Scriptable Object
    public PlayerData player;

    //values for touch inputs (Ask Jaime about these)
    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;
    public float slideSensitivity;
    public bool touchHeld;
    public bool tapped;
    public float posingTimer;
    public float holdSensitivity;

    private Animator anim;

    void Start()
    {
        //player starts in the train
        state = runstate.INTRAIN;
        //set the position to return to, after posing
        poseBase = transform.position;

        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        //set invincibility off 
        safeTime = safeLimit;


        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //calculate approachSpeed
        //approchspeed increases by collecting hearts
        //approachSpeed = approachBase * (1 + (winlose.GetComponent<WinLoseScore>().actualHearts * 0.1f));
        approachSpeed = approachBase * (1 + (WinLoseScore.actualHearts * 0.1f));

        //start the safetimer after stumbling
        if (safeTime <= safeLimit)
        {
            safeTime += Time.deltaTime;
        }

        //change playercolor to white when invincible
        if (safeTime < safeLimit)
        {
            m_SpriteRenderer.color = new Color(1, 0.48f, 0.78f);
        }

        //change playercolor to default when not invincible
        if (safeTime >= safeLimit)
        {
            m_SpriteRenderer.color = new Color(1, 1, 1);
        }
        
        //Posing timer
        


        //touchinputs (jaime knows whats going on here)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    tapped = false;
                    touchHeld = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    if (Math.Abs(direction.y) > slideSensitivity)
                    {
                        directionChosen = true;
                    }
                    if (posingTimer < holdSensitivity && !directionChosen)
                    {
                        tapped = true;
                    }
                    touchHeld = false;
                    posingTimer = 0;
                    break;

                //Report that touch was held
                case TouchPhase.Stationary:
                    posingTimer += Time.unscaledDeltaTime;
                    if (posingTimer > holdSensitivity)
                    {
                        touchHeld = true;
                    }
                    break;
            }

            if (directionChosen)
            {
                if (Input.GetKeyDown("up") || Math.Sign(direction.y) == 1)
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

                if (Input.GetKeyDown("down") || Math.Sign(direction.y) == -1)
                {
                    // if (state == runstate.INTRAIN)
                    // {
                    //     state = runstate.POSING;
                    // }


                    if (state == runstate.ONTRAIN)
                    {
                        state = runstate.SWITCHDOWN;
                    }
                }
            }

            if (touchHeld)
            {
                if (state == runstate.INTRAIN)
                {
                    state = runstate.POSING;
                }
            }

            if (tapped)
            {
                Debug.Log("Screen was tapped)");
                //TO DO: Check if player touched a UI Icon by tapping.
                //Send mouse position to function in UI Manager to check.
            }

        }


        //what happens if you press UP
        if (Input.GetKeyDown("up"))
        {
            //if player is INSIDE the Train switch lane to ON TOP of Train
            if (state == runstate.INTRAIN)
            {
                state = runstate.SWITCHUP;
            }

            //if player is ON TOP of Train jump
            if (state == runstate.ONTRAIN)
            {
                state = runstate.JUMPING;
            }
        }


        if (Input.GetKeyDown("down"))
        {
            //if player is INSIDE the Train pose
            if (state == runstate.INTRAIN)
            {
                state = runstate.POSING;
            }

            //if player is ON TOP of Train switch lane to INSIDE of Train
            if (state == runstate.ONTRAIN)
            {
                state = runstate.SWITCHDOWN;
            }
        }
        //when running (NOT jumping, posing, stumbling or switching lanes) use approachSpeed to slowly move to the right
        if (state == runstate.INTRAIN || state == runstate.ONTRAIN)
        {
            if (transform.position.x <= approachLimit && obstacleSpawn.gameRunning == true)
            {
                transform.Translate(Vector3.right * approachSpeed * Time.deltaTime);
            }
        }


        if (state == runstate.JUMPING)
        {
            Jump();
        }

        if (state == runstate.POSING)
        {
            Pose();
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

        if (state == runstate.CAUGHT)
        {
            GotCaught();
        }

        //if player siwtched lane UPWARDS
        if (transform.position.y >= jumpBase.y && state == runstate.SWITCHUP)
        {
            //set Y-Axis position to jumpBase
            transform.position = new Vector3(transform.position.x, jumpBase.y, transform.position.z);
            Debug.Log("on Train");
            //change state to ONTRAIN
            state = runstate.ONTRAIN;
            //save Jumpbase for the future (maybe this is not really neccessary)
            jumpBase = transform.position;
            anim.SetBool("Switch_Up", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("Switch_Down", false);
        }

        //if player switched lane DOWNWARDS
        if (transform.position.y <= poseBase.y && state == runstate.SWITCHDOWN)
        {
            transform.position = new Vector3(transform.position.x, poseBase.y, transform.position.z);
            Debug.Log("in Train");
            state = runstate.INTRAIN;
            poseBase = transform.position;
            anim.SetBool("Switch_Up", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("Switch_Down", false);
        }
    }

    //FOLLOWING: Methods for jumping, posing, stumbling and switching lanes


    public void Jump()
    {
        Debug.Log("jumping");
        anim.SetBool("IsJumping", true);

        //move upwards
        if (transform.position.y <= jumpBase.y + jumpHeight && falling == false)
        {
            transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
        }

        //reach the top height and switch to falling
        if (transform.position.y >= jumpBase.y + jumpHeight && falling == false)
        {
            falling = true;
        }

        //move back down
        if (falling == true && transform.position.y >= jumpBase.y && jumpingTime >= jumpingLimit)
        {
            transform.Translate(Vector3.down * jumpSpeed * Time.deltaTime);
        }

        //go back to running
        if (transform.position.y <= jumpBase.y && falling == true)
        {
            transform.position = new Vector3(transform.position.x, jumpBase.y, transform.position.z);
            falling = false;
            state = runstate.ONTRAIN;
            jumpingTime = 0;
            jumpBase = transform.position;
            anim.SetBool("IsJumping", false);
        }

        //timer to remain in the air for a brief time after reaching top height
        if (falling == true)
        {
            jumpingTime += Time.deltaTime;
        }

    }

    public void Pose()
    {
        //THIS MIGHT NOT BE NECESSARY ANYMORE (feel free to rework)
        anim.SetBool("Slide", true);

        Debug.Log("posing");

        //move downwards
        if (transform.position.y >= poseBase.y + poseHeight && gettingUp == false)
        {
            transform.Translate(Vector3.down * poseSpeed * Time.deltaTime);
        }

        //reach the lowest point and switch to getting up
        if (transform.position.y <= poseBase.y + poseHeight && gettingUp == false)
        {
            gettingUp = true;
        }

        //move back up
        if (gettingUp == true && transform.position.y <= poseBase.y && posingTime >= posingLimit)
        {
            transform.Translate(Vector3.up * poseSpeed * Time.deltaTime);
        }

        //go back to running
        if (transform.position.y >= poseBase.y && gettingUp == true)
        {
            Debug.Log("got up");
            transform.position = new Vector3(transform.position.x, poseBase.y, transform.position.z);
            gettingUp = false;
            posingTime = 0;
            state = runstate.INTRAIN;
            poseBase = transform.position;
            anim.SetBool("Slide", false);
        }

        //timer to remain in lower position for a brief time after reaching top height
        if (gettingUp == true)
        {
            posingTime += Time.deltaTime;
        }
    }

    public void SwitchDown()
    {
        anim.SetBool("Switch_Down", true);
        //move downwards
        //process continues in line 285
        transform.Translate(Vector3.down * switchSpeed * Time.deltaTime);
    }
    public void SwitchUp()
    {
        anim.SetBool("Switch_Up", true);
        //move upwards
        //process continues in line 273
        transform.Translate(Vector3.up * switchSpeed * Time.deltaTime);
    }

    public void Stumble()
    {
        anim.SetBool("IsJumping", false);
        anim.SetBool("Slide", false);

        //set the invincibility timer back to 0 after being hit
        safeTime = 0;

        //set the stumble speed equal to train speed to make it appear like player get's dragged along with train
        stumbleSpeed = GameManager.Instance.player.Velocity;
        //start timer
        stumbleTime += Time.deltaTime;
        //move to the left along with the train
        transform.Translate(Vector3.left * stumbleSpeed * Time.deltaTime);

        //reset Y-Axis position to stumbleBase if player got hit while jumping, switching or posing
        if (stumbleTime >= stumbleLimit)
        {
            transform.position = new Vector3(transform.position.x, stumbleBase.y, transform.position.z);

            //reset state depending on the position before player got hit
            if (stumbleBase.y == jumpBase.y)
            {
                state = runstate.ONTRAIN;
            }
            if (stumbleBase.y == poseBase.y)
            {
                state = runstate.INTRAIN;
            }

            stumbleTime = 0;
        }

    }

    public void GotCaught()
    {

        caughtTime += Time.deltaTime;
        Debug.Log("GotCaught");

        if (caughtTime >= caughtLimit && caughtTime < caughtLimit + pushTime)
        {
            winlose.GetComponent<WinLoseScore>().state = gamestate.CAUGHT;
            winlose.GetComponent<WinLoseScore>().GetCaught();
            GameManager.Instance.player.CollectedHearts = 0;
            //transform.Translate(Vector3.right * pushSpeed * Time.deltaTime);
            transform.position = new Vector3(0, stumbleBase.y, transform.position.z);
            foreach (var go in obstacleSpawn.obstacleList)
            { 
                if (go != null)
                {
                    go.SetActive(false);
                }
            }
        }
        if (caughtTime >= caughtLimit + pushTime)
        {
            safeTime = 0;

            transform.position = new Vector3(transform.position.x, stumbleBase.y, transform.position.z);

            if (stumbleBase.y == jumpBase.y)
            {
                state = runstate.ONTRAIN;
            }
            if (stumbleBase.y == poseBase.y)
            {
                state = runstate.INTRAIN;
            }

            caughtTime = 0;
        }
    }


    //check collision with obstacles
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            if (obstacleSpawn.gameRunning == true)
            {
                anim.SetBool("Switch_Down", false);
                anim.SetBool("Switch_Up", false);
                //check if player is already stumbling or currently invincible
                //if Not: Proceed.
                if (state != runstate.STUMBLING && safeTime >= safeLimit)
                {
                    //set stumbleBase depending on current position
                    if (state == runstate.ONTRAIN || state == runstate.JUMPING)
                    {
                        stumbleBase = jumpBase;
                    }
                    if (state == runstate.INTRAIN || state == runstate.POSING || state == runstate.SWITCHUP || state == runstate.SWITCHDOWN)
                    {
                        stumbleBase = poseBase;
                    }

                    //change state to stumbling
                    state = runstate.STUMBLING;
                }

            }

        }


        if (collision.gameObject.CompareTag("mass"))
        {
            if (state != runstate.CAUGHT)
            {
                if (state == runstate.ONTRAIN || state == runstate.JUMPING)
                {
                    stumbleBase = jumpBase;
                }
                if (state == runstate.INTRAIN || state == runstate.POSING || state == runstate.SWITCHUP || state == runstate.SWITCHDOWN)
                {
                    stumbleBase = poseBase;
                }

                state = runstate.CAUGHT;

            }

        }
    }
}
