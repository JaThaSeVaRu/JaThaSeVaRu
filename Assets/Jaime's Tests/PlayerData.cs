using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [SerializeField] public Vector2 Coordinates;
    [SerializeField] public float Velocity;
    [SerializeField] public StationData LastStation;
    [SerializeField] public StationData TargetStation;
    
}
