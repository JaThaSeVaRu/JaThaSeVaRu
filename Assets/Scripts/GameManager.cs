using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WorldData world;
    public PlayerData player;
    void Start()
    {
        world.GetSystemTime();
        world.GetWeather();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.location.status == LocationServiceStatus.Running)
        {
            player.Coordinates = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
        }
    }
}