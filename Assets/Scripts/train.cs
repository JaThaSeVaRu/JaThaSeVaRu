using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train : MonoBehaviour
{
    //set speed of train
    public float speed = 8f;
    //static variable for character, lover and obstacles to use
    public static float staticSpeed;
    //starting position to be teleported back to
    public Vector3 startPosition;
    //X-Axis value to initialise the teleport back to startPosititon
    public float setBack = -27.84f;


    void Start()
    {
        //get current position and set as start position
        startPosition = transform.position;
    }

    void Update()
    {
        //set static speed equal to speed for the character-Script, lover-Script and the Obstacle-Script to use
        staticSpeed = speed;
        
        //move left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //if setback-Position is reached set back to starting position to simulate an infinite loop
        if (transform.position.x <= setBack)
        {
            transform.position = startPosition;
        }
    }
}
