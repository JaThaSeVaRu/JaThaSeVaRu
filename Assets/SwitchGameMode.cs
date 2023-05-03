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
        // TO DO Tween this values Camera.main.orthographicSize;

        if (GameManager.Instance.InTransit)
        {
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
        else if (!GameManager.Instance.InTransit)
        {
            Camera.main.orthographicSize = 2.3f;
            foreach (var go in runningModeObjects)
            {
                go.SetActive(false);
            }
            foreach (var go in fightingModeObjects)
            {
                go.SetActive(true);
            }
        }
    }
}
