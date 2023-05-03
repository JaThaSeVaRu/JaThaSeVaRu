using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightChange : MonoBehaviour
{
    public enum ColorOfTime
    {
        Sunrise,
        Day,
        Sunset,
        Night
    }


    public Color[] Lightcolors;
    public Light2D light;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    public float targetPoint;
    public float time;
    public static LightChange instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Change();
        GameManager.Instance.world.GetSystemTime();
    }

    Coroutine ChangeC;
    public void Change(ColorOfTime color)
    {
        if(ChangeC != null)
            StopCoroutine(ChangeC);
        ChangeC = StartCoroutine(ChangeCoroutine(color));
    }

    IEnumerator ChangeCoroutine(ColorOfTime color)
    {
        Debug.Log(color);
        targetPoint += Time.deltaTime / time;
        ColorTransition.instance.Transition(color);
        light.color = Color.Lerp(Lightcolors[currentColorIndex], Lightcolors[(int)color], targetPoint);
        if(light.color != Lightcolors[(int)color])
        {
            yield return new WaitForSeconds(Time.deltaTime);
            StartCoroutine(ChangeCoroutine(color));
        }
        else
        {
            targetPoint = 0;
        }
        
        /*if(targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;
            if(targetColorIndex == Lightcolors.Length)
               targetColorIndex = 0;
        }*/
        yield return null;
    }
}
