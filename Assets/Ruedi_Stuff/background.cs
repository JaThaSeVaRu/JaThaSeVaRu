using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject house1;
    public GameObject house2;
    public GameObject house3;
    public GameObject house4;
    public GameObject park1;
    public GameObject park2;
    public GameObject park3;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;

    public int frontHouseAmount = 15;
    public int midHouseAmount = 15;
    public int backHouseAmount = 15;
    public int cloudAmount = 5;

    int frontHouseChoice;
    int midHouseChoice;
    int backHouseChoice;
    int cloudChoice;


    public float startHousePos = -10;
    public float firstHousePos = 12;
    public float midHousePos = 12;
    public float backHousePos = 12;

     float frontSpawnTimer;
     float midSpawnTimer;
     float backSpawnTimer;
    float cloudSpawnTimer;

    float frontSpawnRate;
    public float frontSpawnMin;
    public float frontSpawnMax;

    float midSpawnRate;
    public float midSpawnMin;
    public float midSpawnMax;

    float backSpawnRate;
    public float backSpawnMin;
    public float backSpawnMax;

    float cloudSpawnRate;
    public float cloudSpawnMin;
    public float cloudSpawnMax;

    public float frontHouseHeight;
    public float midHouseHeight;
    public float backHouseHeight;



    void Start()
    {
        for (var i = 0; i < frontHouseAmount; i++)
        {
            

            if (i <= frontHouseAmount)
            {
                frontHouseChoice = Random.Range(1, 9);

                if (frontHouseChoice >= 1 && frontHouseChoice <= 2)
                {
                    Instantiate(house1, new Vector3(startHousePos, frontHouseHeight, 0), Quaternion.identity);
                }
                if (frontHouseChoice >= 3 && frontHouseChoice <= 5)
                {
                    Instantiate(house2, new Vector3(startHousePos, frontHouseHeight, 0), Quaternion.identity);
                }
                if (frontHouseChoice == 6)
                {
                    Instantiate(park1, new Vector3(startHousePos, frontHouseHeight, 0), Quaternion.identity);
                }
                if (frontHouseChoice == 7)
                {
                    Instantiate(park2, new Vector3(startHousePos, frontHouseHeight, 0), Quaternion.identity);
                }
                if (frontHouseChoice == 8)
                {
                    Instantiate(park3, new Vector3(startHousePos, frontHouseHeight, 0), Quaternion.identity);
                }
            }

            
            if (i <= midHouseAmount)
            {
                midHouseChoice = Random.Range(1, 8);

                if (midHouseChoice == 1)
                {
                    Instantiate(house1, new Vector3(startHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                }
                if (midHouseChoice == 2)
                {
                    Instantiate(house2, new Vector3(startHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                }
                if (midHouseChoice == 3)
                {
                    Instantiate(house3, new Vector3(startHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                }
                if (midHouseChoice == 4)
                {
                    Instantiate(park1, new Vector3(startHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                }
                if (midHouseChoice == 5)
                {
                    Instantiate(park2, new Vector3(startHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                }
                if (midHouseChoice == 6)
                {
                    Instantiate(park3, new Vector3(startHousePos, midHouseHeight, 0.5f), Quaternion.identity);
                }

            }

            if (i <= backHouseAmount)
            {
                backHouseChoice = Random.Range(1, 6);

                if (backHouseChoice == 1)
                {
                    Instantiate(house1, new Vector3(startHousePos, backHouseHeight, 1f), Quaternion.identity);
                }
                if (backHouseChoice == 2)
                {
                    Instantiate(house2, new Vector3(startHousePos, backHouseHeight, 1f), Quaternion.identity);
                }
                if (backHouseChoice == 3)
                {
                    Instantiate(house3, new Vector3(startHousePos, backHouseHeight, 1f), Quaternion.identity);
                }
                if (backHouseChoice == 4)
                {
                    Instantiate(house4, new Vector3(startHousePos, backHouseHeight, 1f), Quaternion.identity);
                }

            }

            if (i <= cloudAmount)
            {
                cloudChoice = Random.Range(1, 7);

                if (backHouseChoice == 1)
                {
                    Instantiate(cloud1, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
                if (backHouseChoice == 2)
                {
                    Instantiate(cloud2, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
                if (backHouseChoice == 3)
                {
                    Instantiate(cloud3, new Vector3(Random.Range(-8f, 8f), Random.Range(0f, 4f), 5f), Quaternion.identity);
                }
            }

            startHousePos += 2.5f;
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
            frontHouseChoice = Random.Range(1, 9);

            if (frontHouseChoice >= 1 && frontHouseChoice <= 2)
            {
                Instantiate(house1, new Vector2(firstHousePos, frontHouseHeight), Quaternion.identity);
            }
            if (frontHouseChoice >= 3 && frontHouseChoice <= 5)
            {
                Instantiate(house2, new Vector2(firstHousePos, frontHouseHeight), Quaternion.identity);
            }
            if (frontHouseChoice == 6)
            {
                Instantiate(park1, new Vector3(firstHousePos, frontHouseHeight, 0), Quaternion.identity);
            }
            if (frontHouseChoice == 7)
            {
                Instantiate(park2, new Vector3(firstHousePos, frontHouseHeight, 0), Quaternion.identity);
            }
            if (frontHouseChoice == 8)
            {
                Instantiate(park3, new Vector3(firstHousePos, frontHouseHeight, 0), Quaternion.identity);
            }

            frontSpawnRate = Random.Range(frontSpawnMin, frontSpawnMax);

            frontSpawnTimer = 0;
        }


        if (midSpawnTimer >= midSpawnRate)
        {
            midHouseChoice = Random.Range(1, 7);

            if (midHouseChoice == 1)
            {
                Instantiate(house1, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
            }
            if (midHouseChoice == 2)
            {
                Instantiate(house2, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
            }
            if (midHouseChoice == 3)
            {
                Instantiate(house3, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
            }
            if (frontHouseChoice == 4)
            {
                Instantiate(park1, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
            }
            if (midHouseChoice == 5)
            {
                Instantiate(park2, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
            }
            if (midHouseChoice == 6)
            {
                Instantiate(park3, new Vector3(midHousePos, midHouseHeight, 0.5f), Quaternion.identity);
            }
            midSpawnRate = Random.Range(midSpawnMin, midSpawnMax);

            midSpawnTimer = 0;
        }

        if (backSpawnTimer >= backSpawnRate)
        {
            backHouseChoice = Random.Range(1, 5);

            if (backHouseChoice == 1)
            {
                Instantiate(house1, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
            }
            if (backHouseChoice == 2)
            {
                Instantiate(house2, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
            }
            if (backHouseChoice == 3)
            {
                Instantiate(house3, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
            }
            if (backHouseChoice == 4)
            {
                Instantiate(house4, new Vector3(backHousePos, backHouseHeight, 1f), Quaternion.identity);
            }

            backSpawnRate = Random.Range(backSpawnMin, backSpawnMax);

            backSpawnTimer = 0;
        }


        if (cloudSpawnTimer >= cloudSpawnRate)
        {
            cloudChoice = Random.Range(1, 4);

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

            cloudSpawnRate = Random.Range(cloudSpawnMin, cloudSpawnMax);

            cloudSpawnTimer = 0;
        }


    }
}
