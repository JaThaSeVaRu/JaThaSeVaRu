using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeTrain : MonoBehaviour
{

    //set speed of tree row
    public float speed = 8f;
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
        //move left
        transform.Translate(Vector3.left * speed / 10f * GameManager.Instance.player.Velocity * Time.deltaTime);

        //if setback-Position is reached set back to starting position to simulate an infinite loop
        if (transform.position.x <= setBack)
        {
            transform.position = startPosition;
        }
    }
}
