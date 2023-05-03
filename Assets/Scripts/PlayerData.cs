using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public event Action<PlayerData> OnCoordinatesChange;
    [SerializeField] private Vector2 coordinates;
    public Vector2 Coordinates
    {
        get
        {
            return coordinates;
        }
        set
        {
            if (value != coordinates)
            {
                coordinates = value;
                OnCoordinatesChange?.Invoke(this);
            }
        }
    }

    public event Action<PlayerData> OnVelocityChange; 
    [SerializeField] private float velocity;

    public float TargetVelocity;

    public float Velocity
    {
        get
        {
            return velocity;
        }
        set
        {
            if (value != velocity)
            {
                velocity = value;
                OnVelocityChange?.Invoke(this);
            }
        }
    }
    [SerializeField] public StationData LastStation;
    [SerializeField] public StationData TargetStation;
    [SerializeField] public double time;

    public event Action<PlayerData> OnCollectHearts;
    [SerializeField] private int _collectedHearts;
    public int CollectedHearts
    {
        get
        {
            return _collectedHearts;
        }   // get method
        set
        {
            if (value != _collectedHearts)
            {
                _collectedHearts = value;
                OnCollectHearts?.Invoke(this);
            }
        }  // set method
    }
}
