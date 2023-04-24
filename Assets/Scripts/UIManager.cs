using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ClosestStationText;
    public TextMeshProUGUI PlayerLocationText;
    public TextMeshProUGUI CurrentWeatherText;
    public TextMeshProUGUI CurrentTimeText;
    public PlayerData player;
    public WeatherData weather;
    public WorldData world;

    private void Update() 
    {
        player.Coordinates.x = Input.location.lastData.latitude;
        player.Coordinates.y = Input.location.lastData.longitude;
        player.time = Input.location.lastData.timestamp;
        PlayerLocationText.text = player.Coordinates.ToString();
        ClosestStationText.text = StationFinder.instance.ClosestStation.StationName;
        //CurrentWeatherText.text = WeatherData.instance.Info.currently.summary;
        CurrentWeatherText.text = world.currentWeather.ToString();
        CurrentTimeText.text = world.currentTime.ToString();
    }
}
