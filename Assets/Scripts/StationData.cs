using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationData
{
    [SerializeField] public string StationName;
    [SerializeField] public Vector2 Coordinates;

    public StationData(string name, double lat, double lon)
    {
        this.StationName = name;
        this.Coordinates = new Vector2((float)lat, (float)lon);
    }
}
