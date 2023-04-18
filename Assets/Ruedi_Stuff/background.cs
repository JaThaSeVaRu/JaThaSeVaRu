using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject frontHouse1;
    public GameObject firstHouse2;
    public GameObject firstHouse3;

    public GameObject secondHouse1;
    public GameObject secondHouse2;
    public GameObject secondHouse3;

    public GameObject thirdHouse1;
    public GameObject thirdHouse2;
    public GameObject thirdHouse3;

    public int firstHouseAmount = 15;
    public int secondHouseAmount = 15;
    public int thirdHouseAmount = 15;
    public int firstHouseChoice;
    public int secondHouseChoice;
    public int thirdHouseChoice;
    public int startHousePos = -10;
    public float firstHousePos = 12;
    public float secondHousePos = 12;
    public float thirdHousePos = 12;

    public static int firstSpawnState;
    public static int secondSpawnState;
    public static int thirdSpawnState;



    void Start()
    {
        for (var i = 0; i < thirdHouseAmount; i++)
        {
            

            if (i <= firstHouseAmount)
            {
                firstHouseChoice = Random.Range(1, 4);

                if (firstHouseChoice == 1)
                {
                    Instantiate(frontHouse1, new Vector3(startHousePos, -4.5f, 0), Quaternion.identity);
                }
                if (firstHouseChoice == 2)
                {
                    Instantiate(firstHouse2, new Vector3(startHousePos, -4, 0), Quaternion.identity);
                }
                if (firstHouseChoice == 3)
                {
                    Instantiate(firstHouse3, new Vector3(startHousePos, -3, 0), Quaternion.identity);
                }
            }

            
            if (i <= secondHouseAmount)
            {
                secondHouseChoice = Random.Range(1, 4);

                if (secondHouseChoice == 1)
                {
                    Instantiate(secondHouse1, new Vector3(startHousePos, -3.5f, 0.5f), Quaternion.identity);
                }
                if (secondHouseChoice == 2)
                {
                    Instantiate(secondHouse2, new Vector3(startHousePos, -3, 0.5f), Quaternion.identity);
                }
                if (secondHouseChoice == 3)
                {
                    Instantiate(secondHouse3, new Vector3(startHousePos, -2, 0.5f), Quaternion.identity);
                }

            }

            if (i <= thirdHouseAmount)
            {
                thirdHouseChoice = Random.Range(1, 4);

                if (thirdHouseChoice == 1)
                {
                    Instantiate(thirdHouse1, new Vector3(startHousePos, -2.5f, 1f), Quaternion.identity);
                }
                if (thirdHouseChoice == 2)
                {
                    Instantiate(thirdHouse2, new Vector3(startHousePos, -2, 1f), Quaternion.identity);
                }
                if (thirdHouseChoice == 3)
                {
                    Instantiate(thirdHouse3, new Vector3(startHousePos, -1, 1f), Quaternion.identity);
                }

            }


            startHousePos += 2;
        }
    }


    void Update()
    {

        if (firstSpawnState >= 1)
        {
            firstHouseChoice = Random.Range(1, 4);

            if (firstHouseChoice == 1)
            {
                Instantiate(frontHouse1, new Vector2(firstHousePos, -4.5f), Quaternion.identity);
            }
            if (firstHouseChoice == 2)
            {
                Instantiate(firstHouse2, new Vector2(firstHousePos, -4), Quaternion.identity);
            }
            if (firstHouseChoice == 3)
            {
                Instantiate(firstHouse3, new Vector2(firstHousePos, -3), Quaternion.identity);
            }

            firstSpawnState = 0;
        }


        if (secondSpawnState >= 1)
        {
            secondHouseChoice = Random.Range(1, 4);

            if (secondHouseChoice == 1)
            {
                Instantiate(secondHouse1, new Vector3(secondHousePos, -3.5f, 0.5f), Quaternion.identity);
            }
            if (secondHouseChoice == 2)
            {
                Instantiate(secondHouse2, new Vector3(secondHousePos, -3f, 0.5f), Quaternion.identity);
            }
            if (secondHouseChoice == 3)
            {
                Instantiate(secondHouse3, new Vector3(secondHousePos, -2, 0.5f), Quaternion.identity);
            }

            secondSpawnState = 0;
        }

        if (thirdSpawnState >= 1)
        {
            thirdHouseChoice = Random.Range(1, 4);

            if (thirdHouseChoice == 1)
            {
                Instantiate(thirdHouse1, new Vector3(thirdHousePos, -2.5f, 1f), Quaternion.identity);
            }
            if (thirdHouseChoice == 2)
            {
                Instantiate(thirdHouse2, new Vector3(thirdHousePos, -2f, 1f), Quaternion.identity);
            }
            if (thirdHouseChoice == 3)
            {
                Instantiate(thirdHouse3, new Vector3(thirdHousePos, -1, 1f), Quaternion.identity);
            }

            thirdSpawnState = 0;
        }
    }
}
