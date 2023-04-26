using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public bool inLove;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pose"))
        {
            if (inLove == false)
            {
                gameManager.staticHeartsStolen++;
                inLove = true;
            }
        }
    }
}
