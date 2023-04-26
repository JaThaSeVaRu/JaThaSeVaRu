using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public GameObject character;

    public GameObject inTrainObstacle1;
    public GameObject inTrainObstacle2;
    public GameObject inTrainObstacle3;
    public GameObject inTrainObstacle4;
    public GameObject inTrainObstacle5;

    public GameObject onTrainObstacle1;
    public GameObject onTrainObstacle2;

    public float inTrainSpawnTime;
    public float inTrainSpawnMin;
    public float inTrainSpawnMax;
    public float inTrainSpawnRate = 5f;

    public float onTrainSpawnTime;
    public float onTrainSpawnMin;
    public float onTrainSpawnMax;
    public float onTrainSpawnRate = 5f;

    public int inTrainChoice;
    public int onTrainChoice;

    public bool noSpawn;
    public float noSpawnTime;
    public float spawnBackOn;

    void Start()
    {

    }


    void Update()
    {
        if (noSpawn == false)
        {
            if (character.GetComponent<characterControl>().state == runstate.INTRAIN)
            {
                inTrainSpawnTime += Time.deltaTime;
            }
            if (character.GetComponent<characterControl>().state != runstate.INTRAIN)
            {
                inTrainSpawnTime += Time.deltaTime / 2f;
            }

            if (character.GetComponent<characterControl>().state == runstate.ONTRAIN)
            {
                onTrainSpawnTime += Time.deltaTime * 1.5f;
            }
            if (character.GetComponent<characterControl>().state != runstate.ONTRAIN)
            {
                onTrainSpawnTime += Time.deltaTime;
            }
        }

        if (noSpawn == true)
        {
            noSpawnTime += Time.deltaTime;
        }

        if (noSpawnTime >= spawnBackOn)
        {
            noSpawn = false;
            noSpawnTime = 0;
        }

        if (inTrainSpawnTime >= inTrainSpawnRate)
        {
            inTrainChoice = Random.Range(1, 6);

            if (inTrainChoice == 1)
            {
                Instantiate(inTrainObstacle1, new Vector3(15, -3.5f, -6f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }

            if (inTrainChoice == 2)
            {
                Instantiate(inTrainObstacle2, new Vector3(15, -4f, -6f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }

            if (inTrainChoice == 3)
            {
                Instantiate(inTrainObstacle3, new Vector3(15, -4.8f, -6f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }

            if (inTrainChoice == 4)
            {
                Instantiate(inTrainObstacle4, new Vector3(15, -5f, -6f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }

            if (inTrainChoice == 5)
            {
                Instantiate(inTrainObstacle5, new Vector3(15, -4f, -4.8f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }
        }


        if (onTrainSpawnTime >= onTrainSpawnRate)
        {

            onTrainChoice = Random.Range(1, 3);

            if (onTrainChoice == 1)
            {
                Instantiate(onTrainObstacle1, new Vector3(15, -6f, -0.5f), Quaternion.identity);
                onTrainSpawnRate = Random.Range(onTrainSpawnMin, onTrainSpawnMax);
                onTrainSpawnTime = 0;
                noSpawn = true;
            }
            if (onTrainChoice == 2)
            {
                Instantiate(onTrainObstacle2, new Vector3(15, -2.5f, -0.5f), Quaternion.identity);
                onTrainSpawnRate = Random.Range(onTrainSpawnMin, onTrainSpawnMax);
                onTrainSpawnTime = 0;
                noSpawn = true;
            }
        }
    }
}
