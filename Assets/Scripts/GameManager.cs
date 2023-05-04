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

    [SerializeField]
    private bool inTransit;
    [SerializeField]
    private bool atStation;
    public bool AtStation
    {
        get
        {
            return atStation;
        }
        set
        {
            if (value != atStation)
            {
                atStation = value;
                OnArrival?.Invoke();
            }
        }
    }
    public event Action OnArrival;
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
                OnStopVelocity?.Invoke();
            }
        }
    }
    public event Action OnStopVelocity;
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
        player.Velocity = 10;
        player.Coordinates = new Vector2(52.52198f, 13.41324f);
    }
    float timeUnder = 0;
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
            player.Velocity = Mathf.MoveTowards(player.Velocity, player.TargetVelocity, Time.deltaTime * 0.75f);
        }

        if (player.Velocity < 0.1f)
        {
            if (timeUnder == 0)
            {
                timeUnder = Time.realtimeSinceStartup;
            }
            else
            {
                if (Time.realtimeSinceStartup - timeUnder > 1)
                {
                    GameManager.Instance.InTransit = false;
                }
            }
        }
        else
        {
            timeUnder = 0;
            GameManager.Instance.InTransit = true;
        }

        //Test swapping assets
        //swapper.SwapTimeOfDayAssets(world);



        if (weather != world.CurrentWeather)
        {
            world.testInvoke();
            weather = world.CurrentWeather;
        }


    
    }

    WorldData.Weather weather;

    private IEnumerator SwapAssets()
    {
        swapper.SwapWeatherAssets(world);
        swapper.SwapTimeOfDayAssets(world);
        yield return new WaitForSeconds(timeBetweenUpdates * 60);
        StartCoroutine (SwapAssets());
    }

}
