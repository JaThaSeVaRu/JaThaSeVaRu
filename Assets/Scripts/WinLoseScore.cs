using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum gamestate { RUNNING, GAMEOVER, CAUGHT, FIGHTING, HEARTSTEAL }
public class WinLoseScore : MonoBehaviour
{
    public gamestate state;
    
    public int actualHearts;
    public int heartWorth;

    public float stayTime;
    public float returnTime;
    
    public PlayerData player;

    void Start()
    {
        state = gamestate.RUNNING;
        
    }
    
    void Update()
    {
        heartWorth = Mathf.FloorToInt(1 + (actualHearts / 10f));

        if (state == gamestate.FIGHTING || state == gamestate.CAUGHT)
        {
            stayTime += Time.deltaTime;
        }
        if (stayTime >= returnTime)
        {
            state = gamestate.RUNNING;
            stayTime = 0;
        }
    }

    // public void StealHeart()
    // {
    //     state = gamestate.HEARTSTEAL;
    //     if (state == gamestate.HEARTSTEAL)
    //     {
    //         player.CollectedHearts += heartWorth;
    //         actualHearts++;
    //         state = gamestate.RUNNING;
    //     }
    // }
    public void GetCaught()
    {
        actualHearts = 0;
    }
    public void GameOver()
    {
        state = gamestate.GAMEOVER;
    }
    public void Fight()
    {
        if (state != gamestate.FIGHTING)
        {
            state = gamestate.FIGHTING;
        }
    }
}
