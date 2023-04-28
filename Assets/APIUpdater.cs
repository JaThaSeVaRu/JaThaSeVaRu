using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class APIUpdater : MonoBehaviour
{
    [SerializeField] private float GPSUpdateTimeInSeconds = 1;
    [SerializeField] private float StationsAPIUpdateTimeInMinutes = 2;
    [SerializeField] private float WeatherAPIUpdateTimeInMinutes = 30;
    void Start()
    {
        StartCoroutine((UpdateGPS()));
        UpdateStationsAPI();
        UpdateWeatherAPI();
    }

    IEnumerator UpdateGPS()
    {
        if (GameManager.instance.velocityFinder.updateGPSnum())
        {
            GameManager.instance.stationFinder.FindNearestStation();
        }
        yield return new WaitForSeconds(GPSUpdateTimeInSeconds);
        StartCoroutine(UpdateGPS());
    }
    void UpdateStationsAPI()
    {
        if (GameManager.instance.APIFinder.locationInitialized)
        {
            GameManager.instance.APIFinder.GetStationsInfo();
        }

        Invoke("UpdateStationsAPI", StationsAPIUpdateTimeInMinutes * 60);
    }
    void UpdateWeatherAPI()
    {
        if (GameManager.instance.weatherData.locationInitialized)
        {
            GameManager.instance.weatherData.GetWeatherInfo();
        }
        Invoke("UpdateWeatherAPI", WeatherAPIUpdateTimeInMinutes * 60);
    }
}
