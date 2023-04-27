using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    // get the Player to tell what lane they are currently running on
    public GameObject character;

    //different Types of InTrain Obstacles
    public GameObject inTrainSmall;
    public GameObject inTrainMedium;
    public GameObject inTrainLarge;
    public GameObject Lover;

    //different Types of OnTrain Obstacles
    public GameObject onTrainPylon;
    public GameObject onTrainBird;

    //Timer values for InTrain Obstacles
    //minimum and maximum values to set inTrainSpawnRate
    //TimeLimit for InTrain Spawns
    public float inTrainSpawnTime;
    public float inTrainSpawnMin;
    public float inTrainSpawnMax;
    public float inTrainSpawnRate = 5f;

    //Timer values for OnTrain Obstacles
    //minimum and maximum values to set onTrainSpawnRate
    //TimeLimit for OnTrain Spawns
    public float onTrainSpawnTime;
    public float onTrainSpawnMin;
    public float onTrainSpawnMax;
    public float onTrainSpawnRate = 5f;

    //value to set what assset should be spawned wither in or on the Train
    public int inTrainChoice;
    public int onTrainChoice;

    //bools and Timers for the noSpawn  Condition used to prevent an overabundance of unevadable obstacles
    public bool noSpawn;
    public float noSpawnTime;
    public float spawnBackOn;

    void Start()
    {

    }


    void Update()
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //IMPORTANT: check spawnBarrier-Script for extension of this script
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        //nospawn condition exists to prevent obstacles to be spawned both in and on the train as well es not between to train carts
        //less obstacles are spawned on the lane the player is currently NOT running on, to make switching lanes less risky
        //lanes in question are [IN the train] and [ON the train]
        if (noSpawn == false)
        {
            if (character.GetComponent<characterControl>().state == runstate.INTRAIN)
            {
                //if player is running IN train the inTrain spawn timers speed normal
                inTrainSpawnTime += Time.deltaTime;
            }
            if (character.GetComponent<characterControl>().state != runstate.INTRAIN)
            {
                //if player is running IN train the inTrain spawn timers speed is just 50%
                inTrainSpawnTime += Time.deltaTime / 2f;
            }

            if (character.GetComponent<characterControl>().state == runstate.ONTRAIN)
            {
                //if player is running ON train the onTrain spawn timers speed is +50% faster
                onTrainSpawnTime += Time.deltaTime * 1.5f;
            }
            if (character.GetComponent<characterControl>().state != runstate.ONTRAIN)
            {
                //if player is running ON train the onTrain spawn timers speed is normal
                onTrainSpawnTime += Time.deltaTime;
            }
        }

        //timer to stop spawns
        if (noSpawn == true)
        {
            noSpawnTime += Time.deltaTime;
        }

        //timer to stop spawns gets deactivated
        if (noSpawnTime >= spawnBackOn)
        {
            noSpawn = false;
            noSpawnTime = 0;
        }



        //Spawn Obstacles INSIDE of Train
        if (inTrainSpawnTime >= inTrainSpawnRate)
        {
            //choose an obstacle to be spawned
            inTrainChoice = Random.Range(1, 5);

            if (inTrainChoice == 1)
            {
                //spawn the chosen obstacle
                Instantiate(inTrainSmall, new Vector3(15, -4.2f, -6f), Quaternion.identity);
                //reset the spawnrate between a minimum and maximum value
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                //reset spawnTimer to 0
                inTrainSpawnTime = 0;
                //to noSpawn on to prevent unevadable obstacles
                noSpawn = true;
            }

            if (inTrainChoice == 2)
            {
                Instantiate(inTrainMedium, new Vector3(15, -3.9f, -6f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }

            if (inTrainChoice == 3)
            {
                Instantiate(inTrainLarge, new Vector3(15, -3.7f, -6f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }

            if (inTrainChoice == 4)
            {
                Instantiate(Lover, new Vector3(15, -4f, -4.8f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }
        }

        //Spawn Obstacles OUTSIDE of Train
        if (onTrainSpawnTime >= onTrainSpawnRate)
        {

            onTrainChoice = Random.Range(1, 3);

            if (onTrainChoice == 1)
            {
                Instantiate(onTrainPylon, new Vector3(15, -3f, -0.5f), Quaternion.identity);
                onTrainSpawnRate = Random.Range(onTrainSpawnMin, onTrainSpawnMax);
                onTrainSpawnTime = 0;
                noSpawn = true;
            }
            if (onTrainChoice == 2)
            {
                Instantiate(onTrainBird, new Vector3(15, -1f, -0.5f), Quaternion.identity);
                onTrainSpawnRate = Random.Range(onTrainSpawnMin, onTrainSpawnMax);
                onTrainSpawnTime = 0;
                noSpawn = true;
            }
        }
    }
}
