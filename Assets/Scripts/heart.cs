using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    //check if already in love
    public bool inLove;


    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //IMPORTANT: check lover-Script for extension of this script
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    //this script might get fused with the lover-Script later on


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pose"))
        {
            //if lover is not yet in love: increase amount of collected hearts by one and change inLove to true
            if (inLove == false)
            {
                GameManager.Instance.player.CollectedHearts++;
                inLove = true;
            }
        }
    }
}
