using System;
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
    public GameObject winlose;
    //get the current amount of collected hearts from the player scriptable object
    public PlayerData player;

    public WinLoseScore winLoseScore;
    public bool retreat;
    public float retreatTime;
    public float keepTime;
    public float retreatLimit;
    public float retreatSpeed;


    void Start()
    {
        retreat = false;
        winLoseScore = GetComponent<WinLoseScore>();
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
        //speed = baseSpeed * (1 + winlose.GetComponent<WinLoseScore>().actualHearts);
        speed = baseSpeed * ( 1 + WinLoseScore.actualHearts);


        //lover mass slowly moves to the right
        //but can not move further than x -3.5
        //this increases tension and risk from knockbacks over time
        if (transform.position.x <= -6f && retreat == false && obstacleSpawn.gameRunning == true)
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

        if (winlose.GetComponent<WinLoseScore>().state == gamestate.CAUGHT || winlose.GetComponent<WinLoseScore>().state == gamestate.FIGHTING)
        {
            retreat = true;
        }

        if (retreat == true)
        {
            retreatTime += Time.deltaTime;
        }

        if (retreat == true && winlose.GetComponent<WinLoseScore>().state == gamestate.RUNNING)
        {
            retreat = false;
            retreatTime = 0;
        }

        if (winlose.GetComponent<WinLoseScore>().state == gamestate.CAUGHT)
        {
            if (/*retreatTime >= keepTime && */transform.position.x >= -12 && retreat == true)
            {
                transform.Translate(Vector3.left * retreatSpeed * Time.deltaTime);
            }
            if (/*retreatTime >= keepTime && */transform.position.x <= -12 && retreat == true)
            {
                retreat = false;
                retreatTime = 0;
            }
        }

        if (winlose.GetComponent<WinLoseScore>().state == gamestate.FIGHTING)
        {
            if (transform.position.x >= -12 && retreat == true)
            {
                transform.Translate(Vector3.left * retreatSpeed * Time.deltaTime);
            }
        }
    }
}
