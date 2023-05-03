using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwitchGameMode : MonoBehaviour
{
    //FightingMode
    [SerializeField] private GameObject[] fightingModeObjects;
    //RunningMode
    [SerializeField] private GameObject[] runningModeObjects;

    private void Start()
    {
        GameManager.Instance.OnArrival += SwitchMode;
    }

    public void SwitchMode()
    {
        if (GameManager.Instance.InTransit)
        {
            //TO DO
            //Call UIManager and show a RUN transition
            //Call Enemy spawner and remove enemies
            //Place character in the center
            
            Camera.main.orthographicSize = 5;
            foreach (var go in runningModeObjects)
            {
                go.SetActive(true);
            }
            foreach (var go in fightingModeObjects)
            {
                go.SetActive(false);
            }
        }
        
        //Switch to Fighting Mode
        else if (!GameManager.Instance.InTransit)
        {
            //TO DO
            //Call UIManager and show a FIGHT transition
            //Call Obstacle spawner and remove obstacles

            Camera.main.orthographicSize = 2.3f;
            foreach (var go in runningModeObjects)
            {
                if (go.GetComponent<characterControl>())
                {
                    go.transform.position = new Vector3(-0.029f, -3.7400f, -5);
                }
                else if (go.GetComponent<obstacleSpawn>())
                {
                    
                }
                go.SetActive(false);
            }
            foreach (var go in fightingModeObjects)
            {
                if (go.GetComponent<FightingCharacter>())
                {
                    go.transform.position = new Vector3(0, -0.4f, 0);
                }
                else if (go.GetComponent<enemySpawn>())
                {
                    for(int i = 0; i < enemySpawn.enemyList.Count; i++) 
                    {
                        Destroy(enemySpawn.enemyList[i]);
                    }

                    enemySpawn.enemyList.RemoveRange(0,enemySpawn.enemyList.Count);
                }
                go.SetActive(true);
            }
        }
    }
}
