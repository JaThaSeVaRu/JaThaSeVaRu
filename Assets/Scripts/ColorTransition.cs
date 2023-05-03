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
    public static ColorTransition instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Transition();
    }

    public void Transition(Color color)
    {
        BGmaterial.color = new Color(color.r, color.b, color.g, 1);
        //BGmaterial.color = Color.Lerp(BGcolors[currentColorIndex], BGcolors[(int) color], LightChange.instance.targetPoint);
        /*if(targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorIndex = targetColorIndex;
            targetColorIndex++;
            if(targetColorIndex == BGcolors.Length)
               targetColorIndex = 0;
        }
        */
    }
}
