using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBarrier : MonoBehaviour
{
    public GameObject spawner;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            if (spawner.GetComponent<obstacleSpawn>().noSpawn == true)
            {
                spawner.GetComponent<obstacleSpawn>().noSpawnTime = 0;
            }
            if (spawner.GetComponent<obstacleSpawn>().noSpawn == false)
            {
                spawner.GetComponent<obstacleSpawn>().noSpawn = true;
            }
        }
    }
}
