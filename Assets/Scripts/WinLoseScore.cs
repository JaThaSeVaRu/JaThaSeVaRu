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
    
    public static int actualHearts;
    public int actualHeartsCheck;
    public static int heartWorth;
    public int heartWorthCheck;
    public static int score;
    public int scoreCheck;

    public string scoreString;

    public float stayTime;
    public float returnTime;

    public GameObject Loose;

    public PlayerData player;

    public TextMeshProUGUI Bonus;

    void Start()
    {
        state = gamestate.RUNNING;
        Loose.GetComponent<SpriteRenderer>().enabled = false;

    }
    
    void Update()
    {
        heartWorth = Mathf.FloorToInt(1 + (actualHearts / 3f));

        if (Bonus.fontSize <= 140)
        {
            Bonus.fontSize = 20 + (heartWorth * 20);
        }
        if (Bonus.fontSize > 140)
        {
            Bonus.fontSize = 140;
        }


        //this one was only for testing
        if (Input.GetKeyDown("space"))
        {
            actualHearts++;
            Debug.Log("bonus up");
        }

        if (state == gamestate.FIGHTING || state == gamestate.CAUGHT)
        {
            stayTime += Time.deltaTime;
        }
        if (stayTime >= returnTime)
        {
            state = gamestate.RUNNING;
            stayTime = 0;
        }

        actualHeartsCheck = actualHearts;
        heartWorthCheck = heartWorth;
        scoreCheck = score;
        GameManager.Instance.player.CollectedHearts = score;
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
        Loose.GetComponent<SpriteRenderer>().enabled = true;
        Loose.GetComponent<Animator>().Play("loose_con", 0, 0);
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
