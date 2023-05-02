using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetSwapper : MonoBehaviour
{
    [SerializeField] private Image weatherIcon;

    private void Start()
    {
        GameManager.Instance.world.OnWeatherChanged += SwapWeatherAssets;
        GameManager.Instance.world.OnTimeOfDayChange += SwapTimeOfDayAssets;
        
    }

    public void SwapWeatherAssets(WorldData world)
    {
        if (world != null)
        {
            switch (world.CurrentWeather)
            {
                case WorldData.Weather.cloudy:
                    //Set cloudy weather and use assets
                    break;
                case WorldData.Weather.clear:
                    //Set clear weather and use assets
                    break;
                case WorldData.Weather.rainy:
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
            switch (world.CurrentTime)
            {
                case WorldData.TimeOfDay.sunrise:
                    //Set background and use assets
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Sunrise/sunriseIcon");
                    break;
                case WorldData.TimeOfDay.day:
                    //Set background and use assets
                    //Ex
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Day/sunIcon");
                    break;
                case WorldData.TimeOfDay.sunset:
                    //Set background and use assets
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Sunset/sunsetIcon");
                    break;
                case WorldData.TimeOfDay.night:
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
