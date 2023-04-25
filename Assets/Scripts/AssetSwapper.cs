using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSwapper : MonoBehaviour
{
    [SerializeField] private WorldData world;

    void SwapWeatherAssets()
    {
        if (world != null)
        {
            switch (world.currentWeather)
            {
                case WorldData.CurrentWeather.cloudy:
                    //Set cloudy weather and use assets
                    break;
                case WorldData.CurrentWeather.clear:
                    //Set clear weather and use assets
                    break;
                case WorldData.CurrentWeather.rainy:
                    //Set rainy weather and use assets
                    break;
            }
        }
        else
        {
            //Use default assets (clear)
        }
    }

    void SwapTimeOfDayAssets()
    {
        if (world != null)
        {
            switch (world.currentTime)
            {
                case WorldData.CurrentTime.sunrise:
                    //Set background and use assets
                    break;
                case WorldData.CurrentTime.day:
                    //Set background and use assets
                    break;
                case WorldData.CurrentTime.sunset:
                    //Set background and use assets
                    break;
                case WorldData.CurrentTime.night:
                    //Set background and use assets
                    break;
            }
        }
        else
        {
            //Use default assets (day)
        }
    }
        
}
