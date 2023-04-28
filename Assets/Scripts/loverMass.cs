using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loverMass : MonoBehaviour
{
    //various values for speed
    public float baseSpeed;
    public float speed;
    public float switchSpeed;

    //get the current position of the player
    public GameObject character;
    //get the current amount of collected hearts from the player scriptable object
    public PlayerData player;


    void Start()
    {
        
    }

    void Update()
    {
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //IMPORTANT: check loverMassComponents-Script for the running shake animation
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        //the speed to switch lanes is a fourth of the characters speed to switch lanes
        //by this the lover mass switches with a little delay
        switchSpeed = character.GetComponent<characterControl>().switchSpeed / 4f;

        //speed increases with the number of collected hearts
        speed = baseSpeed * ( 1 + player.CollectedHearts);


        //lover mass slowly moves to the right
        //but can not move further than x -3.5
        //this increases tension and risk from knockbacks over time
        if (transform.position.x <= -3.5f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        //make the lovermass copy the movements of the player (but slower)
        if (transform.position.y <= -0.6f)
        {
            if (character.GetComponent<characterControl>().transform.position.y <= transform.position.y)
            {
                transform.Translate(Vector3.down * switchSpeed * Time.deltaTime);
            }
            if (character.GetComponent<characterControl>().transform.position.y >= transform.position.y)
            {
                transform.Translate(Vector3.up * switchSpeed * Time.deltaTime);
            }
        }

        //if player is on top of train and jumps the lover mass stays in position and does not jump
        if (transform.position.y > -0.6f)
        {
            transform.position = new Vector3(transform.position.x, -0.6f, transform.position.z);
        }
    }
}
