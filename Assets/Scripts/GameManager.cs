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
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.location.status == LocationServiceStatus.Running)
        {
            player.Coordinates = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
        }
        StartCoroutine (SwapAssets());
        //Test swapping assets
        //swapper.SwapTimeOfDayAssets(world);
    }

    private IEnumerator SwapAssets()
    {
        swapper.SwapWeatherAssets(world);
        swapper.SwapTimeOfDayAssets(world);
        yield return new WaitForSeconds(timeBetweenUpdates * 60);
    }

}
