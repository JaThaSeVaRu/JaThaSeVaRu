using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIconSlider : MonoBehaviour
{
    private RectTransform UIObject;
    [SerializeField] private Vector3 goalPosition;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float showObjectForSeconds;
    [SerializeField] private float slideSpeed;
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] private float graphValue;

    void Awake()
    {
        goalPosition = GetComponentInParent<Transform>().position;
        startPosition = Transform.position;
        animationCurve.postWrapMode = WrapMode.Once;
    }
    void Update()
    {
        
    }

    private IEnumerator SlideObject()
    {
        //Animate
        yield return WaitForSeconds(showObjectForSeconds);
        //Animate backwards
    }
}
