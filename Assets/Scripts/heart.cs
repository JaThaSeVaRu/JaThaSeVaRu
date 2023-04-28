using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public bool inLove;
    public GameObject LovePose, IdlePose;

    void Start()
    {
        LovePose.GetComponent<SpriteRenderer>().enabled = false;
        IdlePose.GetComponent<SpriteRenderer>().enabled = true;
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
                Debug.Log("Test");
                inLove = true;
                //Effekt
                LovePose.GetComponent<SpriteRenderer>().enabled = true;
                IdlePose.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
