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
	public float searchRadius;
	public bool locationInitialized;
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
		locationInitialized = true;
	}
	// void Update() {
	// 	if (locationInitialized) {
	// 		if (timer <= 0) {
	// 			//StartCoroutine (GetStationsInfo ());
	// 			
	// 			timer = minutesBetweenUpdate * 10;
	// 		} else {
	// 			timer -= Time.deltaTime;
	// 		}
	// 	}
	// }


	public IEnumerator GetStationsInfo()
	{
		var www = new UnityWebRequest(
        "https://maps.googleapis.com/maps/api/place/search/json?location=" + player.Coordinates.x.ToString().Replace(",",".") + "," + player.Coordinates.y.ToString().Replace(",", ".") + "&radius=" + searchRadius + "&keyword=&type=train_station&key=" + API_key)
		{
			downloadHandler = new DownloadHandlerBuffer()
		};
		Debug.Log(www.url);
        Debug.Log("Getting station data.");
		yield return www.SendWebRequest();

		if (www.error != null)
		{
			//error
            Debug.Log("Something went wrong with Station API");
			yield break;
		}
        Debug.Log("We got station data");
		Info = JsonConvert.DeserializeObject<StationInfo>(www.downloadHandler.text);
		//Info = JsonUtility.FromJson<StationInfo>(www.downloadHandler.text);
		Debug.Log(www.downloadHandler.text);
		StationFinder.instance.clearStations();
		foreach (PlaceDetails pd in Info.results)
		{

			StationFinder.instance.addStation(new StationData(pd.name, pd.geometry.location.lat, pd.geometry.location.lng));
			Debug.Log(pd.geometry.location.ToString());
		}

		yield return new WaitForSeconds(0);
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
