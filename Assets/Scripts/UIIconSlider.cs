using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIconSlider : MonoBehaviour
{
    private RectTransform UIObject;
    [SerializeField] private Vector3 goalPosition;
    [SerializeField] private Transform showObjectPosition;
    [SerializeField] private Transform hideObjectPosition;
    [SerializeField] private float showObjectForSeconds;
    [SerializeField] private float slideSpeed;
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] private float graphValue;

    void Awake()
    {
        if (this.transform.position != hideObjectPosition.position)
        {
            this.transform.position = hideObjectPosition.position;
            goalPosition = showObjectPosition.position;
        }
        ShowUIIcon();
    }
    void ShowUIIcon()
    {
        
        
    }

    void HideUIIcon()
    {
        goalPosition = hideObjectPosition.position;
    }
}
