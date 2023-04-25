using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WeatherData : MonoBehaviour {
	private float timer;
	public float minutesBetweenUpdate;
	public WeatherInfo Info;
	public string API_key;
	private float latitude;
	private float longitude;
	private bool locationInitialized;
	public PlayerData player;
	public static WeatherData instance;
    void Awake()
    {
    	if(instance == null)
        {
        	instance = this;
        }
    }
    public void Start() {
		latitude = player.Coordinates.x;
		longitude = player.Coordinates.y;
        int day = System.DateTime.Now.Day;
        int month = System.DateTime.Now.Month;
        int year = System.DateTime.Now.Year;
		locationInitialized = true;
	}
	void Update() {
		if (locationInitialized) {
			locationInitialized = false;
			if (timer <= 0) {
				StartCoroutine (GetWeatherInfo ());
				timer = minutesBetweenUpdate * 60;
			} else {
				timer -= Time.deltaTime;
			}
		}
	}
	private IEnumerator GetWeatherInfo()
	{
		var www = new UnityWebRequest(
        "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + latitude + "%2C" + longitude + "/today?unitGroup=metric&elements=temp%2Cwindspeed%2Csunrise%2Csunset%2Cicon&key=" + API_key + "&contentType=json")
		{
			downloadHandler = new DownloadHandlerBuffer()
		};
        Debug.Log("Getting Weather data.");
		yield return www.SendWebRequest();

		if (www.error != null)
		{
			//error
            Debug.Log("Something went wrong with Weather API");
			yield break;
		}
        Debug.Log("We got weather data");
		Info = JsonUtility.FromJson<WeatherInfo>(www.downloadHandler.text);
        //Debug.Log(www.downloadHandler.text);
	}
}
[Serializable]
public class WeatherInfo
{
    public CurrentConditions currentConditions;
}

[Serializable]
public class CurrentConditions
{
	public string datetime;
    public float datetimeEpoch;
    public float temp;
    public float windspeed;
    public string icon;
    public string sunrise;
    public string sunset;
}
