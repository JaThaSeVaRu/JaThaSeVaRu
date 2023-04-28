using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenManager : MonoBehaviour
{
    [SerializeField] private Transform Icons; 
    [SerializeField] private float IconsY;
    [SerializeField] private Transform StationName;
    [SerializeField] private float StationNameY;

    void Start()
    {
        Icons.DOMove(Icons.position + (Vector3.down * IconsY), 2).SetDelay(3).SetEase(Ease.InOutBack);
        StationName.DOMove(StationName.position + (Vector3.down * StationNameY), 2).SetDelay(3).SetEase(Ease.InOutBack);
    }
}
