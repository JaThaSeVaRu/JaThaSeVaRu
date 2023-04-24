using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WorldData world;
    void Start()
    {
        world.GetSystemTime();
        world.GetWeather();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
