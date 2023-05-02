using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    public GameObject character;

    public GameObject inTrainSmall;
    public GameObject inTrainMedium;
    public GameObject inTrainLarge;
    public GameObject Lover;
    public GameObject Lover_g;


    public GameObject onTrainPylon;
    public GameObject onTrainBird;
    public GameObject Kontrolleur;

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
            inTrainChoice = Random.Range(1, 7);

            if (inTrainChoice == 1)
            {
                Instantiate(inTrainSmall, new Vector3(15, -3.3f, -6f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }

            if (inTrainChoice == 2)
            {
                Instantiate(inTrainMedium, new Vector3(15, -3.3f, -6f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }

            if (inTrainChoice == 3)
            {
                Instantiate(inTrainLarge, new Vector3(15, -3.3f, -6f), Quaternion.identity);
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

            if (inTrainChoice == 5)
            {
                Instantiate(Kontrolleur, new Vector3(15, -4f, -4.8f), Quaternion.identity);
                inTrainSpawnRate = Random.Range(inTrainSpawnMin, inTrainSpawnMax);
                inTrainSpawnTime = 0;
                noSpawn = true;
            }

            if(inTrainChoice == 6)
            {
                Instantiate(Lover_g, new Vector3(15, -4f, -4.8f), Quaternion.identity);
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
                Instantiate(onTrainPylon, new Vector3(15, -6f, -0.5f), Quaternion.identity);
                onTrainSpawnRate = Random.Range(onTrainSpawnMin, onTrainSpawnMax);
                onTrainSpawnTime = 0;
                noSpawn = true;
            }
            if (onTrainChoice == 2)
            {
                Instantiate(onTrainBird, new Vector3(15, -2.5f, -0.5f), Quaternion.identity);
                onTrainSpawnRate = Random.Range(onTrainSpawnMin, onTrainSpawnMax);
                onTrainSpawnTime = 0;
                noSpawn = true;
            }
        }
    }
}
