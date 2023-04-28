using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class WorldData : ScriptableObject
{
    public event Action<WorldData> OnTimeOfDayChange;
    [SerializeField] public enum TimeOfDay
    {
        sunrise,//0
        day,//1
        sunset,//2
        night//3
    }
     private TimeOfDay currentTime;
     public TimeOfDay CurrentTime
     {
         get
         {
             return currentTime;
         }   // get method
         set
         {
             if (value != currentTime)
             {
                 currentTime = value;
                 OnTimeOfDayChange?.Invoke(this);
             }
         }  // set method
     }
    
    [SerializeField] public enum Weather
    {
        clear,//0
        cloudy,//1
        rainy,//2
    }

    public event Action<WorldData> OnWeatherChanged;
    
    private Weather currentWeather;
    public Weather CurrentWeather
    {
        get
        {
            return currentWeather;
        }   // get method
        set
        {
            if (value != currentWeather)
            {
                currentWeather = value;
                OnWeatherChanged?.Invoke(this);
            }
        }  // set method
    }
    
    
    
    public void GetSystemTime()
    {
        int systemHour = System.DateTime.Now.Hour;
        if(systemHour > 19)
            currentTime = TimeOfDay.sunset;
        else if(systemHour > 10)
            currentTime = TimeOfDay.day;
        else if(systemHour > 7)
            currentTime = TimeOfDay.sunrise;
        else
        {
            currentTime = TimeOfDay.night;
        }   
    }
    public void GetWeather()
    {
        if (WeatherData.instance.Info.currentConditions.icon == "clear-day" || WeatherData.instance.Info.currentConditions.icon == "clear-night")
        {
            CurrentWeather = Weather.clear;
        }
        else if (WeatherData.instance.Info.currentConditions.icon == "snow" || WeatherData.instance.Info.currentConditions.icon == "rain" || WeatherData.instance.Info.currentConditions.icon =="fog")
        {
            CurrentWeather = Weather.rainy;
        }
        else
        {
            CurrentWeather = Weather.cloudy;
        }
    }
}
