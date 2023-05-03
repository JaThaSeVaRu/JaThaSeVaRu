using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBarrier : MonoBehaviour
{
    //get the objectspawner to make it stop
    public GameObject spawner;


    //get the collision with the Train ends in order to prevent spawning between two train carts
    //the barrier is positioned to only collide with the colliders of the train, and not with spawned obstacles
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
