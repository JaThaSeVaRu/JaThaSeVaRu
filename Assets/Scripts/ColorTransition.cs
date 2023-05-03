using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTransition : MonoBehaviour
{
    public Material BGmaterial;
    public Color[] BGcolors;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;
    public float time;

    // Update is called once per frame
    void Update()
    {
        Transition();
    }

    void Transition()
    {
        targetPoint += Time.deltaTime / time;
        BGmaterial.color = Color.Lerp(BGcolors[currentColorIndex], BGcolors[targetColorIndex], targetPoint);
        if(targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;
            if(targetColorIndex == BGcolors.Length)
               targetColorIndex = 0;
        }
    }
}
