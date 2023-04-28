using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StationFinder : MonoBehaviour
{
    [SerializeField] public List<StationData> Stations = new List<StationData>();
    public float ShortestDistance = 100f;
    public float WaitTimeToUpdateClosestStation;
    public event Action<StationData> OnClosestStationChange;
    public StationData closestStation;
    public StationData ClosestStation
    {
        get
        {
            return closestStation; 
        }
        set
        {
            if (value != closestStation)
            {
                closestStation = value;
                OnClosestStationChange?.Invoke(closestStation);
            }
        }
    }
    public static StationFinder instance;
    void Awake()
    {
    	if(instance == null)
        {
        	instance = this;
        }

        GameManager.instance.player.OnVelocityChange += DetermineArrivalToStation;
    }
    private void Update() 
    {
        WaitTimeToUpdateClosestStation -= Time.deltaTime;
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
        if (WaitTimeToUpdateClosestStation < 0)
        {
            //StartCoroutine(SBahnStationFinder.instance.GetStationsInfo());
            StartCoroutine(Search());
            WaitTimeToUpdateClosestStation = 10;
        }
    }

    IEnumerator Search()
    {
        yield return new WaitForSeconds(3);
        foreach (StationData station in Stations)
        {
            float distance = Vector2.Distance(GameManager.instance.player.Coordinates, station.Coordinates);
            if (distance < ShortestDistance)
            {
                ShortestDistance = distance;
                ClosestStation = station;
            }
        }
        ShortestDistance = float.MaxValue;
        yield return null;
    }

    void DetermineArrivalToStation(PlayerData player)
    {
        if (Vector2.Distance(player.Coordinates, ClosestStation.Coordinates) < 500 && player.Velocity < 5)
        {
            Debug.Log("Arriving to station: " + ClosestStation.StationName);
        }
    }

}
