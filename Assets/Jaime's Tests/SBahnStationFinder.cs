using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SBahnStationFinder : MonoBehaviour {
	private float timer;
	public float minutesBetweenUpdate;
	public StationInfo Info;
	public string API_key;
	private float latitude;
	private float longitude;
	public float searchRadius;
	private bool locationInitialized;
	public PlayerData player;
	public static SBahnStationFinder instance;
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
		locationInitialized = true;
	}
	void Update() {
		if (locationInitialized) {
			locationInitialized = false;
			if (timer <= 0) {
				StartCoroutine (GetStationsInfo ());
				timer = minutesBetweenUpdate * 60;
			} else {
				timer -= Time.deltaTime;
			}
		}
	}
	private IEnumerator GetStationsInfo()
	{
		var www = new UnityWebRequest(
        "https://maps.googleapis.com/maps/api/place/search/json?location=" + latitude.ToString().Replace(",",".") + "," + longitude.ToString().Replace(",", ".") + "&radius=" + searchRadius + "&keyword=&type=train_station&key=" + API_key)
		{
			downloadHandler = new DownloadHandlerBuffer()
		};
		Debug.Log(www.url);
        Debug.Log("Getting station data.");
		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			//error
            Debug.Log("Something went wrong with Station API");
			yield break;
		}
        Debug.Log("We got station data");
		Info = JsonConvert.DeserializeObject<StationInfo>(www.downloadHandler.text);
		//Info = JsonUtility.FromJson<StationInfo>(www.downloadHandler.text);
		Debug.Log(www.downloadHandler.text);
		foreach (PlaceDetails pd in Info.results)
		{
			Debug.Log(pd.geometry.location.ToString());
		}
	}
}
[Serializable]
public class StationInfo
{
    public PlaceDetails[] results;
}
[Serializable]
public class PlaceDetails
{
	public string business_status;
	public Geometry geometry;
	public string icon;
	public string icon_background_color;
	public string icon_mask_base_uri;
	public string name;
}
[Serializable]
public class Geometry
{
	public Location location;
}
public class Location
{
	public double lat;
	public double lng;

    public override string ToString()
    {
		return lat + "," + lng;
    }
}
