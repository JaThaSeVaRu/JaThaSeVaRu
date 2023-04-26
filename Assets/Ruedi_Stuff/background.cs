using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject house1;
    public GameObject house2;
    public GameObject house3;
    public GameObject house4;
    public GameObject house5;
    public GameObject house6;
    public GameObject house7;
    public GameObject house8;
    public GameObject house9;
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

    public int frontHouseAmount = 15;
    public int midHouseAmount = 15;
    public int backHouseAmount = 15;
    public int cloudAmount = 5;

    int frontChoice;
    int prevFrontChoice;
    int midChoice;
    int prevMidChoice;
    int backChoice;
    int prevBackChoice;
    int cloudChoice;


    public float startFrontPos = -10;
    public float startMidPos = -10;
    public float startBackPos = -10;
    public float frontHousePos = 12;
    public float midHousePos = 12;
    public float backHousePos = 12;

     float frontSpawnTimer;
     float midSpawnTimer;
     float backSpawnTimer;
    float cloudSpawnTimer;

    public float frontSpawnRate;
    public float midSpawnRate;
    public float backSpawnRate;

    float cloudSpawnRate;
    public float cloudSpawnMin;
    public float cloudSpawnMax;

    public float frontHouseHeight;
    public float midHouseHeight;
    public float backHouseHeight;

    public static float staticFrontHouseHeight;
    public static float staticMidHouseHeight;
    public static float staticBackHouseHeight;

     float house1Range = 3;
     float house2Range = 3;
     float house3Range = 3;
     float house4Range = 3.5f;
     float house5Range = 3.3f;
     float house6Range = 4;
     float house7Range = 3.3f;
     float house8Range = 2.7f;
     float house9Range = 3.5f;
     float park1Range = 1.2f;
     float park2Range = 1;
     float park3Range = 1.5f;
     float park4Range = 1;



    void Start()
    {


        staticFrontHouseHeight = frontHouseHeight;
        staticMidHouseHeight = midHouseHeight;
        staticBackHouseHeight = backHouseHeight;


        for (var i = 0; i < frontHouseAmount; i++)
        {
            

            if (startFrontPos <= frontHousePos)
            {
                frontChoice = Random.Range(1, 15);

                if (frontChoice >= 1 && frontChoice <= 2)
                {
                    if (prevFrontChoice != 1 || prevFrontChoice != 2)
                    {
                        Instantiate(house1, new Vector3(startFrontPos, frontHouseHeight, 0), Quaternion.identity);
                        startFrontPos += house1Range;
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

            
            if (startMidPos <= midHousePos)
            {
                midChoice = Random.Range(1, 14);

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
                        Instantiate(park1, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += park1Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 10)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(park2, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += park2Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 11)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(park3, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += park3Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice == 12)
                {
                    if (prevMidChoice != midChoice)
                    {
                        Instantiate(park4, new Vector3(startMidPos, midHouseHeight, 0.5f), Quaternion.identity);
                        startMidPos += park4Range;
                        prevMidChoice = midChoice;
                    }
                }
                if (midChoice >= 13)
                {
                    if (prevMidChoice < 13)
                    {
                        startMidPos += 2;
                        prevMidChoice = midChoice;
                    }
                }
            }


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
                if (backChoice >= 6)
                {
                    if (prevBackChoice < 6)
                    {
                        startBackPos += 3;
                        prevBackChoice = backChoice;
                    }
                }

            }

            if (i <= cloudAmount)
            {
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
        frontSpawnTimer += Time.deltaTime;
        midSpawnTimer += Time.deltaTime;
        backSpawnTimer += Time.deltaTime;
        cloudSpawnTimer += Time.deltaTime;



        if (frontSpawnTimer >= frontSpawnRate)
        {
            frontChoice = Random.Range(1, 10);

            if (frontChoice == 1)
            {
                if (prevFrontChoice != frontChoice)
                {
                    Instantiate(house1, new Vector2(frontHousePos, frontHouseHeight), Quaternion.identity);
                    frontSpawnRate = 0.3f + (house1Range * 0.1f);
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


        if (midSpawnTimer >= midSpawnRate)
        {
            midChoice = Random.Range(1, 14);

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
            if (frontChoice == 9)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(park1, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (park1Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 10)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(park2, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (park2Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 11)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(park3, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (park3Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (midChoice == 12)
            {
                if (prevMidChoice != midChoice)
                {
                    Instantiate(park4, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                    midSpawnRate = 0.7f + (park4Range * 0.1f);
                    prevMidChoice = midChoice;
                }
            }
            if (backChoice == 13)
            {
                if (prevMidChoice != midChoice)
                {
                    midSpawnRate = 1.5f;
                    prevMidChoice = midChoice;
                }
            }

            midSpawnTimer = 0;
        }

        if (backSpawnTimer >= backSpawnRate)
        {
            backChoice = Random.Range(1, 7);

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
                    backSpawnRate = 4;
                    prevBackChoice = backChoice;
                }
            }

            backSpawnTimer = 0;
        }


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
