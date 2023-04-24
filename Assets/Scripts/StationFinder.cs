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
    private void Update() 
    {
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
        foreach (StationData station in Stations)
        {
            float distance = Vector2.Distance(player.Coordinates, station.Coordinates);
            if(distance < ShortestDistance)
            {
                ShortestDistance = distance;
                ClosestStation = station;
            }
        }
        ShortestDistance = 100;
    }

}
