using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    //list of prefabs
    //maybe not the most efficient way. ffeel free to optimize
    public GameObject house1;
    public GameObject house2;
    public GameObject house3;
    public GameObject house4;
    public GameObject house5;
    public GameObject house6;
    public GameObject house7;
    public GameObject house8;
    public GameObject house9;
    public GameObject house10;
    public GameObject park1;
    public GameObject park2;
    public GameObject park3;
    public GameObject park4;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public GameObject cloud4;
    public GameObject cloud5;
    public GameObject cloud6;
    public GameObject cloud7;
    public GameObject cloud8;

    //amount of houses and clouds for the for loop that spawns houses and clouds in Start
    public int frontHouseAmount = 15;
    public int cloudAmount = 5;

    //variables to choose the assets to be spawned
    //prev: variables that remember the previously chosen asset to prevent duplicates
    int frontChoice;
    int prevFrontChoice;
    int midChoice;
    int prevMidChoice;
    int backChoice;
    int prevBackChoice;
    int cloudChoice;

    //X-Axis positions for spawning Houses in Start
    public float startFrontPos = -10;
    public float startMidPos = -10;
    public float startBackPos = -10;
    //X-Axis positions for spawning Houses on runtime
    public float frontHousePos = 12;
    public float midHousePos = 12;
    public float backHousePos = 12;
    //Y-Axis positions for spawning Houses
    public float frontHouseHeight;
    public float midHouseHeight;
    public float backHouseHeight;

    //Timers for runtime spawns of houses and clouds
    float frontSpawnTimer;
    float midSpawnTimer;
    float backSpawnTimer;
    float cloudSpawnTimer;

    //Timelimits for runtime spawns of houses
    public float frontSpawnRate;
    public float midSpawnRate;
    public float backSpawnRate;

    //Timelimit for runtime spawns of clouds
    float cloudSpawnRate;
    //minimum and maximum values to set cloudSpawnRate after a cloud has been spawned
    public float cloudSpawnMin;
    public float cloudSpawnMax;

    //static Y-Axis positions of houses for the houseMovement Script to use
    public static float staticFrontHouseHeight;
    public static float staticMidHouseHeight;
    public static float staticBackHouseHeight;

    //X-Axis offset for each type of house or park to prevent overlaps
    float house1Range = 3;
    float house2Range = 3;
    float house3Range = 3;
    float house4Range = 4f;
    float house5Range = 3.3f;
    float house6Range = 4;
    float house7Range = 3.3f;
    float house8Range = 2.7f;
    float house9Range = 3.5f;
    float house10Range = 1f;
    float park1Range = 1.2f;
    float park2Range = 1;
    float park3Range = 1.5f;
    float park4Range = 1;



    void Start()
    {

        //set the static positions of the houses for the houseMovement Script to use
        staticFrontHouseHeight = frontHouseHeight;
        staticMidHouseHeight = midHouseHeight;
        staticBackHouseHeight = backHouseHeight;


        for (var i = 0; i < frontHouseAmount; i++)
        {
            
            //place houses in the front row before the game starts
            if (startFrontPos <= frontHousePos)
            {
                //the asset get's chosen. In this case, houses have a higher chance than trees (parks)
                frontChoice = Random.Range(1, 15);

                if (frontChoice >= 1 && frontChoice <= 2)
                {
                    //checks if this is the same asset as before to prevent duplicates
                    if (prevFrontChoice != 1 || prevFrontChoice != 2)
                    {
                        //spawns house
                        Instantiate(house1, new Vector3(startFrontPos, frontHouseHeight, 0), Quaternion.identity);
                        //sets an offset for the next house to prevent overlapping
                        startFrontPos += house1Range;
                        //saves this asset for the next check for duplicates
                        prevFrontChoice = frontChoice;
                    }
                }
                if (frontChoice >= 3 && frontChoice <= 4)
                {
                    if (prevFrontChoice != 3 || prevFrontChoice != 4)
                    {
                        Instantiate(house2, new Vector3(startFrontPos, frontHouseHeight, 0), Quaternion.identity);
                        startFrontPos += house2Range;
                        prevFrontChoice = frontChoice;
                    }
                }
                if (frontChoice >= 5 && frontChoice <= 6)
                {
                    if (prevFrontChoice != 5 || prevFrontChoice != 6)
                    {
                        Instantiate(house5, new Vector3(startFrontPos, frontHouseHeight, 0), Quaternion.identity);
                        startFrontPos += house5Range;
                        prevFrontChoice = frontChoice;
                    }
                }
                if (frontChoice >= 7 && frontChoice <= 8)
                {
                    if (prevFrontChoice != 7 || prevFrontChoice != 8)
                    {
                        Instantiate(house6, new Vector3(startFrontPos, frontHouseHeight, 0), Quaternion.identity);
                        startFrontPos += house6Range;
                        prevFrontChoice = frontChoice;
                    }
                }
                if (frontChoice == 9)
                {
                    if (prevFrontChoice != frontChoice)
                    {
                        Instantiate(park1, new Vector3(startFrontPos, frontHouseHeight, 0), Quaternion.identity);
                        startFrontPos += park1Range;
                        prevFrontChoice = frontChoice;

                    }
                }
                if (frontChoice == 10)
                {
                    if (prevFrontChoice != frontChoice)
                    {
                        Instantiate(park2, new Vector3(startFrontPos, frontHouseHeight, 0), Quaternion.identity);
                        startFrontPos += park2Range;
                        prevFrontChoice = frontChoice;
                    }
                }
                if (frontChoice == 11)
                {
                    if (prevFrontChoice != frontChoice)
                    {
                        Instantiate(park3, new Vector3(startFrontPos, frontHouseHeight, 0), Quaternion.identity);
                        startFrontPos += park3Range;
                        prevFrontChoice = frontChoice;
                    }
                }
                if (frontChoice == 12)
                {
                    if (prevFrontChoice != frontChoice)
                    {
                        Instantiate(park4, new Vector3(startFrontPos, frontHouseHeight, 0), Quaternion.identity);
                        startFrontPos += park4Range;
                        prevFrontChoice = frontChoice;
                    }
                }
                if (frontChoice >= 13)
                {
                    if (prevFrontChoice < 13)
                    {
                        startFrontPos += 1;
                        prevFrontChoice = frontChoice;
                    }
                }
            }


            //place houses in the middle row before the game starts
            if (startMidPos <= midHousePos)
            {
                midChoice = Random.Range(1, 15);

                if (midChoice == 1)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(house1, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += house1Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 2)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(house2, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += house2Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 3)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(house3, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += house3Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 4)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(house5, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += house5Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 5)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(house6, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += house6Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 6)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(house7, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += house7Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 7)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(house8, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += house8Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 8)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(house9, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += house9Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 9)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(house10, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += house10Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 10)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(park1, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += park1Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 11)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(park2, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += park2Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 12)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(park3, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += park3Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 13)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(park4, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += park4Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice >= 14)
                {
                    if (prevMidChoice < 13)
                    {
                        startMidPos += 2;
                        prevMidChoice = midChoice;
                    }
                }
            }


            //place houses in the back row before the game starts
            if (startBackPos <= backHousePos)
            {
                backChoice = Random.Range(1, 8);

                if (backChoice == 1)
                {
                    if (prevBackChoice != backChoice)
                    {
                        Instantiate(house3, new Vector3(startBackPos, backHouseHeight, 1f), Quaternion.identity);
                        startBackPos += house3Range;
                        prevBackChoice = backChoice;
                    }
                }
                if (backChoice == 2)
                {
                    if (prevBackChoice != backChoice)
                    {
                        Instantiate(house4, new Vector3(startBackPos, backHouseHeight, 1f), Quaternion.identity);
                        startBackPos += house4Range;
                        prevBackChoice = backChoice;
                    }
                }
                if (backChoice == 3)
                {
                    if (prevBackChoice != backChoice)
                    {
                        Instantiate(house5, new Vector3(startBackPos, backHouseHeight, 1f), Quaternion.identity);
                        startBackPos += house5Range;
                        prevBackChoice = backChoice;
                    }
                }
                if (backChoice == 4)
                {
                    if (prevBackChoice != backChoice)
                    {
                        Instantiate(house6, new Vector3(startBackPos, backHouseHeight, 1f), Quaternion.identity);
                        startBackPos += house6Range;
                        prevBackChoice = backChoice;
                    }
                }
                if (backChoice == 5)
                {
                    if (prevBackChoice != backChoice)
                    {
                        Instantiate(house7, new Vector3(startBackPos, backHouseHeight, 1f), Quaternion.identity);
                        startBackPos += house7Range;
                        prevBackChoice = backChoice;
                    }
                }
                if (backChoice == 6)
                {
                    if (prevBackChoice != backChoice)
                    {
                        Instantiate(house10, new Vector3(startBackPos, backHouseHeight, 1f), Quaternion.identity);
                        startBackPos += house10Range;
                        prevBackChoice = backChoice;
                    }
                }
                if (backChoice >= 7)
                {
                    if (prevBackChoice < 7)
                    {
                        startBackPos += 3;
                        prevBackChoice = backChoice;
                    }
                }

            }

            //place clouds in the background before the game starts
            if (i <= cloudAmount)
            {
                //chance of spawning a cloud is 8/20 (less than 50%) to prevent the sky from being cluttered with clouds
                cloudChoice = Random.Range(1, 20);

                if (backChoice == 1)
                {
                    Instantiate(cloud1, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
                if (backChoice == 2)
                {
                    Instantiate(cloud2, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
                if (backChoice == 3)
                {
                    Instantiate(cloud3, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
                if (backChoice == 4)
                {
                    Instantiate(cloud4, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
                if (backChoice == 5)
                {
                    Instantiate(cloud5, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
                if (backChoice == 6)
                {
                    Instantiate(cloud6, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
                if (backChoice == 7)
                {
                    Instantiate(cloud7, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
                if (backChoice == 8)
                {
                    Instantiate(cloud8, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
            }
        }
    }


    void Update()
    {
        //Timers for the runtime spawning of assets 
        frontSpawnTimer += Time.deltaTime;
        midSpawnTimer += Time.deltaTime;
        backSpawnTimer += Time.deltaTime;
        cloudSpawnTimer += Time.deltaTime;


        //spawn houses in the front row on runtime
        if (frontSpawnTimer >= frontSpawnRate)
        {
            //Choose an asset to spawn
            frontChoice = Random.Range(1, 10);

            if (frontChoice == 1)
            {
                //check if the previous asset has been the same as this asset to prevent duplicates
                if (prevFrontChoice != frontChoice)
                {
                    //spawn the chosen asset
                    Instantiate(house1, new Vector2(frontHousePos, frontHouseHeight), Quaternion.identity);
                    //set the timer for the next spawn depending on the type of house that has just been spawned
                    frontSpawnRate = 0.3f + (house1Range * 0.1f);
                    //save this choice for the next check for duplicates
                    prevFrontChoice = frontChoice;
                }
            }
            if (frontChoice == 2)
            {
                if (prevFrontChoice != frontChoice)
                {
                    Instantiate(house2, new Vector2(frontHousePos, frontHouseHeight), Quaternion.identity);
                    frontSpawnRate = 0.3f + (house2Range * 0.1f);
                    prevFrontChoice = frontChoice;
                }
            }
            if (frontChoice == 3)
            {
                if (prevFrontChoice != frontChoice)
                {
                    Instantiate(house5, new Vector2(frontHousePos, frontHouseHeight), Quaternion.identity);
                    frontSpawnRate = 0.3f + (house5Range * 0.1f);
                    prevFrontChoice = frontChoice;
                }
            }
            if (frontChoice == 4)
            {
                if (prevFrontChoice != frontChoice)
                {
                    Instantiate(house6, new Vector2(frontHousePos, frontHouseHeight), Quaternion.identity);
                    frontSpawnRate = 0.3f + (house6Range * 0.1f);
                    prevFrontChoice = frontChoice;
                }
            }
            if (frontChoice == 5)
            {
                if (prevFrontChoice != frontChoice)
                {
                    Instantiate(park1, new Vector3(frontHousePos, frontHouseHeight, 0), Quaternion.identity);
                    frontSpawnRate = 0.3f + (park1Range * 0.1f);
                    prevFrontChoice = frontChoice;
                }
            }
            if (frontChoice == 6)
            {
                if (prevFrontChoice != frontChoice)
                {
                    Instantiate(park2, new Vector3(frontHousePos, frontHouseHeight, 0), Quaternion.identity);
                    frontSpawnRate = 0.3f + (park2Range * 0.1f);
                    prevFrontChoice = frontChoice;
                }
            }
            if (frontChoice == 7)
            {
                if (prevFrontChoice != frontChoice)
                {
                    Instantiate(park3, new Vector3(frontHousePos, frontHouseHeight, 0), Quaternion.identity);
                    frontSpawnRate = 0.3f + (park3Range * 0.1f);
                    prevFrontChoice = frontChoice;
                }
            }
            if (frontChoice == 8)
            {
                if (prevFrontChoice != frontChoice)
                {
                    Instantiate(park4, new Vector3(frontHousePos, frontHouseHeight, 0), Quaternion.identity);
                    frontSpawnRate = 0.3f + (park4Range * 0.1f);
                    prevFrontChoice = frontChoice;
                }
            }
            if (backChoice == 9)
            {
                if (prevFrontChoice != frontChoice)
                {
                    frontSpawnRate = 1;
                    prevFrontChoice = frontChoice;
                }
            }

            frontSpawnTimer = 0;
        }

        //spawn houses in the middle row on runtime
        if (midSpawnTimer >= midSpawnRate)
        {
            midChoice = Random.Range(1, 15);

            if (midChoice == 1)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(house1, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (house1Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 2)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(house2, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (house2Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 3)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(house3, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (house3Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 4)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(house5, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (house5Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 5)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(house6, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (house6Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 6)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(house7, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (house7Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 7)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(house8, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (house8Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 8)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(house9, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (house9Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 9)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(house10, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (house10Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (frontChoice == 10)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(park1, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (park1Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 11)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(park2, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (park2Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 12)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(park3, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (park3Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 13)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(park4, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (park4Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (backChoice == 14)
            {
                if (prevMidChoice != midChoice)
                {
                    midSpawnRate = 1.5f;
                    prevMidChoice = midChoice;
                }
            }

            midSpawnTimer = 0;
        }

        //spawn houses in the back row on runtime
        if (backSpawnTimer >= backSpawnRate)
        {
            backChoice = Random.Range(1, 8);

            if (backChoice == 1)
            {
                if (prevBackChoice != backChoice)
                {
                    Instantiate(house3, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
                    backSpawnRate = 2.5f + (house3Range * 0.1f);
                    prevBackChoice = backChoice;
                }
            }
            if (backChoice == 2)
            {
                if (prevBackChoice != backChoice)
                {
                    Instantiate(house4, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
                    backSpawnRate = 2.5f + (house4Range * 0.1f);
                    prevBackChoice = backChoice;
                }
            }
            if (backChoice == 3)
            {
                if (prevBackChoice != backChoice)
                {
                    Instantiate(house5, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
                    backSpawnRate = 2.5f + (house5Range * 0.1f);
                    prevBackChoice = backChoice;
                }
            }
            if (backChoice == 4)
            {
                if (prevBackChoice != backChoice)
                {
                    Instantiate(house6, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
                    backSpawnRate = 2.5f + (house6Range * 0.1f);
                    prevBackChoice = backChoice;
                }
            }
            if (backChoice == 5)
            {
                if (prevBackChoice != backChoice)
                {
                    Instantiate(house7, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
                    backSpawnRate = 2.5f + (house7Range * 0.1f);
                    prevBackChoice = backChoice;
                }
            }
            if (backChoice == 6)
            {
                if (prevBackChoice != backChoice)
                {
                    Instantiate(house10, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
                    backSpawnRate = 2.5f + (house10Range * 0.1f);
                    prevBackChoice = backChoice;
                }
            }
            if (backChoice == 7)
            {
                if (prevBackChoice != backChoice)
                {
                    backSpawnRate = 4;
                    prevBackChoice = backChoice;
                }
            }

            backSpawnTimer = 0;
        }

        //spawn clouds in the background on runtime
        if (cloudSpawnTimer >= cloudSpawnRate)
        {
            cloudChoice = Random.Range(1, 9);

            if (cloudChoice == 1)
            {
                Instantiate(cloud1, new Vector3(11f, Random.Range(0f, 4f), 5f), Quaternion.identity);
            }
            if (cloudChoice == 2)
            {
                Instantiate(cloud2, new Vector3(11f, Random.Range(0f, 4f), 5f), Quaternion.identity);
            }
            if (cloudChoice == 3)
            {
                Instantiate(cloud3, new Vector3(11f, Random.Range(0f, 4f), 5f), Quaternion.identity);
            }
            if (cloudChoice == 4)
            {
                Instantiate(cloud3, new Vector3(11f, Random.Range(0f, 4f), 5f), Quaternion.identity);
            }
            if (cloudChoice == 5)
            {
                Instantiate(cloud3, new Vector3(11f, Random.Range(0f, 4f), 5f), Quaternion.identity);
            }
            if (cloudChoice == 6)
            {
                Instantiate(cloud3, new Vector3(11f, Random.Range(0f, 4f), 5f), Quaternion.identity);
            }
            if (cloudChoice == 7)
            {
                Instantiate(cloud3, new Vector3(11f, Random.Range(0f, 4f), 5f), Quaternion.identity);
            }
            if (cloudChoice == 8)
            {
                Instantiate(cloud3, new Vector3(11f, Random.Range(0f, 4f), 5f), Quaternion.identity);
            }

            cloudSpawnRate = Random.Range(cloudSpawnMin, cloudSpawnMax);

            cloudSpawnTimer = 0;
        }


    }
}
