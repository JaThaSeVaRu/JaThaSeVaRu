using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;

    public int spawnChoice;

    public Vector3 leftSpawn;
    public Vector3 rightSpawn;

    public float spawnRate;
    public float spawnTime;

    public static List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {
        Instantiate(enemy, leftSpawn, Quaternion.identity);
        Instantiate(enemy, rightSpawn, Quaternion.identity);
    }


    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnRate)
        {
            spawnChoice = Random.Range(1, 3);

            if (spawnChoice == 1)
            {
                enemyList.Add(Instantiate(enemy, leftSpawn, Quaternion.identity));;
                
                spawnTime = 0;
            }
            if (spawnChoice == 2)
            {
                enemyList.Add(Instantiate(enemy, rightSpawn, Quaternion.identity));
                spawnTime = 0;
            }
        }
    }
}
