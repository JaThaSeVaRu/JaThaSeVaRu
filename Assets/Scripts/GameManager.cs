using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public WorldData world;
    public PlayerData player;
    public AssetSwapper swapper;
    public SBahnStationFinder APIFinder;
    public StationFinder stationFinder;
    public VelocityFinder velocityFinder;
    public WeatherData weatherData;
    public UIManager UiManager;
    private bool inTransit;
    public bool atStation;
    public bool InTransit
    {
        get
        {
            return inTransit;
        }
        set
        {
            if (value != inTransit)
            {
                inTransit = value;
                OnArrival?.Invoke();
            }
        }
    }
    public event Action OnArrival;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    private static GameManager instance;

    public float timeBetweenUpdates;
    void Start()
    {
        world.GetSystemTime();
        world.GetWeather();
        player.CollectedHearts = 0;
        StartCoroutine (SwapAssets());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (UnityEngine.Input.location.status == LocationServiceStatus.Running)
        {
            player.Coordinates = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
        }*/

        if(player.Velocity != player.TargetVelocity)
        {
            player.Velocity = Mathf.Lerp(player.Velocity, player.TargetVelocity, Time.deltaTime);
        }
        
        //Test swapping assets
        //swapper.SwapTimeOfDayAssets(world);
    }

    private IEnumerator SwapAssets()
    {
        swapper.SwapWeatherAssets(world);
        swapper.SwapTimeOfDayAssets(world);
        yield return new WaitForSeconds(timeBetweenUpdates * 60);
        StartCoroutine (SwapAssets());
    }

}
