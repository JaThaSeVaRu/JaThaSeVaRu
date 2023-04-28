using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightChange : MonoBehaviour
{
    public Color[] Lightcolors;
    public Light2D light;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        //Light light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Change();
    }

    void Change()
    {
        targetPoint += Time.deltaTime / time;
        light.color = Color.Lerp(Lightcolors[currentColorIndex], Lightcolors[targetColorIndex], targetPoint);
        if(targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;
            if(targetColorIndex == Lightcolors.Length)
               targetColorIndex = 0;
        }
    }
}
