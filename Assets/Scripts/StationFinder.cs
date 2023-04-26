using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StationFinder : MonoBehaviour
{
    [SerializeField] public List<StationData> Stations = new List<StationData>();
    public float ShortestDistance = 100f;
    public PlayerData player;
    public StationData ClosestStation;
    public StationData LastStation;
    public static StationFinder instance;
    void Awake()
    {
    	if(instance == null)
        {
        	instance = this;
        }
    }
    float cd = 3;
    private void Update() 
    {
        cd -= Time.deltaTime;
        //FindNearestStation();
    }

    public void clearStations()
    {
        Stations.Clear();
    }

    public void addStation(StationData newStation)
    {
        Stations.Add(newStation);
    }

    public void FindNearestStation() 
    {
        if (cd < 0)
        {
            StartCoroutine(SBahnStationFinder.instance.GetStationsInfo());
            StartCoroutine(Search());
            cd = 3;
        }
    }

    IEnumerator Search()
    {
        yield return new WaitForSeconds(3);
        foreach (StationData station in Stations)
        {
            float distance = Vector2.Distance(player.Coordinates, station.Coordinates);
            if (distance < ShortestDistance)
            {
                ShortestDistance = distance;
                ClosestStation = station;
            }
        }
        ShortestDistance = float.MaxValue;
        yield return null;
    }

}
