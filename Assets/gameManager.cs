using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int heartsStolen;
    public static int staticHeartsStolen;

    void Start()
    {
        
    }

    void Update()
    {
        heartsStolen = staticHeartsStolen;
    }
}
