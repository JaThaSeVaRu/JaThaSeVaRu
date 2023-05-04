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
    
    [SerializeField]
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
                Debug.Log("Weather changed to " + value);
                currentWeather = value;
                OnWeatherChanged?.Invoke(this);
            }
        }  // set method
    }

    public void testInvoke()
    {
        Debug.Log("Weather changed to " + value);
        OnWeatherChanged?.Invoke(this);
    }
    
    
    
    public void GetSystemTime()
    {
        int systemHour = System.DateTime.Now.Hour;
        
        if(22 > systemHour && systemHour >= 20)
            CurrentTime = TimeOfDay.sunset;
        else if(20 > systemHour && systemHour >= 9)
            CurrentTime = TimeOfDay.day;
        else if(9 > systemHour && systemHour >= 7)
            CurrentTime = TimeOfDay.sunrise;
        else
        {
            CurrentTime = TimeOfDay.night;
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
