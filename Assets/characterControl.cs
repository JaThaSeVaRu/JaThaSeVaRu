using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum runstate { ONTRAIN, INTRAIN, JUMPING, SLIDING, SWITCHUP, SWITCHDOWN }
public class characterControl : MonoBehaviour
{

    public runstate state;

    public float speed;

    public bool falling;

    void Start()
    {
        state = runstate.INTRAIN;


    }

    void Update()
    {
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


        if (transform.position.y >= -0.5f && state == runstate.SWITCHUP)
        {
            transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
            Debug.Log("on Train");
            state = runstate.ONTRAIN;
        }

        if (transform.position.y <= -4f && state == runstate.SWITCHDOWN)
        {
            transform.position = new Vector3(transform.position.x, -4f, transform.position.z);
            Debug.Log("in Train");
            state = runstate.INTRAIN;
        }
    }

    public void Jump()
    {
        Debug.Log("jumping");

        if (transform.position.y <= 1.5f && falling == false)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (transform.position.y >= 1.5f && falling == false)
        {
            falling = true; 
        }
        if (falling == true && transform.position.y >= -0.5f)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (transform.position.y <= -0.5f && falling == true)
        {
            transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
            falling = false;
            state = runstate.ONTRAIN;
        }

    }

    public void Slide()
    {
        Debug.Log("sliding");
        state = runstate.INTRAIN;
    }

    public void SwitchDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    public void SwitchUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

}
