using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public enum CurrentScreen
    {
        startScreen,
        gameScreen,
        pauseScreen
    }

    public CurrentScreen currentScreen;
    //UI Texts
    public TextMeshProUGUI ClosestStationText;
    public TextMeshProUGUI CurrentTimeText;
    public TextMeshProUGUI HeartCounter;
    public TextMeshProUGUI CurrentWeatherText;

    //Game UI
    public RectTransform IconsUI;
    public RectTransform ButtonsUI;
    public Vector2 LeftSideMaxAnchor;
    public Vector2 LeftSideMinAnchor;
    public Vector2 LeftSidePivot;
    public Vector2 RightSideMaxAnchor;
    public Vector2 RightSideMinAnchor;
    public Vector2 RightSidePivot;
    public bool ButtonsOnTheRight;
    
    //Menu UI
    public GameObject StartScreenUI;
    public GameObject GameUI;
    public GameObject PauseUI;

    public TweenManager tweener;

    private void Start()
    {
        //Set StartScreen first
        OpenStartUI();
        
        //Set anchors for game UI elements
        LeftSideMinAnchor = new Vector2(0, 1);
        LeftSideMaxAnchor = new Vector2(0, 1);
        LeftSidePivot = new Vector2(0, 1);

        RightSideMinAnchor = new Vector2(1, 1);
        RightSideMaxAnchor = new Vector2(1, 1);
        RightSidePivot = new Vector2(1, 1);

        ButtonsOnTheRight = ButtonsUI.anchorMax == RightSideMaxAnchor ? true : false;

        GameManager.Instance.player.OnCollectHearts += UpdateScoreUI;
        GameManager.Instance.stationFinder.OnClosestStationChange += UpdateUIStationName;
        
    }

    private void Update() 
    {
        //CurrentWeatherText.text = WeatherData.instance.Info.currently.summary;
        CurrentWeatherText.text = GameManager.Instance.world.CurrentWeather.ToString();
        CurrentTimeText.text = GameManager.Instance.world.CurrentTime.ToString();
        
        //Test swapping sides
        if (Input.GetKey(KeyCode.A))
        {
            SwapUISide();
        }

        
    }

    public void SwapUISide()
    {
        if (ButtonsOnTheRight)
        {
            ButtonsUI.anchorMax = LeftSideMaxAnchor;
            ButtonsUI.anchorMin = LeftSideMinAnchor;
            ButtonsUI.pivot = LeftSidePivot;

            IconsUI.anchorMax = RightSideMaxAnchor;
            IconsUI.anchorMin = RightSideMinAnchor;
            IconsUI.pivot = RightSidePivot;

            ButtonsOnTheRight = false;
        }
        else
        {
            ButtonsUI.anchorMax = RightSideMaxAnchor;
            ButtonsUI.anchorMin = RightSideMinAnchor;
            ButtonsUI.pivot = RightSidePivot;

            IconsUI.anchorMax = LeftSideMaxAnchor;
            IconsUI.anchorMin = LeftSideMinAnchor;
            IconsUI.pivot = LeftSidePivot;
            
            ButtonsOnTheRight = true; 
        }
    }

    public void SwapUIMenus()
    {
        switch (currentScreen)
        {
            case CurrentScreen.startScreen:
                StartScreenUI.gameObject.SetActive(true);
                GameUI.gameObject.SetActive(false);
                PauseUI.gameObject.SetActive(false);
                Time.timeScale = 1;
                break;
            case CurrentScreen.gameScreen:
                StartScreenUI.gameObject.SetActive(false);
                GameUI.gameObject.SetActive(true);
                PauseUI.gameObject.SetActive(false);
                Time.timeScale = 1;
                break;
            case CurrentScreen.pauseScreen:
                StartScreenUI.gameObject.SetActive(false);
                GameUI.gameObject.SetActive(false);
                PauseUI.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
            default:
                StartScreenUI.gameObject.SetActive(true);
                GameUI.gameObject.SetActive(false);
                PauseUI.gameObject.SetActive(false);
                Time.timeScale = 1;
                break;
        }
    }

    public void OpenGameUI()
    {
        currentScreen = CurrentScreen.gameScreen;
        SwapUIMenus();
    }
    public void OpenStartUI()
    {
        currentScreen = CurrentScreen.startScreen;
        SwapUIMenus();
    }
    public void OpenPauseUI()
    {
        currentScreen = CurrentScreen.pauseScreen;
        SwapUIMenus();
    }

    void UpdateScoreUI(PlayerData player)
    {
        HeartCounter.text = player.CollectedHearts.ToString();
        tweener.TweenScore(HeartCounter.rectTransform);
    }

    void UpdateUIStationName()
    {
        if(StationFinder.instance.ClosestStation != null)
            ClosestStationText.text = StationFinder.instance.ClosestStation.StationName;
    }
}
