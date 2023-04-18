using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject house1;
    public GameObject house2;
    public GameObject house3;

    public int houseAmount = 15;
    public int houseChoice;
    public int startHousePos = -10;
    public int housePos = 12;

    public float spawnRate;
    public float spawnTime;


    void Start()
    {
        for (var i = 0; i < houseAmount; i++)
        {
            
            houseChoice = Random.Range(1, 4);

            if (houseChoice == 1)
            {
                Instantiate(house1, new Vector2(startHousePos, -4.5f), Quaternion.identity);
            }
            if (houseChoice == 2)
            {
                Instantiate(house2, new Vector2(startHousePos, -4), Quaternion.identity);
            }
            if (houseChoice == 3)
            {
                Instantiate(house3, new Vector2(startHousePos, -3), Quaternion.identity);
            }

            startHousePos+= 2;
        }
    }


    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnRate)
        {
            houseChoice = Random.Range(1, 4);

            if (houseChoice == 1)
            {
                Instantiate(house1, new Vector2(housePos, -4.5f), Quaternion.identity);
            }
            if (houseChoice == 2)
            {
                Instantiate(house2, new Vector2(housePos, -4), Quaternion.identity);
            }
            if (houseChoice == 3)
            {
                Instantiate(house3, new Vector2(housePos, -3), Quaternion.identity);
            }

            spawnTime = 0;
        }

    }
}
