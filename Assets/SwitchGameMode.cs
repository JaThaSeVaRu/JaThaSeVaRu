using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwitchGameMode : MonoBehaviour
{
    //FightingMode
    [SerializeField] private GameObject[] fightingModeObjects;
    [SerializeField] private float fightingCameraSize;
    //RunningMode
    [SerializeField] private GameObject[] runningModeObjects;
    [SerializeField] private float runningCameraSize;

    public GameObject fight;

    private void Start()
    {
        GameManager.Instance.OnStopVelocity += SwitchMode;
        fight.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void SwitchMode()
    {
        fight.GetComponent<SpriteRenderer>().enabled = true;
        if (GameManager.Instance.InTransit)
        {
            //TO DO
            //Call UIManager and show a RUN transition
            //Call Enemy spawner and remove enemies
            //Place character in the center
            
            Camera.main.orthographicSize = runningCameraSize;
            foreach (var go in runningModeObjects)
            {
                if (go.GetComponent<characterControl>())
                {
                    go.transform.position = new Vector3(-0.029f, -3.7400f, -5);
                }
                go.SetActive(true);
            }
            foreach (var go in fightingModeObjects)
            {
                if (go.GetComponent<enemySpawn>())
                {
                    for(int i = 0; i < enemySpawn.enemyList.Count; i++) 
                    {
                        Destroy(enemySpawn.enemyList[i]);
                    }

                    enemySpawn.enemyList.RemoveRange(0,enemySpawn.enemyList.Count);
                }
                go.SetActive(false);
            }
        }
        
        //Switch to Fighting Mode
        else if (!GameManager.Instance.InTransit)
        {
            //TO DO
            //Call UIManager and show a FIGHT transition
            //SERA HIER FIGHTING TRANSITION!!!! <-------------------------------------

            fight.GetComponent<SpriteRenderer>().enabled = true;

            //Call Obstacle spawner and remove obstacles

            //2.3f might work for camera size
            Camera.main.orthographicSize = fightingCameraSize;
            foreach (var go in runningModeObjects)
            {
                if (go.GetComponent<obstacleSpawn>())
                {
                    for(int i = 0; i < obstacleSpawn.obstacleList.Count; i++) 
                    {
                        Destroy(obstacleSpawn.obstacleList[i]);
                    }

                    obstacleSpawn.obstacleList.RemoveRange(0,obstacleSpawn.obstacleList.Count);
                }
                go.SetActive(false);
            }
            foreach (var go in fightingModeObjects)
            {
                if (go.GetComponent<FightingCharacter>())
                {
                    go.transform.position = new Vector3(0, -0.4f, 0);
                }
                go.SetActive(true);
            }
        }
    }
}
