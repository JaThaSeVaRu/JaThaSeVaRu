using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenManager : MonoBehaviour
{
    [SerializeField] private Transform Icons; 
    [SerializeField] private float IconsY;
    private Vector3 iconsStartPosition;
    [SerializeField] private Transform StationName;
    [SerializeField] private float StationNameY;
    [SerializeField] private bool shownStation;

    void Start()
    {
        iconsStartPosition = Icons.position;
        GameManager.Instance.stationFinder.OnClosestStationChange += ShowStationName;
        GameManager.Instance.player.OnCollectHearts += TweenScore;
    }
    
    private IEnumerator HideUI()
    {
        yield return new WaitForSeconds(2);
        Icons.DOMove(iconsStartPosition, 2).SetDelay(3).SetEase(Ease.InOutBack);
        StationName.DOMove(StationName.position + (Vector3.up * StationNameY), 2).SetDelay(3).SetEase(Ease.InOutBack);
    }

    void ShowWorldIcons(WorldData world)
    {
        Icons.DOMove(Icons.position + (Vector3.down * IconsY), 2).SetDelay(3).SetEase(Ease.InOutBack);
    }

    void ShowStationName()
    {
        StationName.DOMove(StationName.position + (Vector3.down * StationNameY), 2).SetDelay(3).SetEase(Ease.InOutBack);
        StartCoroutine(HideUI());
    }

    public void TweenScore(PlayerData player)
    {
        Icons.DOScale(2, 0.5f).SetEase(Ease.InOutBack).SetLoops(1);
    }
}
