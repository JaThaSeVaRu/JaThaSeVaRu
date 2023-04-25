using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetSwapper : MonoBehaviour
{
    [SerializeField] private Image weatherIcon;
    public void SwapWeatherAssets(WorldData world)
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

    public void SwapTimeOfDayAssets(WorldData world)
    {
        if (world != null)
        {
            switch (world.currentTime)
            {
                case WorldData.CurrentTime.sunrise:
                    //Set background and use assets
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Sunrise/sunriseIcon");
                    break;
                case WorldData.CurrentTime.day:
                    //Set background and use assets
                    //Ex
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Day/sunIcon");
                    break;
                case WorldData.CurrentTime.sunset:
                    //Set background and use assets
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Sunset/sunsetIcon");
                    break;
                case WorldData.CurrentTime.night:
                    //Set background and use assets
                    //Ex
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Day/moonIcon");
                    break;
            }
        }
        else
        {
            //Use default assets (day)
        }
    }
        
}
