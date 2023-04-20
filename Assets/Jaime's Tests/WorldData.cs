using UnityEngine;

[CreateAssetMenu]
public class WorldData : ScriptableObject
{
    [SerializeField] public enum CurrentTime
    {
        sunrise,//0
        day,//1
        sunset,//2
        night//3
    }
    public CurrentTime currentTime;
    [SerializeField] public enum CurrentWeather
    {
        clear,//0
        cloudy,//1
        rainy,//2
    }
    public CurrentWeather currentWeather;
    public void GetSystemTime()
    {
        int systemHour = System.DateTime.Now.Hour;
        if(systemHour > 19)
            currentTime = CurrentTime.sunset;
        else if(systemHour > 10)
            currentTime = CurrentTime.day;
        else if(systemHour > 7)
            currentTime = CurrentTime.sunrise;
        else
        {
            currentTime = CurrentTime.night;
        }   
    }
    public void GetWeather()
    {
        if (WeatherData.instance.Info.currentConditions.icon == "clear-day" || WeatherData.instance.Info.currentConditions.icon == "clear-night")
        {
            currentWeather = CurrentWeather.clear;
        }
        else if (WeatherData.instance.Info.currentConditions.icon == "snow" || WeatherData.instance.Info.currentConditions.icon == "rain" || WeatherData.instance.Info.currentConditions.icon =="fog")
        {
            currentWeather = CurrentWeather.rainy;
        }
        else
        {
            currentWeather = CurrentWeather.cloudy;
        }
    }
}
