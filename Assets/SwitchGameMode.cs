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
    [SerializeField] public GameObject[] runningModeObjects;
    [SerializeField] private float runningCameraSize;

    public GameObject fight;
    public static SwitchGameMode instance;
    float lastSwitch;
    float modeChangeCooldown = 15;

    private void Start()
    {
        instance = this;
        GameManager.Instance.OnStopVelocity += SwitchMode;
        fight.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void StartGame()
    {
        foreach (var go in runningModeObjects)
        {
            go.SetActive(true);
            GameManager.Instance.gameStarted = true;
        }
    }

    public void SwitchMode()
    {
        if (GameManager.Instance.gameStarted)
        {
            if (GameManager.Instance.InTransit && Time.realtimeSinceStartup - lastSwitch > modeChangeCooldown)
            {
                lastSwitch = Time.realtimeSinceStartup;
                fight.GetComponent<SpriteRenderer>().enabled = true;
                fight.GetComponent<Animator>().Play("Fight", 0, 0);
                //TO DO
                //Call UIManager and show a RUN transition
                //Call Enemy spawner and remove enemies
                //Place character in the center
                fight.GetComponent<SpriteRenderer>().enabled = false;
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
                        for (int i = 0; i < enemySpawn.enemyList.Count; i++)
                        {
                            Destroy(enemySpawn.enemyList[i]);
                        }

                        enemySpawn.enemyList.RemoveRange(0, enemySpawn.enemyList.Count);
                    }
                    go.SetActive(false);
                }
            }

            //Switch to Fighting Mode
            else if (!GameManager.Instance.InTransit &&  Time.realtimeSinceStartup - lastSwitch > modeChangeCooldown)
            {
                lastSwitch = Time.realtimeSinceStartup;
                //TO DO
                //Call UIManager and show a FIGHT transition
                //SERA HIER FIGHTING TRANSITION!!!! <-------------------------------------

                fight.GetComponent<SpriteRenderer>().enabled = true;
                fight.GetComponent<Animator>().Play("Fight", 0, 0);
                //fight.GetComponent<Animator>().Play("Fight", 0, 0);

                //Call Obstacle spawner and remove obstacles

                //2.3f might work for camera size
                Camera.main.orthographicSize = fightingCameraSize;
                foreach (var go in runningModeObjects)
                {
                    if (go.GetComponent<obstacleSpawn>())
                    {
                        for (int i = 0; i < obstacleSpawn.obstacleList.Count; i++)
                        {
                            Destroy(obstacleSpawn.obstacleList[i]);
                        }

                        obstacleSpawn.obstacleList.RemoveRange(0, obstacleSpawn.obstacleList.Count);
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
}
