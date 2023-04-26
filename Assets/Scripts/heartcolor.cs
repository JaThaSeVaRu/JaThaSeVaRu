using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartcolor : MonoBehaviour
{
    public SpriteRenderer m_SpriteRenderer;

    public GameObject heart;

    public Color coldColor;
    public Color loveColor;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();


        m_SpriteRenderer.color = coldColor;
    }

    void Update()
    {
        if (heart.GetComponent<heart>().inLove == true)
        {
            m_SpriteRenderer.color = loveColor;
        }
    }

}
