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
    [SerializeField] private float timer;
    [SerializeField] private float timerShownLimit;
    [SerializeField] private bool shownStation;

    void Start()
    {
        iconsStartPosition = Icons.position;
        Icons.DOMove(Icons.position + (Vector3.down * IconsY), 2).SetDelay(3).SetEase(Ease.InOutBack);
        
        StationName.DOMove(StationName.position + (Vector3.down * StationNameY), 2).SetDelay(3).SetEase(Ease.InOutBack);

        GameManager.Instance.player.OnCollectHearts += TweenScore;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (!shownStation)
            HideUI();
    }

    private void HideUI()
    {
        if (timer >= timerShownLimit)
        {
            Icons.DOMove(iconsStartPosition, 2).SetDelay(3).SetEase(Ease.InOutBack);
            StationName.DOMove(StationName.position + (Vector3.up * StationNameY), 2).SetDelay(3).SetEase(Ease.InOutBack);
            timer = 0;
            shownStation = true;
        }
    }

    void TweenScore(PlayerData player)
    {
        GameManager.Instance.UiManager.HeartCounter.rectTransform.DOScale(2, 0.5f).SetEase(Ease.OutBounce).SetLoops(1);
    }
}
