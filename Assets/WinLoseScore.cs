using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum gamestate { RUNNING, GAMEOVER, CAUGHT, FIGHTING, HEARTSTEAL }
public class WinLoseScore : MonoBehaviour
{
    public gamestate state;

    public int stolenHearts;
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

        ButtonInput();

    }

    /*public void Texts()
    {
        hearts.text = "Score: " + stolenHearts;
        trueHearts.text = "stolen Hearts: " + player.CollectedHearts;
        nextHeart.text = "Worth of next heart: " + heartWorth;

        if (state == gamestate.GAMEOVER)
        {
            stateText.text = "Game Over";
        }
        if (state == gamestate.RUNNING)
        {
            stateText.text = "Running";
        }
        if (state == gamestate.FIGHTING)
        {
            stateText.text = "Fight!";
        }
        if (state == gamestate.HEARTSTEAL)
        {
            stateText.text = "stealing heart";
        }
        if (state == gamestate.CAUGHT)
        {
            GetCaught();
            stateText.text = "you got caught";
        }

    }*/

    public void ButtonInput()
    {
        /*if (Input.GetKeyDown("up") && state == gamestate.RUNNING)
        {
            StealHeart();
        }
        if (Input.GetKeyDown("left") && state == gamestate.RUNNING)
        {
            state = gamestate.CAUGHT;
        }
        if (Input.GetKeyDown("down") && state == gamestate.RUNNING)
        {
            GameOver();
        }
        if (Input.GetKeyDown("right") && state == gamestate.RUNNING)
        {
            Fight();
        }*/

    }

    public void StealHeart()
    {
        state = gamestate.HEARTSTEAL;
        if (state == gamestate.HEARTSTEAL)
        {
            stolenHearts += heartWorth;
            player.CollectedHearts += heartWorth;
            actualHearts++;
            state = gamestate.RUNNING;
        }
    }
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
