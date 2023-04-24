using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Testing Stuff
    public TextMeshProUGUI ClosestStationText;
    public TextMeshProUGUI PlayerLocationText;
    public TextMeshProUGUI CurrentTimeText;
    
    public TextMeshProUGUI CurrentWeatherText;
    public PlayerData player;
    public WorldData world;

    private void Update() 
    {
        player.Coordinates.x = Input.location.lastData.latitude;
        player.Coordinates.y = Input.location.lastData.longitude;
        player.time = Input.location.lastData.timestamp;
        PlayerLocationText.text = player.Coordinates.ToString();
       // ClosestStationText.text = StationFinder.instance.ClosestStation.StationName;
        //CurrentWeatherText.text = WeatherData.instance.Info.currently.summary;
        CurrentWeatherText.text = world.currentWeather.ToString();
        CurrentTimeText.text = world.currentTime.ToString();
    }
}
