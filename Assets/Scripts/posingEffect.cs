using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posingEffect : MonoBehaviour
{
    //get the player to know when they are posing
    public GameObject character;


    void Start()
    {
        //place the effect somewhere out of bounds
        //save that position (except for Y-Axis) for later
        //Y-Axis position is 10 to make sure it'S out of bounds
        transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
    }

    void Update()
    {
        //if player IS NOT posing teleport the effect to the position saved in Start
        if (character.GetComponent<characterControl>().state != runstate.POSING)
        {
            transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
        }
        //if player IS posing teleport the effect to the position of the player
        if (character.GetComponent<characterControl>().state == runstate.POSING)
        {
            transform.position = character.GetComponent<characterControl>().transform.position;
        }
    }
}
