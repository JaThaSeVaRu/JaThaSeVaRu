using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetSwapper : MonoBehaviour
{
    [SerializeField] private Image weatherIcon;
    public ParticleSystem StarsParticles;
    public ParticleSystem RainParticles; 
    private void Start()
    {
        GameManager.Instance.world.OnWeatherChanged += SwapWeatherAssets;
        GameManager.Instance.world.OnTimeOfDayChange += SwapTimeOfDayAssets;
        StarsParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        RainParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        
    }

    public void SwapWeatherAssets(WorldData world)
    {
        if (world != null)
        {
            RainParticles.Stop();
            switch (world.CurrentWeather)
            {
                case WorldData.Weather.cloudy:
                    //Set cloudy weather and use assets
                    background.instance.Transition(background.ColorOfWeather.Cloudy);
                    background.instance.Clouds(15);
                    break;
                case WorldData.Weather.clear:
                    //Set clear weather and use assets
                    background.instance.Transition(background.ColorOfWeather.Clear);
                    break;
                case WorldData.Weather.rainy:
                    //Set rainy weather and use assets
                    background.instance.Transition(background.ColorOfWeather.Rainy);
                    RainParticles.Play();
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
            StarsParticles.Stop();
            switch (world.CurrentTime)
            {
                case WorldData.TimeOfDay.sunrise:
                    //Set background and use assets
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Sunrise/sunriseIcon");
                    LightChange.instance.Change(LightChange.ColorOfTime.Sunrise);
                    break;
                case WorldData.TimeOfDay.day:
                    //Set background and use assets
                    //Ex
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Day/sunIcon");
                    LightChange.instance.Change(LightChange.ColorOfTime.Day);
                    break;
                case WorldData.TimeOfDay.sunset:
                    //Set background and use assets
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Sunset/sunsetIcon");
                    LightChange.instance.Change(LightChange.ColorOfTime.Sunset);
                    break;
                case WorldData.TimeOfDay.night:
                    //Set background and use assets
                    //Ex
                    StarsParticles.Play();
                    weatherIcon.sprite = Resources.Load<Sprite>("TimeOfDay/Day/moonIcon");
                    LightChange.instance.Change(LightChange.ColorOfTime.Night);
                    break;
            }
        }
        else
        {
            //Use default assets (day)
        }
    }
        
}
