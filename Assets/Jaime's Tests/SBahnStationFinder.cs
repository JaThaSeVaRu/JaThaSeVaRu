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
        "https://maps.googleapis.com/maps/api/place/search/json?location=" + latitude + "," + longitude + "&radius=" + searchRadius + "&keyword=sbahn&type=light_rail_station&key=" + API_key)
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
		Info = JsonUtility.FromJson<StationInfo>(www.downloadHandler.text);
        Debug.Log(www.downloadHandler.text);
		Debug.Log(Info.results);
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
}
