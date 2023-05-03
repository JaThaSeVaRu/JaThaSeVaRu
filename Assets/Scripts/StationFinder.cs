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
    public event Action OnClosestStationChange;
    private StationData closestStation;
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
                OnClosestStationChange?.Invoke();
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

        GameManager.Instance.player.OnVelocityChange += DetermineArrivalToStation;
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
            StartCoroutine(GameManager.Instance.APIFinder.GetStationsInfo());
            StartCoroutine(Search());
            WaitTimeToUpdateClosestStation = 10;
        }
    }

    IEnumerator Search()
    {
        yield return new WaitForSeconds(3);
        foreach (StationData station in Stations)
        {
            float distance = Vector2.Distance(GameManager.Instance.player.Coordinates, station.Coordinates);
            if (distance < ShortestDistance)
            {
                ShortestDistance = distance;
                ClosestStation = station;
            }
        }
        ShortestDistance = float.MaxValue;
        yield return null;
    }

    private float timeUnder;
    public void DetermineArrivalToStation(PlayerData player)
    {
        if (ClosestStation != null)
        {
            if (player.Velocity < 5)
            {
                if (timeUnder == 0)
                {
                    timeUnder = Time.realtimeSinceStartup;
                }
                else
                {
                    if (Time.realtimeSinceStartup - timeUnder > 10)
                    {
                        GameManager.Instance.InTransit = false;
                    }
                }
            }
            else
            {
                timeUnder = 0;
                GameManager.Instance.InTransit = true;
            }


            if (GameManager.Instance.velocityFinder.calculateGPSDistance(player.Coordinates.x, player.Coordinates.y,
                    closestStation.Coordinates.x, closestStation.Coordinates.y) < 0.5f)
            {
                GameManager.Instance.atStation = true;
            }
            else
            {
                GameManager.Instance.atStation = true;
            }
        }
        else
        {
            print("No station coordinates");
        }
        
        
    }

}
