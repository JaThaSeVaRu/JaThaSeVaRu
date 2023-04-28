using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class APIUpdater : MonoBehaviour
{
    [SerializeField] private float GPSUpdateTime;
    [SerializeField] private float StationsAPIUpdateTime;
    [SerializeField] private float WeatherAPIUpdateTime;
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
        yield return new WaitForSeconds(GPSUpdateTime * 60);
        StartCoroutine(UpdateGPS());
    }
    void UpdateStationsAPI()
    {
        if (GameManager.instance.APIFinder.locationInitialized)
        {
            GameManager.instance.APIFinder.GetStationsInfo();
        }

        Invoke("UpdateStationsAPI", StationsAPIUpdateTime * 60);
    }
    void UpdateWeatherAPI()
    {
        if (GameManager.instance.weatherData.locationInitialized)
        {
            GameManager.instance.weatherData.GetWeatherInfo();
        }
        Invoke("UpdateWeatherAPI", StationsAPIUpdateTime * 60);
    }
}
